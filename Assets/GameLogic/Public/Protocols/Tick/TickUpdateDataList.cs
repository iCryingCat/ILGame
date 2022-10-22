using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TickUpdateDataList
    {
        public List<TickUpdateData> dataList = new List<TickUpdateData>();

        public TickUpdateDataList()
        {
        }

        public TickUpdateDataList(List<TickUpdateData> dataList)
        {
            this.dataList = dataList;
        }
    }
}