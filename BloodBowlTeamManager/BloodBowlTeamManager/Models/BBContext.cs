using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodBowlTeamManager
{
    public class BBContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

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

        public BBContext(DbContextOptions<BBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BBmanager;Integrated Security=True");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
