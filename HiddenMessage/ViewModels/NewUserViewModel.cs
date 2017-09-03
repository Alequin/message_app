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
            set { instructionText = value; }
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

        public void ShowPleaseWaitMessage()
        {
            instructionText = "This name is taken";
			instructionTextColour = Color.Red;
			this.HandelInstructionTextChange();
        }

        public void ShowNameTakenMessage()
        {
            instructionText = "This name is taken";
			instructionTextColour = Color.Red;
			this.HandelInstructionTextChange();
        }

        public void ShowEmptyInputMessage()
        {
            instructionText = "It's empty. Pick a user name";
            instructionTextColour = Color.Red;
            this.HandelInstructionTextChange();
        }

        private void HandelInstructionTextChange()
        {
            this.OnPropertyChange("InstructionText");
            this.OnPropertyChange("InstructionTextColour");
        }
		
    }
}

