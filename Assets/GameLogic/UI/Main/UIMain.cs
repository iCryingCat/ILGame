using System;
using GFramework;
using GFramework.UI;

using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.UI
{
    public class UIMain : BaseView<MainControl>
    {
        GLogger logger = new GLogger("UIMain");

        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.goMatching.gameObject.SetActive(false);
        }

        protected override void BindEvents()
        {
            base.BindEvents();
            this.btnPlay.onClick.AddListener(this.OnClickBtnPlay);
        }

        private void OnClickBtnPlay()
        {
            this.goMatching.gameObject.SetActive(true);
            this.BindingContext.OnMatch();
        }

        public override void BindProp()
        {
            base.BindProp();
            this.propertyBinder.Add<UserData>("uiPlayerInfo", OnUpdatePlayerInfo);
            this.propertyBinder.Add<int>("playerNum", OnUpdatePlayerNum);
        }

        private void OnUpdatePlayerNum(int oldValue, int newValue)
        {
            this.txtPlayerNum.text = newValue.ToString();
        }

        private void OnUpdatePlayerInfo(UserData oldValue, UserData newValue)
        {
            this.uiPlayerInfo.BindingContext.userName.Value = newValue.userName;
        }

        // ++
        public override string BindPath()
        {
            return "Main/UIMain";
        }
        private UIPlayerInfo uiPlayerInfo;
        private RectTransform goMatching;
        private Button btnPlay;
        private Text txtPlayerNum;
        protected override void BindVars()
        {
            this.uiPlayerInfo = this.GetVar<UIPlayerInfo, PlayerInfoControl>(0);
            this.goMatching = this.GetVar<RectTransform>(1);
            this.btnPlay = this.GetVar<Button>(2);
            this.txtPlayerNum = this.GetVar<Text>(3);
        }
        // --
    }
}
