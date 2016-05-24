using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Logic.KTHPlaces
{
    [DataContract]
    class RoomExistsDataContract
    {
        [DataMember(Name = "exists")]
        public bool Exists { get; set; }
    }
}
