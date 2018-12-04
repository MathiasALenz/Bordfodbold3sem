using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSolution_Bordfodbold.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Spiller> Spillere { get; set; }
    }
}