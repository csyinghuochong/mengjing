using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MainTeamItem))]
    [EntitySystemOf(typeof(Scroll_Item_MainTeamItem))]
    public static partial class Scroll_Item_MainTeamItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MainTeamItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MainTeamItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateDamage(this Scroll_Item_MainTeamItem self, TeamPlayerInfo teamPlayerInfo)
        {
            long value = teamPlayerInfo.Damage;
            string str = value.ToString();
            using (zstring.Block())
            {
                if (value >= 10000)
                {
                    str = zstring.Format("{0}万", ((float)value / 10000.0f).ToString("F2"));
                }

                self.E_DamageValueText.text = zstring.Format("输出:{0}", str);
            }
        }

        public static void OnReset(this Scroll_Item_MainTeamItem self)
        {
            self.E_DamageValueText.text = "";
        }

        public static void OnUpdateHP(this Scroll_Item_MainTeamItem self, Unit unit)
        {
            if (unit.Id != self.UnitId)
            {
                return;
            }

            float curhp = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Hp);
            float blood = curhp / unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_MaxHp);
            blood = Mathf.Clamp01(blood);
            self.E_ImageBooldValueImage.transform.localScale = new Vector3(blood, 1, 1);
        }

        public static void OnUpdateItem(this Scroll_Item_MainTeamItem self, TeamPlayerInfo teamPlayerInfo)
        {
            self.E_DamageValueText.text = "";

            if (self.UnitId == 0)
            {
                self.uiTransform.gameObject.SetActive(true);
            }

            self.TeamPlayerInfo = teamPlayerInfo;
            self.UnitId = teamPlayerInfo.UserID;
            self.E_PlayerNameText.text = teamPlayerInfo.PlayerName;
            using (zstring.Block())
            {
                self.E_PlayerLvText.text = zstring.Format("{0}级", teamPlayerInfo.PlayerLv);
            }

            self.OnUpdateDamage(teamPlayerInfo);
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_ImageHeadImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon,
                        teamPlayerInfo.Occ.ToString()));
        }
    }
}