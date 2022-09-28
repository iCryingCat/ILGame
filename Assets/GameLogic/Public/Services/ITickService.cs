using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFramework.Network
{
    public interface IScene2Battle : ICaller
    {
        void ToHandleInput(InputContainer data);
    }

    public interface IBattle2Scene : ICallee
    {
        void OnSynInput(int unitID, InputContainer inputData);
    }

}