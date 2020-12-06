using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgKornyWPFbeadando.Models
{
    /// <summary>
    /// Service that implements CRUD operations on persons' collection
    /// </summary>

    public class PersonService
    {
        // Field: Collection of persons:
        private static List<Person> ObjPersonList;

        // Ctor: Init list and adding persons to it:
        public PersonService()
        {
            ObjPersonList = new List<Person>()
            {
                new Person("Jackie Chan", "jckchan@gmail.com", "06704564456", "Hong Kong"),
                new Person("Axl Rose", "axl@gmail.com", "06307658975", "Lafayette"),
                new Person("Carl Johnson", "cj@gmail.com", "06202433455", "Los Santos"),
                new Person("Tupac Amaru Shakur", "tupac@gmail.com", "06202222222", "New York"),
                new Person("Lewis Hamilton", "lwhmlton@gmail.com", "06304569876", "Stevenage")
            };
        }

        // Method: Get all elements of list:
        public List<Person> GetAll()
        {
            return ObjPersonList;
        }

        // Function: Get list element by id:
        public Person GetPersonById(int id)
        {
            foreach (Person p in ObjPersonList)
                if (p.Id == id)
                    return p;

            return null;
        }

        // Method: Add:
        public void Add(Person objNewPerson)
        {
            ObjPersonList.Add(objNewPerson);       
        }

        // Method: Delete:
        public void Delete(Person objPersonToDelete)
        {
            for (int i = 0; i < ObjPersonList.Count; i++)
                if (ObjPersonList[i].Id == objPersonToDelete.Id)
                    ObjPersonList.RemoveAt(i);     
        }
    }
}
