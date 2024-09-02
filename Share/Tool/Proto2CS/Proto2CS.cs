using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ET
{
    internal class OpcodeInfo
    {
        public string Name;
        public int Opcode;
    }

    public static class Proto2CS
    {
        public static void Export()
        {
            InnerProto2CS.Proto2CS();
            Log.Console("proto2cs succeed!");
        }
    }

    public static partial class InnerProto2CS
    {
        private const string protoDir = "../Unity/Assets/Config/Proto";
        private const string clientMessagePath = "../Unity/Assets/Scripts/Model/Generate/Client/Message/";
        private const string serverMessagePath = "../Unity/Assets/Scripts/Model/Generate/Server/Message/";
        private const string clientServerMessagePath = "../Unity/Assets/Scripts/Model/Generate/ClientServer/Message/";
        
        private const string serverMessageEntityPath = "../Unity/Assets/Scripts/Model/Share/ProtoToEntity/";

        private static readonly char[] splitChars = [' ', '\t'];
        private static readonly List<OpcodeInfo> msgOpcode = [];

        public static void Proto2CS()
        {
            msgOpcode.Clear();

            RemoveAllFilesExceptMeta(clientMessagePath);
            RemoveAllFilesExceptMeta(serverMessagePath);
            RemoveAllFilesExceptMeta(clientServerMessagePath);
            
            RemoveAllFilesExceptMeta(serverMessageEntityPath);

            List<string> list = FileHelper.GetAllFiles(protoDir, "*proto");
            foreach (string s in list)
            {
                if (!s.EndsWith(".proto"))
                {
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(s);
                string[] ss2 = fileName.Split('_');
                string protoName = ss2[0];
                string cs = ss2[1];
                int startOpcode = int.Parse(ss2[2]);

                ProtoFile2CS(fileName, protoName, cs, startOpcode);
                if (protoName == "OuterMessage")
                {
                    ProtoFile2Entity(fileName);
                }
            }

            RemoveUnusedMetaFiles(clientMessagePath);
            RemoveUnusedMetaFiles(serverMessagePath);
            RemoveUnusedMetaFiles(clientServerMessagePath);
            
            RemoveUnusedMetaFiles(serverMessageEntityPath);
        }

        private static void ProtoFile2CS(string fileName, string protoName, string cs, int startOpcode)
        {
            msgOpcode.Clear();

            string proto = Path.Combine(protoDir, $"{fileName}.proto");
            string s = File.ReadAllText(proto);

            StringBuilder sb = new();
            sb.Append("using MemoryPack;\n");
            sb.Append("using System.Collections.Generic;\n\n");
            sb.Append($"namespace ET\n");
            sb.Append("{\n");

            bool isMsgStart = false;
            string msgName = "";
            string responseType = "";
            StringBuilder sbDispose = new();
            Regex responseTypeRegex = ResponseTypeRegex();
            foreach (string line in s.Split('\n'))
            {
                string newline = line.Trim();
                if (string.IsNullOrEmpty(newline))
                {
                    continue;
                }

                if (responseTypeRegex.IsMatch(newline))
                {
                    responseType = responseTypeRegex.Replace(newline, string.Empty);
                    responseType = responseType.Trim().Split(' ')[0].TrimEnd('\r', '\n');
                    continue;
                }

                if (!isMsgStart && newline.StartsWith("//"))
                {
                    if (newline.StartsWith("///"))
                    {
                        sb.Append("\t/// <summary>\n");
                        sb.Append($"\t/// {newline.TrimStart('/', ' ')}\n");
                        sb.Append("\t/// </summary>\n");
                    }
                    else
                    {
                        sb.Append($"\t// {newline.TrimStart('/', ' ')}\n");
                    }

                    continue;
                }

                if (newline.StartsWith("message"))
                {
                    isMsgStart = true;

                    string parentClass = "";
                    msgName = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries)[1];
                    string[] ss = newline.Split(["//"], StringSplitOptions.RemoveEmptyEntries);
                    if (ss.Length == 2)
                    {
                        parentClass = ss[1].Trim();
                    }

                    msgOpcode.Add(new OpcodeInfo() { Name = msgName, Opcode = ++startOpcode });

                    sb.Append($"\t[MemoryPackable]\n");
                    sb.Append($"\t[Message({protoName}.{msgName})]\n");
                    if (!string.IsNullOrEmpty(responseType))
                    {
                        sb.Append($"\t[ResponseType(nameof({responseType}))]\n");
                    }

                    sb.Append($"\tpublic partial class {msgName} : MessageObject");

                    if (parentClass is "IActorMessage" or "IActorRequest" or "IActorResponse")
                    {
                        sb.Append($", {parentClass}\n");
                    }
                    else if (parentClass != "")
                    {
                        sb.Append($", {parentClass}\n");
                    }
                    else
                    {
                        sb.Append('\n');
                    }

                    continue;
                }

                if (isMsgStart)
                {
                    if (newline.StartsWith('{'))
                    {
                        sbDispose.Clear();
                        sb.Append("\t{\n");
                        sb.Append($"\t\tpublic static {msgName} Create(bool isFromPool = false)\n\t\t{{\n\t\t\treturn ObjectPool.Instance.Fetch(typeof({msgName}), isFromPool) as {msgName};\n\t\t}}\n\n");
                        continue;
                    }

                    if (newline.StartsWith('}'))
                    {
                        isMsgStart = false;
                        responseType = "";

                        // 加了no dispose则自己去定义dispose函数，不要自动生成
                        if (!newline.Contains("// no dispose"))
                        {
                            sb.Append($"\t\tpublic override void Dispose()\n\t\t{{\n\t\t\tif (!this.IsFromPool)\n\t\t\t{{\n\t\t\t\treturn;\n\t\t\t}}\n\n\t\t\t{sbDispose.ToString().TrimEnd('\t')}\n\t\t\tObjectPool.Instance.Recycle(this);\n\t\t}}\n");
                        }

                        sb.Append("\t}\n\n");
                        continue;
                    }

                    if (newline.StartsWith("//"))
                    {
                        sb.Append("\t\t/// <summary>\n");
                        sb.Append($"\t\t/// {newline.TrimStart('/', ' ')}\n");
                        sb.Append("\t\t/// </summary>\n");
                        continue;
                    }

                    string memberStr;
                    if (newline.Contains("//"))
                    {
                        string[] lineSplit = newline.Split("//");
                        memberStr = lineSplit[0].Trim();
                        sb.Append("\t\t/// <summary>\n");
                        sb.Append($"\t\t/// {lineSplit[1].Trim()}\n");
                        sb.Append("\t\t/// </summary>\n");
                    }
                    else
                    {
                        memberStr = newline;
                    }

                    if (memberStr.StartsWith("map<"))
                    {
                        Map(sb, memberStr, sbDispose);
                    }
                    else if (memberStr.StartsWith("repeated"))
                    {
                        Repeated(sb, memberStr, sbDispose);
                    }
                    else
                    {
                        Members(sb, memberStr, sbDispose);
                    }
                }
            }

            sb.Append("\tpublic static class " + protoName + "\n\t{\n");
            foreach (OpcodeInfo info in msgOpcode)
            {
                sb.Append($"\t\tpublic const ushort {info.Name} = {info.Opcode};\n");
            }

            sb.Append("\t}\n");

            sb.Append('}');

            sb.Replace("\t", "    ");
            string result = sb.ToString().ReplaceLineEndings("\r\n");

            if (cs.Contains('C'))
            {
                GenerateCS(result, clientMessagePath, proto);
                GenerateCS(result, serverMessagePath, proto);
                GenerateCS(result, clientServerMessagePath, proto);
            }

            if (cs.Contains('S'))
            {
                GenerateCS(result, serverMessagePath, proto);
                GenerateCS(result, clientServerMessagePath, proto);
            }
        }

        private static void ProtoFile2Entity(string fileName)
        {
            string proto = Path.Combine(protoDir, $"{fileName}.proto");
            string s = File.ReadAllText(proto);

            Dictionary<string, string> name_type = new();

            bool isMsgStart = false;
            string msgName = "";
            Regex responseTypeRegex = ResponseTypeRegex();

            foreach (string line in s.Split('\n'))
            {
                string newline = line.Trim();
                if (string.IsNullOrEmpty(newline))
                {
                    continue;
                }

                if (responseTypeRegex.IsMatch(newline))
                {
                    continue;
                }

                if (!isMsgStart && newline.StartsWith("//"))
                {
                    continue;
                }

                if (newline.StartsWith("message"))
                {
                    string parentClass = "";
                    msgName = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries)[1];
                    string[] ss = newline.Split(["//"], StringSplitOptions.RemoveEmptyEntries);
                    if (ss.Length == 2)
                    {
                        parentClass = ss[1].Trim();
                    }

                    if (parentClass == "" && msgName.EndsWith("Proto"))
                    {
                        msgName = msgName.Substring(0, msgName.Length - "Proto".Length);
                        isMsgStart = true;
                    }

                    continue;
                }

                if (isMsgStart)
                {
                    if (newline.StartsWith('{'))
                    {
                        continue;
                    }

                    if (newline.StartsWith('}'))
                    {
                        // 开始生成代码
                        StringBuilder sb = new();
                        sb.AppendLine("using MemoryPack;");
                        sb.AppendLine("using System.Collections.Generic;");
                        sb.AppendLine("");
                        sb.AppendLine($"namespace ET");
                        sb.AppendLine("{");
                        sb.AppendLine($"\t[ChildOf]");
                        sb.AppendLine($"\tpublic class {msgName} : Entity, IAwake, ISerializeToEntity");
                        sb.AppendLine("\t{");
                        foreach (KeyValuePair<string, string> keyValuePair in name_type)
                        {
                            if (keyValuePair.Key == "Id")
                            {
                                continue;
                            }

                            if (keyValuePair.Value.Contains("List") || keyValuePair.Value.Contains("Map"))
                            {
                                sb.AppendLine($"\t\tpublic {keyValuePair.Value} {keyValuePair.Key} {{ get; set; }} = new();");
                            }
                            else
                            {
                                sb.AppendLine($"\t\tpublic {keyValuePair.Value} {keyValuePair.Key} {{ get; set; }}");
                            }
                        }

                        sb.AppendLine("\t}");

                        sb.AppendLine("");
                        // System
                        sb.AppendLine($"\t[EntitySystemOf(typeof({msgName}))]");
                        sb.AppendLine($"\t[FriendOf(typeof({msgName}))]");
                        sb.AppendLine($"\tpublic static partial class {msgName}System");
                        sb.AppendLine("\t{");
                        sb.AppendLine("\t\t[EntitySystem]");
                        sb.AppendLine($"\t\tprivate static void Awake(this {msgName} self)");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine("");
                        sb.AppendLine($"\t\tpublic static void FromMessage(this {msgName} self, {msgName}Proto proto)");
                        sb.AppendLine("\t\t{");
                        foreach (KeyValuePair<string, string> keyValuePair in name_type)
                        {
                            if (keyValuePair.Key == "Id")
                            {
                                continue;
                            }

                            sb.AppendLine($"\t\t\tself.{keyValuePair.Key} = proto.{keyValuePair.Key};");
                        }

                        sb.AppendLine("\t\t}");
                        sb.AppendLine("");
                        sb.AppendLine($"\t\tpublic static {msgName}Proto ToMessage(this {msgName} self)");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\t\t\t{msgName}Proto proto = {msgName}Proto.Create();");
                        foreach (KeyValuePair<string, string> keyValuePair in name_type)
                        {
                            if (keyValuePair.Key == "Id")
                            {
                                sb.AppendLine($"\t\t\tproto.{keyValuePair.Key} = (int)self.{keyValuePair.Key};");
                                continue;
                            }
                            sb.AppendLine($"\t\t\tproto.{keyValuePair.Key} = self.{keyValuePair.Key};");
                        }

                        sb.AppendLine("\t\t\treturn proto;");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine("\t}");
                        sb.AppendLine("}");


                        GenerateCS(sb.ToString(), serverMessageEntityPath, msgName);
                           
                        
                        isMsgStart = false;
                        msgName = "";
                        name_type = new();

                        continue;
                    }

                    if (newline.StartsWith("//"))
                    {
                        continue;
                    }

                    string memberStr;
                    if (newline.Contains("//"))
                    {
                        string[] lineSplit = newline.Split("//");
                        memberStr = lineSplit[0].Trim();
                    }
                    else
                    {
                        memberStr = newline;
                    }

                    if (memberStr.StartsWith("map<"))
                    {
                        int start = newline.IndexOf('<') + 1;
                        int end = newline.IndexOf('>');
                        string types = newline.Substring(start, end - start);
                        string[] ss = types.Split(',');
                        string keyType = ConvertType(ss[0].Trim());
                        string valueType = ConvertType(ss[1].Trim());
                        string tail = newline[(end + 1)..];
                        ss = tail.Trim().Replace(";", "").Split(' ');
                        string v = ss[0];

                        name_type.Add(v, $"Dictionary<{keyType}, {valueType}>");
                    }
                    else if (memberStr.StartsWith("repeated"))
                    {
                        int index = newline.IndexOf(';');
                        newline = newline.Remove(index);
                        string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                        string type = ss[1];
                        type = ConvertType(type);
                        string name = ss[2];

                        name_type.Add(name, $"List<{type}>");
                    }
                    else
                    {
                        int index = newline.IndexOf(';');
                        newline = newline.Remove(index);
                        string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                        string type = ss[0];
                        string name = ss[1];
                        string typeCs = ConvertType(type);

                        name_type.Add(name, typeCs);
                    }
                }
            }
        }
        
        private static void GenerateCS(string result, string path, string proto)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string csPath = Path.Combine(path, Path.GetFileNameWithoutExtension(proto) + ".cs");
            using FileStream txt = new(csPath, FileMode.Create, FileAccess.ReadWrite);
            using StreamWriter sw = new(txt);
            sw.Write(result);
        }

        private static void Map(StringBuilder sb, string newline, StringBuilder sbDispose)
        {
            int start = newline.IndexOf('<') + 1;
            int end = newline.IndexOf('>');
            string types = newline.Substring(start, end - start);
            string[] ss = types.Split(',');
            string keyType = ConvertType(ss[0].Trim());
            string valueType = ConvertType(ss[1].Trim());
            string tail = newline[(end + 1)..];
            ss = tail.Trim().Replace(";", "").Split(' ');
            string v = ss[0];
            int n = int.Parse(ss[2]);

            sb.Append("\t\t[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]\n");
            sb.Append($"\t\t[MemoryPackOrder({n - 1})]\n");
            sb.Append($"\t\tpublic Dictionary<{keyType}, {valueType}> {v} {{ get; set; }} = new();\n");

            sbDispose.Append($"this.{v}.Clear();\n\t\t\t");
        }

        private static void Repeated(StringBuilder sb, string newline, StringBuilder sbDispose)
        {
            try
            {
                int index = newline.IndexOf(';');
                newline = newline.Remove(index);
                string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                string type = ss[1];
                type = ConvertType(type);
                string name = ss[2];
                int n = int.Parse(ss[4]);

                sb.Append($"\t\t[MemoryPackOrder({n - 1})]\n");
                sb.Append($"\t\tpublic List<{type}> {name} {{ get; set; }} = new();\n\n");

                sbDispose.Append($"this.{name}.Clear();\n\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{newline}\n {e}");
            }
        }

        private static string ConvertType(string type)
        {
            return type switch
            {
                "int16" => "short",
                "int32" => "int",
                "bytes" => "byte[]",
                "uint32" => "uint",
                "long" => "long",
                "int64" => "long",
                "uint64" => "ulong",
                "uint16" => "ushort",
                _ => type
            };
        }

        private static void Members(StringBuilder sb, string newline, StringBuilder sbDispose)
        {
            try
            {
                int index = newline.IndexOf(';');
                newline = newline.Remove(index);
                string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                string type = ss[0];
                string name = ss[1];
                int n = int.Parse(ss[3]);
                string typeCs = ConvertType(type);

                sb.Append($"\t\t[MemoryPackOrder({n - 1})]\n");
                sb.Append($"\t\tpublic {typeCs} {name} {{ get; set; }}\n\n");

                switch (typeCs)
                {
                    case "bytes":
                    {
                        break;
                    }
                    default:
                        sbDispose.Append($"this.{name} = default;\n\t\t\t");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{newline}\n {e}");
            }
        }

        /// <summary>
        /// 删除meta以外的所有文件
        /// </summary>
        static void RemoveAllFilesExceptMeta(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            DirectoryInfo targetDir = new(directory);
            FileInfo[] fileInfos = targetDir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo info in fileInfos)
            {
                if (!info.Name.EndsWith(".meta"))
                {
                    File.Delete(info.FullName);
                }
            }
        }

        /// <summary>
        /// 删除多余的meta文件
        /// </summary>
        static void RemoveUnusedMetaFiles(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            DirectoryInfo targetDir = new(directory);
            FileInfo[] fileInfos = targetDir.GetFiles("*.meta", SearchOption.AllDirectories);
            foreach (FileInfo info in fileInfos)
            {
                string pathWithoutMeta = info.FullName.Remove(info.FullName.LastIndexOf(".meta", StringComparison.Ordinal));
                if (!File.Exists(pathWithoutMeta) && !Directory.Exists(pathWithoutMeta))
                {
                    File.Delete(info.FullName);
                }
            }
        }

        [GeneratedRegex(@"//\s*ResponseType")]
        private static partial Regex ResponseTypeRegex();
    }
}