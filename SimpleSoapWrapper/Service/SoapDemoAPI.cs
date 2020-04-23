using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SoapDemoService;

namespace SimpleSoapWrapper.Service
{
    // TODO: Need to modified this class. Currently its not efficient.
    public class SoapDemoAPI : ISoapDemoAPI
    {
        public readonly string ServiceUrl = "https://www.crcind.com:443/csp/samples/SOAP.Demo.cls";
        public readonly EndpointAddress EndpointAddress;
        public readonly BasicHttpBinding BasicHttpBinding;

        public SoapDemoAPI()
        {
            EndpointAddress = new EndpointAddress(ServiceUrl);
            BasicHttpBinding = new BasicHttpBinding(EndpointAddress.Uri.Scheme.ToLower() == "http"
                ? BasicHttpSecurityMode.None
                : BasicHttpSecurityMode.Transport);
            BasicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            BasicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            BasicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            BasicHttpBinding.SendTimeout = TimeSpan.MaxValue;
        }

        public async Task<SOAPDemoSoapClient> GetInstanceAsync()
        {
            return await Task.Run(() => new SOAPDemoSoapClient(BasicHttpBinding, EndpointAddress));
        }

        public async Task<Address> GetCityDetails(string zipCode)
        {
            var client = await GetInstanceAsync();
            var response = await client.LookupCityAsync(zipCode);
            return response;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var client = await GetInstanceAsync();
            var response = await client.FindPersonAsync($"{id}");
            return response;
        }

        public async Task<List<PersonIdentification>> GetAllPersons()
        {
            var client = await GetInstanceAsync();
            var response = await client.GetListByNameAsync("");
            return response.ToList();
        }
    }
}