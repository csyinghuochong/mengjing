using System;
using System.Collections.Generic;
using System.IO;
using DotRecast.Detour;
using DotRecast.Detour.Io;

namespace ET
{
    public class NavmeshComponent: Singleton<NavmeshComponent>, ISingletonAwake
    {
        public struct RecastFileLoader
        {
            public string Name { get; set; }
        }

        private readonly Dictionary<string, byte[]> navmeshs = new();
        private readonly Dictionary<string, DtNavMesh> parsedMeshes = new();
        
        public void Awake()
        {
        }

        public DtNavMesh GetMesh(string name)
        {
            lock (this)
            {
                if (!this.parsedMeshes.TryGetValue(name, out DtNavMesh mesh))
                {
                    using MemoryStream stream = new(this.Get(name), writable: false);
                    using BinaryReader reader = new(stream);
                    mesh = new DtMeshSetReader().Read32Bit(reader, 6)
                            ?? throw new InvalidDataException($"nav load fail: {name}");
                    this.parsedMeshes.Add(name, mesh);
                }
                return mesh;
            }
        }
        
        public byte[] Get(string name)
        {
            lock (this)
            {
                if (this.navmeshs.TryGetValue(name, out byte[] bytes))
                {
                    return bytes;
                }

                byte[] buffer =
                        EventSystem.Instance.Invoke<NavmeshComponent.RecastFileLoader, byte[]>(
                            new NavmeshComponent.RecastFileLoader() { Name = name });
                if (buffer.Length == 0)
                {
                    throw new Exception($"no nav data: {name}");
                }

                this.navmeshs[name] = buffer;
                return buffer;
            }
        }
    }
}
