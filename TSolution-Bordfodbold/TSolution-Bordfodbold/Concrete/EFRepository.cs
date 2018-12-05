using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Concrete
{
    public class EFRepository : IRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Spiller> Spillere
        {
            get { return context.Spillere; }
        }

        public void GemSpiller(Spiller spiller)
        {
            if(spiller.Spiller_ID == 0)
            {
                context.Spillere.Add(spiller);
            }
            else
            {
                Spiller dbEntry = context.Spillere.Find(spiller.Spiller_ID);
                if(dbEntry != null)
                {
                    dbEntry.Navn = spiller.Navn;
                    dbEntry.Scorede_Maal = spiller.Scorede_Maal;
                    dbEntry.Indkasserede_Maal = spiller.Indkasserede_Maal;
                    dbEntry.Vundne = spiller.Vundne;
                    dbEntry.Tabte = spiller.Tabte;
                    dbEntry.Uafgjorte = spiller.Uafgjorte;
                    dbEntry.WS = spiller.WS;
                    dbEntry.Administrator = spiller.Administrator;
                }
            }

            context.SaveChanges();
        }

        public Spiller SletSpiller(int spillerID)
        {
            Spiller dbEntry = context.Spillere.Find(spillerID);
            if(dbEntry != null)
            {
                context.Spillere.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}