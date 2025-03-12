
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_DamageValueItem))]
	public static partial class Scroll_Item_DamageValueItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_DamageValueItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_DamageValueItem self )
		{
			self.DestroyWidget();
		}
		

		public static void OnInitData(this Scroll_Item_DamageValueItem self, DamageValueInfo damageValueInfo)
		{
			using (zstring.Block())
			{
				string text_0 = TimeHelper.FormatTimestampToTime(damageValueInfo.Time);
				string text_1 = string.Empty;	
				switch (damageValueInfo.UnitType)
				{
					case UnitType.Monster:
						text_1 =  MonsterConfigCategory.Instance.Get(damageValueInfo.ConfigId).MonsterName;
						break;  
					default:
						text_1 = damageValueInfo.UnitName;
						break;
				}

				if (string.IsNullOrEmpty(text_1))
				{
					text_1 = string.Empty;	
				}

				string text_2 = zstring.Format("技能:{0}", SkillConfigCategory.Instance.Get(damageValueInfo.SkillId).SkillName);
				string text_3 = zstring.Format("伤害:{0}",  damageValueInfo.DamageValue);

				self.E_Text_NameText.text = zstring.Format("{0} {1} {2} {3}", text_0,  text_1, text_2, text_3);
			}
			
		}
	}
}
