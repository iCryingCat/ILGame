using System.Collections.Generic;

using Lockstep.Math;

namespace GFramework.Network
{
    public class InputContainer
    {
        public long frameID = 0;
        public int unitID = 0;
        public Dictionary<InputCode, LFloat> floatInput = new Dictionary<InputCode, LFloat>();
        public Dictionary<InputCode, bool> boolInput = new Dictionary<InputCode, bool>();
        public Dictionary<InputCode, LVector2> vector2Input = new Dictionary<InputCode, LVector2>();
    }
}