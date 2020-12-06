using Caliburn.Micro;
using ProgKornyWPFbeadando.Command;
using ProgKornyWPFbeadando.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgKornyWPFbeadando.ViewModels
{
     /// <summary>
     /// ViewModel for persons
     /// </summary>

    public class PersonsViewModel : INotifyPropertyChanged
    {
        // Ctor: Init:
        public PersonService ObjPersonService;
        public PersonsViewModel()
        {
            SelectedPerson = new Person(0, "Some Name", "somemail@gmail.com", "06304689647", "Eger");
            ObjPersonService = new PersonService();
            loadPeople();
            Color = "White";
            Message = "Create a new person!";
            CurrentPerson = new Person("Some Name", "somemail@gmail.com", "06304689647", "Eger");
            saveCommand = new RelayCommand(Save);
        }

        // Implement interface:
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Property: List of persons:
        private ObservableCollection<Person> personsList;
        public ObservableCollection<Person> PersonsList
        {
            get { return personsList; }
            set { personsList = value; OnPropertyChanged("PersonsList"); }
        }

        // Property: Command:
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        // Property: Selected person:
        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; OnPropertyChanged("SelectedPerson"); }
        }

        // Property: Current person:
        private Person currentPerson;
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set { currentPerson = value; OnPropertyChanged("CurrentPerson"); }
        }

        // Property: Message:
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        // Property: Color:
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged("Color"); }
        }

        // Method: Load person list elements:
        public void loadPeople()
        {
            this.PersonsList = new ObservableCollection<Person>(ObjPersonService.GetAll());
        }

        // Method: Save person:
        public void Save()
        {
            try
            {
                ValidatePersonFields(currentPerson);

                Person personToAdd = new Person(
                    currentPerson.Name,
                    currentPerson.Email,
                    currentPerson.Mobile,
                    currentPerson.City
                    );
                ObjPersonService.Add(personToAdd);

                loadPeople();
                Color = "LightGreen";
                Message = "Person added successfully!";

                currentPerson.Name = personToAdd.Name;
                currentPerson.Email = personToAdd.Email;
                currentPerson.Mobile = personToAdd.Mobile;
                currentPerson.City = personToAdd.City;
            }
            catch (Exception ex)
            {
                Color = "Red";
                Message = ex.Message;
            }
        }

        // Method: Validate new person fields:
        public void ValidatePersonFields(Person person)
        {
            // Name:
            if (person.Name == null)
            {
                throw new Exception("Name cannot be null!");
            }
            else if (person.Name.Length < 5)
            {
                throw new Exception("Name must be at least five characters long!");
            }
            else if (person.Name.Length > 32)
            {
                throw new Exception("Name length cannot be over 32 characters long!");
            }
            else if (person.Name.Any(char.IsDigit))
            {
                throw new Exception("Name cannot contain numbers!");
            }
            else if (!person.Name.Contains(' '))
            {
                throw new Exception("There must be a space between first and last name!");
            }
            else if (person.Name[0] == ' ' || person.Name[person.Name.Length - 1] == ' ')
            {
                throw new Exception("Space cannot be the first or last character!");
            }

            // Email:
            if (person.Email == null)
            {
                throw new Exception("Email cannot be null!");
            }
            else if (person.Email.Length <= 0)
            {
                throw new Exception("Email must be at least one characters long!");
            }
            else if (person.Email.Contains(' '))
            {
                throw new Exception("Email cannot contain spaces!");
            }
            else if (!person.Email.Contains('@') || person.Email[0] == '@' || person.Email[person.Email.Length - 1] == '@')
            {
                throw new Exception("Email must contain the character @ which must be inline!");
            }

            // Mobile:
            if (person.Mobile == null)
            {
                throw new Exception("Mobile cannot be null!");
            }
            else if (person.Mobile.Length != 11)
            {
                throw new Exception("Mobile must consist of 11 characters exactly!");
            }
            else if (!person.Mobile.All(char.IsDigit))
            {
                throw new Exception("Phone number can only contain digits!");
            }

            // City:
            if (person.City == null)
            {
                throw new Exception("City cannot be null!");
            }
            else if (person.City.Length <= 0)
            {
                throw new Exception("City must be at least one characters long!");
            }
        }
    }
}
