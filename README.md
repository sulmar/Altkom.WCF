## Remoting Service

1. Utwórz projekt _IServices_ i dodaj interfejs 

~~~ csharp
public interface IHelloRemotingService
{
    string Ping();
    string Ping(string message);
}
~~~

2. Utwórz projekt _RemotingServices_ i dodaj implementację
~~~ csharp
public class HelloRemotingService : MarshalByRefObject, IHelloRemotingService
{
     public string Ping()
    {
        return "Pong";
    }

    public string Ping(string message)
    {
        return message;
    }
}
~~~

3. Utwórz projekt _RemotingServiceHost_

~~~ csharp
static void Main(string[] args)
{
    // add reference System.Runtime.Remoting
    int port = 8080;

    RemotingServices.HelloRemotingService remotingService = new RemotingServices.HelloRemotingService();
    TcpChannel channel = new TcpChannel(port);
    ChannelServices.RegisterChannel(channel);
    RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingServices.HelloRemotingService), "Ping", WellKnownObjectMode.Singleton);

    Console.WriteLine($"Remoting service started on {port}");
    Console.ReadLine();
}
~~~


4. Utwórz projekt _HelloRemotingServiceConsoleClient_

~~~ csharp
private static void PingTest()
{
    IServices.IHelloRemotingService client;

    TcpChannel channel = new TcpChannel();
    ChannelServices.RegisterChannel(channel);

    client = (IServices.IHelloRemotingService)Activator.GetObject(typeof(IServices.IHelloRemotingService), "tcp://localhost:8080/Ping");

    while (true)
    {
        Console.WriteLine("Ping");
        string response = client.Ping("Pong");

        Console.WriteLine(response);

        Thread.Sleep(TimeSpan.FromSeconds(2));
    }
}
~~~

## WCF Service

1. Utwórz projekt _HelloService_

- Utwórz interfejs 
~~~ csharp
 // add reference System.ServiceModel
[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    string Ping(string message);
}
~~~

- Utwórz implementację

~~~ csharp
public class HelloService : IHelloService
{
    public string Ping(string message)
    {
        return message;
    }
}
~~~

### Self-Hosting

1. Utwórz projekt _HelloServiceHost_

~~~ csharp
 static void Main(string[] args)
{
    using(ServiceHost host = new ServiceHost(typeof(HelloService.HelloService)))
    {
        host.Open();
        Console.WriteLine("Host started on");

        foreach (var uri in host.BaseAddresses)
        {
            Console.WriteLine(uri);

        }

        Console.ReadLine();
    }
}
~~~

1. Dodaj konfigurację w pliku _app.config_

~~~ xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>


  <system.serviceModel>
    <services>
      <service name="HelloService.HelloService" behaviorConfiguration="mexBehavior">
        
        <endpoint address="HelloService" binding="basicHttpBinding" contract="HelloService.IHelloService">
        </endpoint>

        <endpoint address="HelloService" binding="netTcpBinding" contract="HelloService.IHelloService">
        </endpoint>

        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange">
          
        </endpoint>

        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8080/" />
            <add baseAddress="net.tcp://localhost:8090/ "/>
          </baseAddresses>
        </host>

      </service>
    </services>

    <behaviors>
      <serviceBehaviors>
        <behavior name="mexBehavior">
          <serviceMetadata httpGetEnabled="true" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
</configuration>
~~~

3. Uruchom jako administator

## Klient

### Utworzenie klienta z użyciem wygenerowanej klasy Proxy

1. Utwórz projekt _HelloServiceConsoleClient_

2. Wybierz opcję *Add Service Reference* i wskaż adres _http://localhost:8080/_

3. Utwórz kod klienta
~~~ csharp 
static void Main(string[] args)
    {
        HelloService.HelloServiceClient client = new HelloService.HelloServiceClient();
        string response = client.Ping("Hello");

        Console.WriteLine(response);
    }
~~~

**uwaga** - W przypadku gdy w pliku konfiguracyjnym zdefiniowania wiele bindingów należy w konstruktorze przekazać nazwę konfiguracji.

Zalety:
- łatwe generowanie

Wady:
- Brak odporności na zmianę (po każdej zmianie kontraktu należy wygenerować klienta na nowo

 ~~~ csharp 
static void Main(string[] args)
    {
        HelloService.HelloServiceClient client = new HelloService.HelloServiceClient("BasicHttpBinding_IHelloService");
            string response = client.Ping("Hello");

            Console.WriteLine(response);
    }
~~~

### Utworzenie klienta z własną klasą Proxy

~~~ csharp
  public class HelloServiceProxy : ClientBase<IHelloService>, IHelloService
    {
        public string Ping(string message)
        {
            return base.Channel.Ping(message);
        }

        public Task<string> PingAsync(string message)
        {
            return base.Channel.PingAsync(message);
        }
    }
~~~

### Utworzenie klienta z użyciem fabryki **ChannelFactory**

~~~ csharp
private static void ChannelFactoryTest()
    {
        BasicHttpBinding myBinding = new BasicHttpBinding();
        EndpointAddress myEndpoint = new EndpointAddress("http://localhost:8080/HelloService");

        ChannelFactory<IHelloService> proxy = new ChannelFactory<IHelloService>(myBinding, myEndpoint);
        IHelloService client = proxy.CreateChannel();

        string response = client.Ping("Hello");

        ((IClientChannel)client).Close();
    }
~~~


## Serializacja złożonych typów

~~~ csharp
public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
~~~

http://localhost:8080/?xsd=xsd2


### Typy atrybutów

**brak** - domyślnie używa DataContractSerializer. Serializuje wszystkie publiczne właściwości w porządku alfabetycznym. Prywatne pola i właściwości nie są serializowane.

**[Serializable]** - serializacuje wszystkie pola. Nie mamy kontroli nad tym, które pola będą zawarte lub pominięte w danych.

**[DataContract]** - serializacuje wszystkie pola oznaczone **[DataMember]**. Pola, które nie są oznaczone atrybutem [DataMember] są pomijane z serializacji. Atrybut [DataMember] może być stosowany również do prywatnych pól i publicznych właściwości.


~~~ csharp
[DataContract]
public class Employee
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
~~~

### Dodatkowe modyfikatory

namespace, nazwy pól, kolejność

~~~ csharp
[DataContract(Namespace = "http://www.altkom.pl/Employee")]
public class Employee
{
    [DataMember(Name = "ID", Order = 1)]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public string FirstName { get; set; }

    [DataMember(Order = 3, IsRequired = true)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
~~~


## Znane typy (KnowTypes)

### Opcja 1 - atrybut **[KnownType]** na klasie bazowej

~~~ csharp
  [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://www.altkom.pl/Employee")]
    public class Employee
    {
        [DataMember(Name = "ID", Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }


    public class FullTimeEmployee : Employee
    {
        public decimal AnnualSalary { get; set; }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyPay { get; set; }
    }
  ~~~

### Opcja 2 - atrybut **[ServiceKnownType]** na kontrakcie usługi

Dotyczy wszystkich operacji tylko w kontrakcie usługi.

~~~ csharp
[ServiceKnownType(typeof(PartTimeEmployee))]
[ServiceKnownType(typeof(FullTimeEmployee))]
[ServiceContract]
public interface IEmployeeService
{
    [OperationContract]
    Employee Get(int id);

    [OperationContract]
    void Add(Employee employee);
}
~~~

### Opcja 3 - tylko wybrane operacje
~~~ csharp
[ServiceContract]
public interface IEmployeeService
{
    [ServiceKnownType(typeof(PartTimeEmployee))]
    [ServiceKnownType(typeof(FullTimeEmployee))]
    [OperationContract]
    Employee Get(int id);

    [OperationContract]
    void Add(Employee employee);
}
~~~
