using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Abstract
{
    public interface IRepository
    {
        IEnumerable<Spiller> Spillere { get; }

        void GemSpiller(Spiller spiller);

        Spiller SletSpiller(int spillerID);

        IEnumerable<Kamp> Kampe { get; }

        void GemKamp(Kamp kamp);
    }
}