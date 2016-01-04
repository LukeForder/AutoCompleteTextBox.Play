using PropertyChanged;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls;

namespace AutoCompleteControls
{
    [ImplementPropertyChanged]
    public class MainVM 
    {
        public string Text { get; set; }

        public ISuggestionProvider AutoCompleteSuggestions => new SuggestionProvider(searchTerm => new CountriesProvider().GetCountriesAsync(searchTerm).Result);
    }
}
