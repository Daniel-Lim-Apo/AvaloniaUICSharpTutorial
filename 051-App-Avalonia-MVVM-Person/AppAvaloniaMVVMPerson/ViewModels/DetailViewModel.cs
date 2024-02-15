using AppAvaloniaMVVMPerson.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvaloniaMVVMPerson.ViewModels
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public Person Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        public DetailViewModel(Person person)
        {
            _person = person;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
