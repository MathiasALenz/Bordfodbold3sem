using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Spiller> Spillere { get; set; }
        public DbSet<Kamp> Kampe { get; set; }
    }
}