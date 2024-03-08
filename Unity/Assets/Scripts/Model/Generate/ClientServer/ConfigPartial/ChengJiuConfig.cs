

using System.Collections.Generic;
using static UnityEditor.Progress;

namespace ET
{
    //�ɾ���������
    public class ChengJiuTypeData
    {
        //ÿ���½ڶ�Ӧ�ĳɾ�����
        public Dictionary<int, List<int>> ChengJiuChapterTask = new Dictionary<int, List<int>>();
    }

    public partial class ChengJiuConfigCategory
    {
        public Dictionary<int, List<int>> ChengJiuTargetData = new Dictionary<int, List<int>>();


        public List<ChengJiuTypeData> ChengJiuTypeData = new List<ChengJiuTypeData>();

        public List<string> ChengJiuTypeText = new List<string>() { "", "�ؿ��ɾ�", "̽���ɾ�", "�ռ��ɾ�" };

        public Dictionary<int, string> ChapterIndexText = new Dictionary<int, string>()
        {
            {0,  "ͨ��" },
            {1,  "��һ��" },
            {2,  "�ڶ���" },
            {3,  "������" },
            {4,  "������" },
            {5,  "������" },
            {10,  "��Ӹ���" },
            {11,  "��ɫ����" },
            {12,  "���۳ɾ�" },
            {21,  "����ɾ�" },
        };


        public override void EndInit()
        {
            for (int i = 0; i < (int)ChengJiuTypeEnum.Number; i++)
            {
                ChengJiuTypeData.Add(new ChengJiuTypeData());
            }

            foreach (ChengJiuConfig activityConfig in this.GetAll().Values)
            {
                ChengJiuConfig chengJiuConfig = activityConfig;
                int chengjiuType = chengJiuConfig.ChengjiuType;
                int chapterId = chengJiuConfig.ChapterId;
                int targetType = chengJiuConfig.TargetType;

                ChengJiuTypeData chengJiuTypeDatas = ChengJiuTypeData[chengjiuType];
                if (!chengJiuTypeDatas.ChengJiuChapterTask.ContainsKey(chapterId))
                {
                    chengJiuTypeDatas.ChengJiuChapterTask.Add(chapterId, new List<int>());
                }
                chengJiuTypeDatas.ChengJiuChapterTask[chapterId].Add(activityConfig.Id);

                if (!ChengJiuTargetData.ContainsKey(targetType))
                {
                    ChengJiuTargetData.Add(targetType, new List<int>());
                }
                ChengJiuTargetData[targetType].Add(activityConfig.Id);
            }
        }


    }
}