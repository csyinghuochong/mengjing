
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

		// new KeyValuePairInt() { KeyId = 10000, Value = 77001801 }, 
		public static void OnInitData(this Scroll_Item_PetEchoSkillItem self, KeyValuePairInt data)
		{
			int skillid = (int)data.Value;

			SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            SkillSetComponentC skillSetComponentC = self.Root().GetComponent<SkillSetComponentC>();	
            bool active = skillSetComponentC.GetPetEchoSkillList().Contains(skillid);
            CommonViewHelper.SetImageGray(self.Root(), self.E_SkillIconImage.gameObject, !active);
            
			self.E_SkillIconImage.sprite = sp;

			self.E_Text_NameText.text = skillConfig.SkillName;
			
			self.E_Text_NameText.text = data.KeyId.ToString();
		}
	}
	
}
