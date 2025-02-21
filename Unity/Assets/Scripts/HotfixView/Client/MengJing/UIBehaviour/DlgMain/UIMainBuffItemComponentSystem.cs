using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIMainBuffItemComponent))]
    [EntitySystemOf(typeof(UIMainBuffItemComponent))]
    public static partial class UIMainBuffItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainBuffItemComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            self.TextBuffName = rc.Get<GameObject>("TextBuffName");
            self.Img_BuffCD = rc.Get<GameObject>("Img_BuffCD");
            self.ImgBufflIcon = rc.Get<GameObject>("ImgBufflIcon");
            self.TextLeftTime = rc.Get<GameObject>("TextLeftTime");
            self.TextNumber = rc.Get<GameObject>("TextNumber").GetComponent<Text>();
            self.TextNumber.gameObject.SetActive(true);

            self.ImgBufflIcon.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.ImgBufflIcon.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this UIMainBuffItemComponent self)
        {
            if (self.GameObject != null)
            {
                UnityEngine.Object.Destroy(self.GameObject);
            }
        }

        public static async ETTask BeginDrag(this UIMainBuffItemComponent self, PointerEventData pdata)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_BuffTips);

            if (self.IsDisposed)
            {
                return;
            }

            if (self.BuffID == 0)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("UIMainBuffItemComponent {0}", self.BuffID == 0));
                }

                return;
            }

            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgBuffTips>().OnUpdateData(self.BuffID, new Vector3(localPoint.x, localPoint.y, 0f),
                self.SpellCast, self.aBAtlasTypes, self.BuffIcon);
        }

        public static void BeforeRemove(this UIMainBuffItemComponent self)
        {
            DlgBuffTips dlgBuffTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgBuffTips>();
            if (dlgBuffTips != null && self.BuffID == dlgBuffTips.BuffId)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BuffTips);
            }
        }

        public static void EndDrag(this UIMainBuffItemComponent self, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BuffTips);
        }

        public static bool OnUpdate(this UIMainBuffItemComponent self)
        {
            long leftTime = self.EndTime - TimeHelper.ClientNow();

            self.Img_BuffCD.GetComponent<Image>().fillAmount = (self.BuffTime - leftTime) * 1f / self.BuffTime;
            leftTime = leftTime / 1000;
            return leftTime > 0;
        }

        public static void OnResetBuff(this UIMainBuffItemComponent self, BuffC aBuffHandler)
        {
            self.EndTime = aBuffHandler.BuffEndTime;
        }

        public static void UpdateBuffNumber(this UIMainBuffItemComponent self, BuffC buffHandler, int number)
        {
            int BuffNumber = self.BuffManagerComponent.GetBuffNumber(buffHandler.BuffData.BuffId) + number;
            if (BuffNumber == 0)
            {
                self.BuffID = 0;
                self.EndTime = 0;
            }
            else if (number >= 0)
            {
                self.EndTime = buffHandler.BuffEndTime;
            }

            self.TextNumber.text = BuffNumber > 1 ? BuffNumber.ToString() : string.Empty;
        }

        public static void OnAddBuff(this UIMainBuffItemComponent self, BuffC buffHandler)
        {
            long endTime = buffHandler.BuffData.BuffEndTime;
            SkillBuffConfig skillBuffConfig = buffHandler.mSkillBuffConf;
            self.BuffTime = skillBuffConfig.BuffTime;
            self.TextBuffName.GetComponent<Text>().text = skillBuffConfig.BuffName;
            self.SpellCast = buffHandler.BuffData.Spellcaster;
            self.EndTime = endTime;
            self.BuffID = skillBuffConfig.Id;
            self.UnitId = buffHandler.TheUnitBelongto.Id;
            self.TextNumber.text = string.Empty;
            self.BuffManagerComponent = buffHandler.TheUnitBelongto.GetComponent<BuffManagerComponentC>();
            string bufficon = skillBuffConfig.BuffIcon;
            //Buff表BuffIcon为0时,显示图标显示为对应的技能图标,如果没找到对应资源,
            //释放者是怪物,那么就显示怪物的头像Icon,最后还是没找到显示默认图标b001
            string aBAtlasTypes = ABAtlasTypes.RoleSkillIcon;

            if (!CommonHelp.IfNull(bufficon) && skillBuffConfig.BuffIconType.Equals("ItemIcon"))
            {
                aBAtlasTypes = ABAtlasTypes.ItemIcon;
            }

            if (CommonHelp.IfNull(bufficon) && buffHandler.BuffData.SkillId != 0)
            {
                bufficon = SkillConfigCategory.Instance.Get(buffHandler.BuffData.SkillId).SkillIcon;
            }

            if (CommonHelp.IfNull(bufficon) && buffHandler.BuffData.UnitType == UnitType.Monster)
            {
                aBAtlasTypes = ABAtlasTypes.MonsterIcon;
                bufficon = MonsterConfigCategory.Instance.Get(buffHandler.BuffData.UnitConfigId).MonsterHeadIcon;
            }

            if (CommonHelp.IfNull(bufficon))
            {
                bufficon = "b001";
            }

            self.aBAtlasTypes = aBAtlasTypes;
            self.BuffIcon = bufficon;
            string path = ABPathHelper.GetAtlasPath_2(aBAtlasTypes, bufficon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.ImgBufflIcon.GetComponent<Image>().sprite = sp;
        }
    }
}