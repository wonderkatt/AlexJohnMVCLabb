using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BloodBowlTeamManager
{
    public class BBContext : DbContext
    {
        public BBContext()
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<AgilitySkill> AgilitySkills { get; set; }
        public DbSet<StrengthSkill> StrengthSkills { get; set; }
        public DbSet<GeneralSkill> GeneralSkills { get; set; }
        public DbSet<PassSkill> PassSkills { get; set; }
        public DbSet<Mutation> Mutations { get; set; }

        public BBContext(DbContextOptions<BBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = master; Integrated Security = True");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
