using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingData.Models
{
    public class ChartRoot
    {
        public Chart [] chart { get; set; }
    }

    public class Chart
    {
        public int ChartId { get; set; }
        public string symbol { get; set; }
        public Company company { get; set; }
        public string date { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
        public int unadjustedVolume { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public float vwap { get; set; }
        public string label { get; set; }
        public float changeOverTime { get; set; }
    }
}
