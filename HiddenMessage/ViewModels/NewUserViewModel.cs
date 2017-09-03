using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace HiddenMessage.ViewModels
{
    public class NewUserViewModel : INotifyPropertyChanged
    {

		private string instructionText;
		private Color instructionTextColour;

        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChange(String propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public string InstructionText
        {
            get { return instructionText; }
        }

		public Color InstructionTextColour
		{
			get { return instructionTextColour; }
		}

        public NewUserViewModel()
        {
            this.instructionText = "Select a user name";
            this.instructionTextColour = Color.Black;
        }

        public void setInstructionTextToWarningMessage()
        {
            instructionText = "This name is taken";
            instructionTextColour = Color.Red;
			this.OnPropertyChange("InstructionText");
			this.OnPropertyChange("InstructionTextColour");
        }
		
    }
}


//using System;
//using Xamarin.Forms;
//using System.ComponentModel;
//namespace newFormPlay
//{
//	public class TestViewModel : INotifyPropertyChanged
//	{
//		public TestViewModel(String name)
//		{
//			this.Name = name;
//		}

//		public event PropertyChangedEventHandler PropertyChanged;

//		private void OnPropertyChange(String propertyName)
//		{
//			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//		}

//		string name = "James";
//		public string Name
//		{
//			get
//			{
//				return name;
//			}
//			set
//			{
//				name = value;
//				this.OnPropertyChange("Name");
//			}
//		}

//		public Thickness TopMargin
//		{
//			get
//			{
//				switch (Device.RuntimePlatform)
//				{
//					case Device.iOS:
//						return new Thickness(0, 30, 0, 0);

//					default:
//						return new Thickness(0, 0, 0, 0);
//				}
//			}
//		}

//		private int editorSize = 500;
//		public int EditorSize
//		{
//			get
//			{
//				return editorSize;
//			}
//			set
//			{
//				editorSize = value;
//				this.OnPropertyChange("EditorSize");
//			}
//		}
//	}
//}



