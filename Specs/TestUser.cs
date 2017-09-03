using System;
using HiddenMessage.Models;
using HiddenMessage.Service;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace Specs
{
    [TestFixture]
    public class TestUser
    {
		[Test]
		public void CanConstructUserFromJObject()
		{
            string jsonUser = "{\"id\": 8, \"name\": \"bob\", \"avatar\": 1, \"deviceSystem\": \"android\", \"deviceToken\": 101010, \"onlineStatus\": \"online\", \"isVisible\": true }";
            JObject JObjectUser = JsonHelper.DeserialiseObject(jsonUser);
            User result = new User(JObjectUser);

			Assert.AreEqual(8, result.Id);
			Assert.AreEqual("bob", result.Name);
			Assert.AreEqual(1, result.Avatar);
			Assert.AreEqual("android", result.DeviceSystem);
			Assert.AreEqual("101010", result.DeviceToken);
			Assert.AreEqual("online", result.OnlineStatus);
			Assert.AreEqual(true, result.IsVisible);
		}
    }
}
