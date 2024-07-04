using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgJiaYuanUpLv))]
    public static class DlgJiaYuanUpLvSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanUpLv self)
        {
            self.View.E_Btn_UpLvButton.AddListenerAsync(self.OnBtn_UpLv);
            self.View.E_Btn_ExchangeExpButton.AddListenerAsync(self.OnBtn_ExchangeExp);
            self.View.E_Btn_ExchangeZiJinButton.AddListenerAsync(self.OnBtn_ExchangeZiJin);
        }

        public static void ShowWindow(this DlgJiaYuanUpLv self, Entity contextData = null)
        {
            //放止图标丢失
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, "444");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_ImgGengDiIconImage.sprite = sp;

            self.OnUpdateUI();
        }

        public static async ETTask OnBtn_UpLv(this DlgJiaYuanUpLv self)
        {
            await JiaYuanNetHelper.JiaYuanUpLvRequest(self.Root());

            self.OnUpdateUI();
        }

        /// <summary>
        /// 兑换经验
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask OnBtn_ExchangeExp(this DlgJiaYuanUpLv self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            if (numericComponent.GetAsInt(NumericType.JiaYuanExchangeExp) >= 10)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("兑换次数不足！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv);
            if (userInfo.JiaYuanFund < jiaYuanConfig.ExchangeExpCostZiJin)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("家园资金不足！");
                return;
            }

            await JiaYuanNetHelper.JiaYuanExchangeRequest(self.Root(), 2);

            self.OnUpdateUI();
        }

        public static async ETTask OnBtn_ExchangeZiJin(this DlgJiaYuanUpLv self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.JiaYuanExchangeZiJin) >= 10)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("兑换次数不足！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv);
            if (userInfo.Gold < jiaYuanConfig.ExchangeZiJinCostGold)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("金币不足！");
                return;
            }

            await JiaYuanNetHelper.JiaYuanExchangeRequest(self.Root(), 1);

            self.OnUpdateUI();
        }

        //初始化
        public static void OnUpdateUI(this DlgJiaYuanUpLv self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            UserInfoComponentC userInfoCom = self.Root().GetComponent<UserInfoComponentC>();
            int jiayuanid = userInfoCom.UserInfo.JiaYuanLv;

            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanid);
            self.View.E_JiaYuanNameText.text = userInfoCom.UserInfo.Name + "的家园";
            self.View.E_Text_ZiZhiValueText.text = userInfoCom.UserInfo.JiaYuanExp + "/" + jiayuanCof.Exp;
            self.View.E_ImageExpValueImage.fillAmount = (float)userInfoCom.UserInfo.JiaYuanExp / (float)jiayuanCof.Exp;

            self.View.E_Lab_GengDiText.text = jiayuanCof.FarmNumMax.ToString();
            self.View.E_Lab_RenKouText.text = jiayuanCof.PeopleNumMax.ToString();

            self.View.E_JiaYuanLvText.text = "等级:" + jiayuanCof.Lv;

            //提示描述
            int hour = (int)((float)(jiayuanCof.Exp - (int)userInfoCom.UserInfo.JiaYuanExp) / jiayuanCof.JiaYuanAddExp) + 1;
            if (hour < 0)
            {
                hour = 0;
            }

            self.View.E_JiaYuanUpHintText.text = "提示:经验产出" + jiayuanCof.JiaYuanAddExp + "/小时,预计" + hour + "小时后可升级家园";

            self.View.E_ZiJinDuiHuanTextText.text = $"兑换次数:10/{numericComponent.GetAsInt(NumericType.JiaYuanExchangeZiJin)}";
            self.View.E_ExpDuiHuanTextText.text = $"兑换次数:10/{numericComponent.GetAsInt(NumericType.JiaYuanExchangeExp)}";

            string[] upgets = jiayuanCof.JiaYuanDes.Split(';');
            for (int i = 0; i < self.View.EG_UpdateGetRectTransform.childCount; i++)
            {
                Transform item = self.View.EG_UpdateGetRectTransform.GetChild(i);
                if (i >= upgets.Length)
                {
                    item.gameObject.SetActive(false);
                    continue;
                }

                item.gameObject.SetActive(true);
                item.Find("Text").GetComponent<Text>().text = upgets[i];
            }

            //更新兑换显示
            self.View.E_ExpDuiHuanShowText.text = jiayuanCof.ExchangeExpCostZiJin.ToString();
            self.View.E_ZiJinDuiHuanShowText.text = jiayuanCof.ExchangeZiJinCostGold.ToString();

            self.View.E_ExpDuiHuanAddShowText.text = jiayuanCof.JiaYuanAddExp.ToString();
            self.View.E_ZiJinDuiHuanAddShowText.text = jiayuanCof.ExchangeZiJin.ToString();
        }
    }
}