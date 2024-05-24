using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class MailComponentC: Entity, IAwake
    {
        public List<MailInfo> MailInfoList { get; set; } = new();

        public MailInfo SelectMail { get; set; }
    }
}