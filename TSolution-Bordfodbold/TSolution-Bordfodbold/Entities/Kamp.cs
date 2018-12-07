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
        public int Spiller1_ID { get; set; }
        public int Spiller2_ID { get; set; }
        public int Spiller3_ID { get; set; }
        public int Spiller4_ID { get; set; }
        public DateTime DatoTid { get; set; }

        [Display(Name = "Hold 1 mål")]
        public int Hold1_Maal { get; set; }

        [Display(Name = "Hold 2 mål")]
        public int Hold2_Maal { get; set; }
    }
}