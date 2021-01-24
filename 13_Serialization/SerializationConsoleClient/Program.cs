using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            DataContractSerializer serializer = new DataContractSerializer(typeof(Customer));
            MemoryStream outputStream = new MemoryStream();

            //Serializacja
            serializer.WriteObject(outputStream, customer);

            //Pobierz dane ze strumienia
            string serializedValue = Encoding.UTF8.GetString(outputStream.ToArray());

            Console.WriteLine(serializedValue);

            outputStream.Position = 0;

            //Deserializacja
            var deserializedPerson = serializer.ReadObject(outputStream);

            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
