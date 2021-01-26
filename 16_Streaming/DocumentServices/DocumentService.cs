using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DocumentServices
{
    [ServiceContract]
    public interface IDocumentService
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        Stream GetLargeDocument();
    }

    [ServiceBehavior]
    public class DocumentService : IDocumentService
    {
        public Stream GetLargeDocument()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"C:\temp\photo1.jpg");
            FileStream stream = File.OpenRead(filePath);

            return stream;
        }

        public string Ping()
        {
            return "Pong";
        }
    }
}
