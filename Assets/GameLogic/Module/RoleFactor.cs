using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFramework;
using UnityEngine;

namespace GameLogic
{
    public class RoleFactor
    {
        GLogger logger = new GLogger("RoleFactor");

        public NetPlayer SpawnNetPlayer(ulong roleID)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            NetPlayer player = go.AddComponent<NetPlayer>();
            return player;
        }
    }
}