using Konzerthaus.Infrastructur;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Konzerthous.Infrastructur.Test
{
    public class UnitTest
    {

        [Fact]
        public void Test1()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite("Data Source= Konzerthaus.db")
                .Options;

            KonzerthausDbContext db = new KonzerthausDbContext(options);
            db.Database.EnsureDeleted();  
            db.Database.EnsureCreated(); 
            //db.Seed();          


            //db.Categories.Add(....)

            //db.Products.Add(new Domain.Model.Product("", "", "", "", 3, db.Categories[1]));
            //db.Products.Add(new Domain.Model.Product("", "", "", "", 3, db.Categories[1]));
            //db.Products.Add(new Domain.Model.Product("", "", "", "", 3, db.Categories[2]));

            //db.SaveChanges();

            Assert.True(true);
        }
    }
}
