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
        private ConversationListViewModel viewModel;

		[SetUp]
        public void Setup()
        {
			userNames = new List<string>() { "name1", "name2", "name3", "name4" };
            viewModel = new ConversationListViewModel(-1, "last message", userNames);
		}

		[Test]
		public void CanBuildStringOfUserNames()
		{
            string expected = "Users: name1, name2, name3, name4";
            string result = viewModel.UsersText;
		    Assert.AreEqual(expected, result);
		}

		[Test]
		public void CanAddUser()
		{
            viewModel.AddUser("name5");

			string expected = "Users: name1, name2, name3, name4, name5";
			string result = viewModel.UsersText;
			Assert.AreEqual(expected, result);
		}

	}
}
