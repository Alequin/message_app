using System;
using NUnit.Framework;
using HiddenMessage.Service;
using Newtonsoft.Json.Linq;

namespace Specs
{
    [TestFixture]
    public class TestJson
    {
	
		[Test]
		public void CanDeserialiseJsonStringToJObject()
		{

            string jsonString = "{\"id\": 1, \"name\": \"A green door\", \"price\": 12.50, \"tags\": \"home\"}";
            JObject output = JsonHelper.DeserialiseObject(jsonString);

			Assert.AreEqual("A green door", output["name"].ToString());
            Assert.AreEqual(12.50, (double) output["price"]);
		}

        [Test]
        public void CanDeserialiseJsonArrayStringToArrayOfJObjects()
		{

            string jsonString = "[{\"id\": 1, \"name\": \"A green door\", \"price\": 12.50, \"tags\": \"home\"}, {\"id\": 2, \"name\": \"A red window\", \"price\": 5, \"tags\": \"green house\"}]";
			JObject[] output = JsonHelper.DeserialiseArray(jsonString);

			Assert.AreEqual("A green door", output[0]["name"].ToString());
			Assert.AreEqual(12.50, (double)output[0]["price"]);
			Assert.AreEqual("A red window", output[1]["name"].ToString());
			Assert.AreEqual(5, (int) output[1]["price"]);
		}
    }
}
