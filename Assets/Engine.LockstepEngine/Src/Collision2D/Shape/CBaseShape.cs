// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

using Lockstep.Math;
using Lockstep.UnsafeCollision2D;

namespace Lockstep.Collision2D {
    public class CBaseShape {
        public virtual int TypeId => (int) EShape2D.EnumCount;
        public int id;
        public LFloat high;
    }
}