using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AutoCompleteControls
{
    public class CountriesProvider
    {
        public async Task<IEnumerable<Country>> GetCountriesAsync(string searchTerm)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = await client.GetAsync("https://restcountries.eu/rest/v1/all");

                var json = await request.Content.ReadAsStringAsync();

                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                return countries.Where(x => x.Name?.StartsWith(searchTerm) ?? true);
            }
        }
    }
}
