using DotNetTraining_Assignments_Session2.Model;

namespace DotNetTraining_Assignments_Session2.Services
{
    
    
    public interface IPeopleService
    {
        IList<Person> GetAllPeoples();
        bool CreatePeople(Person person);
    }
    public class PeopleService: IPeopleService
    {
        private static readonly IList<Person> _persons = new List<Person>()
        {
            new Person() {Id = 1, FirstName = "Rakesh", LastName = "Lad", Age = 37},
            new Person() {Id = 2, FirstName = "Ajay", LastName = "Pardhi", Age = 38},
            new Person() {Id = 3, FirstName = "Mahesh", LastName = "Mohan", Age = 36}
        };
       
        public PeopleService()
        {
           
        }


        public IList<Person> GetAllPeoples()
        {
            return _persons.ToList();
        }

        public bool CreatePeople(Person person)
        {
            _persons.Add(person);
            return true;
        }

        
    }
}
