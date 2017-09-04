using System;
using System.Collections.Generic;
using HiddenMessage.ViewModels;
using NUnit.Framework;


namespace Specs
{
    [TestFixture]
    public class TestConversationListViewModel
    {

        private List<String> userNames;
        [SetUp]
        public void Setup()
        {
			userNames = new List<string>() { "name1", "name2", "name3", "name4" };
		}

		[Test]
		public void CanBuildStringOfUserNames()
		{
            ConversationListViewModel viewModel = new ConversationListViewModel("last message", userNames);

            string expected = "Users: name1, name2, name3, name4";
            string result = viewModel.UsersText;
		    Assert.AreEqual(expected, result);
		}

		//[Test]
		//public void CanAddUser()
		//{
		//	ConversationListViewModel viewModel = new ConversationListViewModel("last message", userNames);

		//	string expected = "Users: name1, name2, name3, name4";
		//	string result = viewModel.UsersText;
		//	Assert.AreEqual(expected, result);
		//}

	}
}
