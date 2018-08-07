using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingData.Models.ViewModel
{
    public class CompaniesCharts
    {
        public List<Company> Companies { get; set; }
        public List<Chart> Charts { get; set; }

        public CompaniesCharts(List<Company> companies, List<Chart> charts)
        {
            Companies = companies;
            Charts = charts;
        }
    }
}
