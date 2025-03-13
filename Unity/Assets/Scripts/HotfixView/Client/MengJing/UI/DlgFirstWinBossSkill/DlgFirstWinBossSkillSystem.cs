using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgFirstWinBossSkill))]
	public static  class DlgFirstWinBossSkillSystem
	{

		public static void RegisterUIEvent(this DlgFirstWinBossSkill self)
		{
		  
			self.View.E_ImageButtonButton.AddListener( self.OnImageButtonButton );
		}

		public static void ShowWindow(this DlgFirstWinBossSkill self, Entity contextData = null)
		{
		}

		private static void OnImageButtonButton(this DlgFirstWinBossSkill self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_FirstWinBossSkill);
		}

        public static void UpdateBossInfo(this DlgFirstWinBossSkill self, int firstwinId)
        {
            if (firstwinId == 0)
            {
                return;
            }

            int bossId = FirstWinConfigCategory.Instance.Get(firstwinId).BossID;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            self.View.E_BossNameTextText.text = monsterConfig.MonsterName;
           
            self.View.E_SkillDescriptionItemTextText.gameObject.SetActive(false);
            int[] skillIds = monsterConfig.SkillID;
            for (int i = 0; i < skillIds.Length; i++)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillIds[i]);
                using (zstring.Block())
                {
                    string str = zstring.Format("{0}:{1}", skillConfig.SkillName, skillConfig.SkillDescribe);
                   
                    GameObject obj = UnityEngine.Object.Instantiate(self.View.E_SkillDescriptionItemTextText.gameObject);
                    obj.SetActive(true);
                    CommonViewHelper.SetParent(obj, self.View.EG_SkillDescriptionListNodeRectTransform.gameObject);

                    obj.GetComponent<Text>().text = str;
                    //float height = (str.Length / 30 + 1) * 40; // 16个字一行
                    float height = obj.GetComponent<Text>().preferredHeight;
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, height);
                }
            }
            
            string skilldesc = "";
            int[] skilllist = monsterConfig.SkillID;
            for (int i = 0; i < skilllist.Length; i++)
            {
                if (skilllist[i] == 0)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skilllist[i]);
                using (zstring.Block())
                {
                    skilldesc += zstring.Format("{1} {2}\n", skillConfig.SkillName, skillConfig.SkillDescribe);
                }
            }

            //self.E_Text_SkillJieShaoText.text = skilldesc;
        }
    }
}
