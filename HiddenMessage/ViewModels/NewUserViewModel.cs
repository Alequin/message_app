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

