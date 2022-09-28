using DG.Tweening;
using GFramework.UI;
using UnityEngine;
using UnityEngine.UI;
namespace GameLogic.UI
{
    public class UILogo : BaseView<LogoControl>
    {
        protected override void BindEvents()
        {
            base.BindEvents();
            this.anim.onComplete.AddListener(this.BindingContext.OnLogoPlayOver);
        }

        // ++
        public override string BindingPath()
        {
            return "Logo/UILogo.prefab";
        }
        private Image bg;
        private Text txtTitle;
        private DOTweenAnimation anim;
        protected override void BindVars()
        {
            this.bg = this.GetVar<Image>(0);
            this.txtTitle = this.GetVar<Text>(1);
            this.anim = this.GetVar<DOTweenAnimation>(2);
        }
        // --
    }
}
