using AppAvaloniaMVVMPerson.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvaloniaMVVMPerson.ViewModels
{
    public class SummaryViewModel : INotifyPropertyChanged
    {
        private string _info;

        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public SummaryViewModel(Person person)
        {
            Info = $"{person.Name} is {person.Age} years old.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
