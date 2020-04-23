using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SoapDemoService;

namespace SimpleSoapWrapper.Service
{
    public interface ISoapDemoAPI
    {
        Task<SOAPDemoSoapClient> GetInstanceAsync();
        Task<Address> GetCityDetails(string zipCode);
        Task<Person> GetPersonById(int id);
        Task<List<PersonIdentification>> GetAllPersons();
    }
}
