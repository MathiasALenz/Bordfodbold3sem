using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSolution_Bordfodbold.Entities
{
    public class Kamp
    {
        [Key]
        public int Kamp_ID { get; set; }
        public string Spiller1 { get; set; }
        public string Spiller2 { get; set; }
        public string Spiller3 { get; set; }
        public string Spiller4 { get; set; }
        public DateTime DatoTid { get; set; }

        [Display(Name = "Hold 1 mål")]
        public int Hold1_Maal { get; set; }

        [Display(Name = "Hold 2 mål")]
        public int Hold2_Maal { get; set; }

        public Kamp()
        {
            
            Spiller1 = "Hej";
            Spiller2 = "Dav";
            Spiller3 = "Goddag";
            Spiller4 = "Yes";
            
            DatoTid = DateTime.Now;
        }
    }
}