using System.Collections.Generic;

using Lockstep.Math;

using ProtoBuf;

namespace GFramework.Network
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class InputContainer
    {
        public Dictionary<InputCode, LFloat> floatInput = new Dictionary<InputCode, LFloat>();
        public Dictionary<InputCode, bool> boolInput = new Dictionary<InputCode, bool>();

        public InputContainer()
        {
        }
    }
}