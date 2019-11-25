using System;
using System.Runtime.Serialization;

namespace IServices
{
    
    // brak atr. - DataContractSerializer


     
    [Serializable]
    public class Employee2
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NonSerialized]
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }
    }



    [DataContract(Namespace = "http://altkom.pl/schema/Employee")]
    public class Employee
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)] 
        public string FirstName { get; set; }

        [DataMember(Order = 3, Name = "Surname", IsRequired = true)] 
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
