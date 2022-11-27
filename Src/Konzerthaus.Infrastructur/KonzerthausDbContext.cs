using Konzerthaus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace Konzerthaus.Infrastructur
{
    public class KonzerthausDbContext : DbContext
    {

        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Price> Price => Set<Price>();
        public DbSet<Singer> Singer => Set<Singer>();
        public DbSet<Saal> Saals => Set<Saal>();
        public DbSet<Spectator> Spectators => Set<Spectator>();
        public DbSet<Performance> performances => Set<Performance>();

        public KonzerthausDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Konzerthaus.db"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Spectator>()
                .OwnsOne(e => e.Address);
            modelBuilder.Entity<Ticket>()
                .HasOne(c => c.Performance);
            modelBuilder.Entity<Ticket>()
                .HasOne(c => c.Spectator);
            modelBuilder.Entity<Performance>()
               .HasOne(c => c.Saal);
            modelBuilder.Entity<Performance>()
               .HasOne(c => c.Saal);
            modelBuilder.Entity<Performance>()  
                .OwnsMany(c => c.Price);
            modelBuilder.Entity<Performance>()  
                .HasMany(c => c.Singer);

            modelBuilder.Entity<Spectator>()
                .HasIndex(e => e.EMail).IsUnique(); 

            modelBuilder.Entity<Spectator>()
               .Property(e => e.LastName).IsRequired();  

            modelBuilder.Entity<Spectator>()
                .Property(e => e.LastName).HasMaxLength(80);

            modelBuilder.Entity<Spectator>() //PK
                .HasKey(e => e.Id);

            modelBuilder.Entity<Spectator>()
                .ToTable("Spectator");


        }


    }
}

