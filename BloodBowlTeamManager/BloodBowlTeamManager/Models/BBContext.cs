using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BloodBowlTeamManager
{
    class BBContext : DbContext
    {
        string accountEndpoint = "https://localhost:8081";
        string accountKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        string databaseName = "BBDatabase";
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
            optionsBuilder.UseCosmos(accountEndpoint, accountKey, databaseName);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
