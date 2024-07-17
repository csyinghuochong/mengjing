using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof (Scroll_Item_MainChatItem))]
	[EntitySystemOf(typeof (Scroll_Item_MainChatItem))]
	public static partial class Scroll_Item_MainChatItemSystem
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MainChatItem self)
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MainChatItem self)
		{
			self.DestroyWidget();
		}

		public static void Refresh(this Scroll_Item_MainChatItem self, ChatInfo chatInfo)
		{
			for (int i = 0; i < ChannelEnum.Number; i++)
			{
				self.TitleList[i] = self.uiTransform.Find(i.ToString()).gameObject;
				self.TitleList[i].transform.localPosition = new Vector3(- 300f, -15.9f, 0);
			}
			
			self.ChatInfo = chatInfo;
			string showValue = string.Empty;
			if (!string.IsNullOrEmpty(chatInfo.ChatMsg))
			{
				int startindex = chatInfo.ChatMsg.IndexOf("<link=");
				int endindex = chatInfo.ChatMsg.IndexOf("></link>");
				if (startindex != -1)
				{
					showValue = chatInfo.ChatMsg.Substring(0, startindex);
				}
				else
				{
					showValue = chatInfo.ChatMsg;
				}

				if (chatInfo.ChannelId == (int)ChannelEnum.System)
				{
					self.E_ChatTextText.text = showValue;
				}
				else
				{
					self.E_ChatTextText.text = StringBuilderHelper.GetChatText(chatInfo.PlayerName, showValue);
				}

				float preferredHeight = self.E_ChatTextText.preferredHeight;
				if (preferredHeight > 40f)
				{
					self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, preferredHeight + 50);
				}
				else
				{
					self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 40);
				}

				if (chatInfo.ChannelId >= 0 && chatInfo.ChannelId < self.TitleList.Length)
				{
					for (int i = 0; i < self.TitleList.Length; i++)
					{
						self.TitleList[i].transform.localPosition =
								i == chatInfo.ChannelId? new Vector3(-157.6f, -15.9f, 0) : new Vector3(-300f, -15.9f, 0);
					}
				}
			}
		}
		
		public static  void UpdateHeight(this Scroll_Item_MainChatItem self)
		{
			if (!self.UpdateHeight)
			{
				return;
			}
			self.UpdateHeight = false;
			float preferredHeight = self.E_ChatTextText.preferredHeight;
			if (preferredHeight > 40f)
			{
				self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, preferredHeight + 50);
				self.uiTransform.gameObject.SetActive(false);
				self.uiTransform.gameObject.SetActive(true);
			}
			else
			{
				self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 40);
			}
		}

	}
}
