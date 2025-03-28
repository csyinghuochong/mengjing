
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetEchoSkillItem))]
	public static partial class Scroll_Item_PetEchoSkillItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetEchoSkillItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetEchoSkillItem self )
		{
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_PetEchoSkillItem self)
		{
			int skillid  = self.SkillId;	
			SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

			SkillSetComponentC skillSetComponentC = self.Root().GetComponent<SkillSetComponentC>();	
			bool active = skillSetComponentC.GetPetEchoSkillList().Contains(skillid);
			
            self.ES_CommonSkillItem_0.OnUpdateUI(skillid);
            self.ES_CommonSkillItem_0.SetImageGray(!active);
			self.E_Text_NameText.text = skillConfig.SkillName;
		}

		// new KeyValuePairInt() { KeyId = 10000, Value = 77001801 }, 
		public static void OnInitData(this Scroll_Item_PetEchoSkillItem self, KeyValuePairInt data, int index)
		{
			int skillid = (int)data.Value;
			self.SkillId = skillid;
			self.E_Text_ComabtText.text = data.KeyId.ToString();
			self.E_JianTouImage.gameObject.SetActive(index % 4 != 3);
			self.OnUpdateUI();
		}
	}
	
}
