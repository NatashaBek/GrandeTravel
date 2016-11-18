using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using NatashaAgileProject.Models;

namespace NatashaAgileProject.ViewModels
{
    public class SearchPackageViewModel
    {
        public string Location { get; set; }
        public IEnumerable<Package> Packages { get; set; }

        //Filter Search
        public string KeywordSearch { get; set; }
    }
}
