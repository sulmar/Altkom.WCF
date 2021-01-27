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
        [OperationContract]
        void AddLargeDocument(DocumentUpload document);
    }

    [ServiceBehavior]
    public class DocumentService : IDocumentService
    {
        public void AddLargeDocument(DocumentUpload document)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"C:\temp\test.txt");
            FileStream stream = File.OpenWrite(filePath);

            document.Content.CopyTo(stream);
        }

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

    [MessageContract]
    public class DocumentUpload
    {
        [MessageHeader]
        public string Author { get; set; }
        [MessageHeader] 
        public string Name { get; set; }
        [MessageBodyMember]
        public Stream Content { get; set; }
    }
}
