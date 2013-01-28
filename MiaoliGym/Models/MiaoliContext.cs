using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    public class MiaoliContext:DbContext
    {
        public MiaoliContext()
            : base("name=DefaultConnection")
        { }

        public DbSet<Member> Members { get; set; }
        public DbSet<GymRecord> GymRecords { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<LendHeader> LendHeaders { get; set; }
        public DbSet<PurchaseRecord> PurchaseRecords { get; set; }
        public DbSet<SportsStuff> SportsStuffs { get; set; }

    }
}