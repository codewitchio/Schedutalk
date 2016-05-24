using Newtonsoft.Json;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Schedutalk.Logic.KTHPlaces
{
    class KTHPlacesDataFetcher
    {
        const string APIKEY = "NZfvZYDhIqDrPZvsnkY0Ocb5qJPlQNwh1BsVEH5H";
        HttpRequestor httpRequestor;

        public KTHPlacesDataFetcher()
        {
            string placeName = "E2";
            httpRequestor = new HttpRequestor();
            string recivedData = httpRequestor.getJSONAsString(getRoomExistRequestMessage, placeName);

            RoomExistsDataContract roomExistsDataContract = JsonConvert.DeserializeObject<RoomExistsDataContract>(recivedData);

            bool roomExists = roomExistsDataContract.Exists;
            if (roomExists)
            {
                recivedData = httpRequestor.getJSONAsString(getRoomDataRequestMessage, placeName);
                RoomDataContract roomDataContract =
                    JsonConvert.DeserializeObject<RoomDataContract>(recivedData);

                Debug.WriteLine("The building name was: " + roomDataContract.BuildingName);
            }
            else
            {
                Debug.WriteLine("Failed to fetch room data for" + placeName);
            }
        }

        public HttpRequestMessage getRoomExistRequestMessage(string room)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, @"https://www.kth.se/api/places/v3/room/exists/" + room + "?api_key=" + APIKEY);
            return request;
        }

        public HttpRequestMessage getRoomDataRequestMessage(string room)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, @"https://www.kth.se/api/places/v3/room/name/" + room  + "?api_key=" + APIKEY);
            return request;
        }
    }
}
