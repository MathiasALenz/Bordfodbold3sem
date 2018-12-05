using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TSolution_Bordfodbold.Entities
{
    public class Spiller
    {
        [Key]
        public int Spiller_ID { get; set; }
        public string Navn { get; set; }
        public int Scorede_Maal { get; set; }
        public int Indkasserede_Maal { get; set; }
        public int Vundne { get; set; }
        public int Tabte { get; set; }
        public int Uafgjorte { get; set; }
        public int WS { get; set; }
        [Range(0, 1)]
        public int Administrator { get; set; }
    }
}