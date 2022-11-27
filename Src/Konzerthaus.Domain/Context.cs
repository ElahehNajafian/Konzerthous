using Bogus;
using Konzerthaus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Konzerthaus.Domain.Model.Spectator;


namespace Konzerthaus.Domain
{
    public class Context : DbContext
    {
        //public Context()
        //{ }

        public Context(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Price> Price => Set<Price>();
        public DbSet<Singer> Singers => Set<Singer>();
        public DbSet<Saal> Saals => Set<Saal>();
        public DbSet<Spectator> Spectators => Set<Spectator>();
        public DbSet<Performance> Performances => Set<Performance>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=Konzerthaus.db");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spectator>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Spectator>()
               .Property(e => e.FirstName).IsRequired();
            modelBuilder.Entity<Spectator>()
               .Property(e => e.LastName).IsRequired();
            modelBuilder.Entity<Spectator>()
                .Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<Spectator>()
                .HasKey(e => e.EMail);
            modelBuilder.Entity<Spectator>()
                .HasKey(e => e.Address);

            modelBuilder.Entity<Concert>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Concert>()
                .Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Concert>()
                .Property(e => e.Seat);



            modelBuilder.Entity<Performance>()
                        .HasOne(c => c.Saal);
            modelBuilder.Entity<Performance>()
                        .Property(e => e.Datum);
            modelBuilder.Entity<Performance>()
                        .HasKey(e => e.Concert);
            modelBuilder.Entity<Performance>()
                        .HasKey(e => e.Id);
            modelBuilder.Entity<Performance>()
                        .HasKey(e => e.Price);
            modelBuilder.Entity<Performance>()
                        .HasKey(e => e.Singer);

            modelBuilder.Entity<Saal>()
                .Property(e => e.Name);
            modelBuilder.Entity<Saal>()
               .Property(e => e.Seat);
            modelBuilder.Entity<Saal>()
                .HasKey(c => c.Id);


            modelBuilder.Entity<Singer>()
               .Property(e => e.FirstName);
            modelBuilder.Entity<Singer>()
               .Property(e => e.LastName);
            modelBuilder.Entity<Singer>()
               .Property(e => e.GebDat);
            modelBuilder.Entity<Singer>()
                .HasOne(c => c.PerformanceNavigation);


            modelBuilder.Entity<Ticket>()
              .Property(e => e.Spectator);
            modelBuilder.Entity<Ticket>()
               .Property(e => e.Performance);
            modelBuilder.Entity<Ticket>()
               .Property(e => e.Price);


            modelBuilder.Entity<Concert>()
                   .ToTable("Concerts");
            modelBuilder.Entity<Ticket>()
                    .ToTable("Tickets");
            modelBuilder.Entity<Performance>()
                  .ToTable("Performances");
            modelBuilder.Entity<Singer>()
                  .ToTable("Singer");


            //    modelBuilder.Entity<Ticket>()
            //        .HasOne(c => c.Performance);
            //modelBuilder.Entity<Ticket>()
            //        .HasOne(c => c.Spectator);
            //modelBuilder.Entity<Spectator>()
            //        .OwnsOne(c => c.Address);
            //modelBuilder.Entity<Performance>()
            //       .HasOne(c => c.Saal);
            //modelBuilder.Entity<Performance>()
            //       .HasOne(c => c.Concert);
            //modelBuilder.Entity<Performance>() 
            //        .OwnsMany(c => c.Price);
            //modelBuilder.Entity<Performance>() 
            //        .HasMany(c => c.Singer);

        }

        public void Seed() 
        {
            Randomizer.Seed = new Random(5000);

            List<Saal> saals = new List<Saal>()
            {
              new Saal("Mozart Saal", 1500),
              new Saal("Grosser Saal", 2000),
            };
            saals.AddRange(saals);
            SaveChanges();

            List<Concert> concerts = new List<Concert>()
            {
                new Concert("Symphony 5",1500 ),
                new Concert("Rock", 1000 ),
            };
            Concerts.AddRange(concerts);
            SaveChanges();

            List<Performance> performances = new List<Performance>()
            {
               new Performance(saals[0], new DateTime(2022, 4, 12, 19, 30, 00), concerts[0]),
               new Performance(saals[1], new DateTime(2022, 10, 10, 20, 00,00), concerts[1]),
            };
            //performances[0].AddSinger(singers.ElementAt(0));

            Performances.AddRange(performances);
            SaveChanges();

            List<Concert> concert = new Faker<Concert>("en").CustomInstantiator(f => new Concert(f.Random.String2(1, "ABCD"), f.Random.Int(1, 2000))

                ).Generate(8)
                .ToList();
            Concerts.AddRange(concert);
            SaveChanges();


            List<Singer> singers = new List<Singer>()
            {
                new Singer("Cicilia", "Bartoli", new DateTime(1966, 06, 04), performances[0]),
                new Singer("Andrea", "Bocelli", new DateTime(1958, 09, 22), performances[1]),
            };
            Singers.AddRange(singers);
            SaveChanges();

            List<Spectator> spectators = new List<Spectator>()
            {
                new Spectator(GenderTypes.FEMALE, "Elaheh", "Najafian", "elahen@gmail.com", new Address("Mariahilfer-Str.", "243", "Wien"), "0667456987"  ),
                new Spectator(GenderTypes.MALE, "Andrea", "Mahler", "andream@gmail.com", new Address("Lorenz-Mandl-Gasse", "14", "Niederösterreich"), "0660689376" )
            };
            Spectators.AddRange(spectators);
            SaveChanges();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket(performances[0], spectators[0] ),
                new Ticket(performances[1], spectators[1]) ,
            };
            Tickets.AddRange(tickets);
            SaveChanges();

            //List<Ticket> tickets = new List<Ticket>()
            //{
            //    new Ticket(Ticket.TicketTypes.VIP),
            //    new Ticket(Ticket.TicketTypes.Normal),
            //};
            //Tickets.AddRange(tickets);
            //SaveChanges();




        }
    }
}

