using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HiddenMessage.Service
{
    public class JsonHelper
    {
        public JsonHelper()
        {
        }

		public static JObject DeserialiseObject(String json)
		{
			return (JObject)JsonConvert.DeserializeObject(json);
		}

		public static JObject[] DeserialiseArray(String json)
		{
			JArray jsonArray = (JArray)JsonConvert.DeserializeObject(json);

            JObject[] result = new JObject[jsonArray.Count];
            for (int j = 0; j < result.Length; j++)
            {
                result[j] = JsonHelper.DeserialiseObject(jsonArray[j].ToString());   
            }

			return result;
		}
    }
}
