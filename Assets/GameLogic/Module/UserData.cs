using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFramework.UI;

namespace GameLogic
{
    public class UserData : BaseData
    {
        public string userName;
        public string nickName;

        public UserData(string userName, string nickName)
        {
            this.userName = userName;
            this.nickName = nickName;
        }
    }
}