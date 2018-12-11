using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TSolution_Bordfodbold.Entities {
  public class Spiller {
    [Key]
    public int Spiller_ID { get; set; }

    [Required]
    public string Brugernavn { get; set; }

    [Required]
    public string Kodeord { get; set; }


    public string Navn { get; set; }

    [Display(Name = "Scorede Mål")]
    public int Scorede_Maal { get; set; }

    [Display(Name = "Indkasserede Mål")]
    public int Indkasserede_Maal { get; set; }
    public int Vundne { get; set; }
    public int Tabte { get; set; }
    public int Uafgjorte { get; set; }
    public int WS { get; set; }


    public bool Administrator { get; set; }

    public Spiller() { }

    public Spiller(string brugernavn, string kodeord, string Navn, bool Administrator) {
      this.Spiller_ID = 0;
      this.Brugernavn = brugernavn;
      this.Kodeord = kodeord;
      this.Navn = Navn;
      this.Scorede_Maal = 0;
      this.Indkasserede_Maal = 0;
      this.Vundne = 0;
      this.Tabte = 0;
      this.Uafgjorte = 0;
      this.WS = 0;
      this.Administrator = Administrator;
    }

    public override string ToString() {
      return Navn;
    }
  }
}