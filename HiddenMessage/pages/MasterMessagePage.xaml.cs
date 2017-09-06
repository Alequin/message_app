using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HiddenMessage.pages
{
    public partial class MasterMessagePage : MasterDetailPage
    {
        private int conversationId;

        public MasterMessagePage(int conversationId)
        {
            InitializeComponent();
            this.conversationId = conversationId;
            Detail = new MessagePage(conversationId);
        }
    }
}
