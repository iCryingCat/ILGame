using GFramework.UI;
using UnityEngine;

namespace GameLogic.UI
{
    public class PlayerInfoControl : BaseViewModel
    {
        public BindableProperty<string> userName = new BindableProperty<string>();

    }
}