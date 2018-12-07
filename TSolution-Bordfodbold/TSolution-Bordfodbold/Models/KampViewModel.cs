using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Models
{
    public class KampViewModel
    {
        public int Hold1_Maal { get; set; }
        public int Hold2_Maal { get; set; }
        public IEnumerable<Spiller> Spillere { get; set; }
        public string Spiller1 { get; set; }
        public string Spiller2 { get; set; }
        public string Spiller3 { get; set; }
        public string Spiller4 { get; set; }
    }
}