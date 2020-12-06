using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgKornyWPFbeadando.Models
{
    /// <summary>
    /// Person model
    /// </summary>

    public class Person : INotifyPropertyChanged
    {
        // Implement interface:
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Fields:
        #region Fields
        static int ID = 1; //first person will have id: 1
        int id;
        string name;
        string email;
        string mobile;
        string city;
    #endregion

        // Constructor that auto increments ID:
        public Person(string name, string email, string mobile, string city)
        {
            this.Name = name;
            this.Email = email;
            this.Mobile = mobile;
            this.City = city;
            this.Id = ID;
            ID++;
        }

        // Constructor with 0 id:
        public Person(int id, string name, string email, string mobile, string city)
        {
            this.Name = name;
            this.Email = email;
            this.Mobile = mobile;
            this.City = city;
            this.Id = id;
        }

        // Id property:
        public int Id
        {
            get { return id; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Field \"id\" cannot be null!");
                }
                else if (value < 0)
                {
                    throw new Exception("Id cannot be less than 0!");
                }
                else
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        // Name property:
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        // Email property:
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        // Mobile property:
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; OnPropertyChanged("Mobile"); }
        }

        // City property:
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }
    }
}
