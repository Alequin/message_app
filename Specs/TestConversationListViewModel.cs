using System;
using HiddenMessage.ViewModels;
using NUnit.Framework;


namespace Specs
{
    [TestFixture]
    public class TestConversationListViewModel
    {
		[Test]
		public void CanBuildStringOfUserNames()
		{
            String[] userNames = new string[] { "name1", "name2", "name3", "name4" };

            ConversationListViewModel viewModel = new ConversationListViewModel("last message", userNames);

            string expected = "Users: name1, name2, name3, name4";
            string result = viewModel.UsersText;
		    Assert.AreEqual(expected, result);
		}

	}
}
