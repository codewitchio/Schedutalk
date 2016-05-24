using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Logic.KTHPlaces
{
    [DataContract]
    public class RoomDataContract
    {
        [DataMember(Name = "floorUid")]
        public string FloorUId { get; set; }
        [DataMember(Name = "buildingName")]
        public string BuildingName { get; set; }
        [DataMember(Name = "campus")]
        public string Campus { get; set; }
        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }
        [DataMember(Name = "placeName")]
        public string PlaceName { get; set; }
        [DataMember(Name = "uid")]
        public string UId { get; set; }
    }


}