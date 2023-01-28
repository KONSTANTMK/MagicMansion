using MagicMansion_MansionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMansion_MansionAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Mansion> Mansions { get; set; }
		public DbSet<MansionNumber> MansionNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mansion>().HasData(
                new Mansion
                {
                    Id = 1,
                    Name = "Royal mansion",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://sun9-14.userapi.com/impg/0wx3laWZz-W3ClxGfdu8NfzKB4_IG9wtkhjyLg/WOb7pesENtQ.jpg?size=800x509&quality=95&sign=bcfc866301bd2269c19f794c24d19707&type=album",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate= DateTime.Now,
                    
                },
              new Mansion
              {
                  Id = 2,
                  Name = "Premium Pool mansion",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://sun9-30.userapi.com/impg/-xKq2aYv0vQMhz43SVPaRJvg-txJovhjIB0Kkw/4qHK5FADbpo.jpg?size=800x509&quality=95&sign=6e0ade8c4be3b87f67e281baae33bec8&type=album",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Mansion
              {
                  Id = 3,
                  Name = "Luxury Pool mansion",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://sun9-86.userapi.com/impg/K21KcfdcWKql89Nlv9B6Y5Cgeo7sMIlshAXHfw/D4lcWaxEd0w.jpg?size=800x509&quality=95&sign=4d9ebe62cef615f5592510d3cacb784c&type=album",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Mansion
              {
                  Id = 4,
                  Name = "Diamond mansion",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://sun9-85.userapi.com/impg/YGMw5mpK17Y1bZIyI-aqVHZ3KLCFFu-Hz7tYxg/CVRKxwkblk0.jpg?size=800x509&quality=95&sign=cc4494bacaf276443a6f504da371b80a&type=album",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Mansion
              {
                  Id = 5,
                  Name = "Diamond Pool mansion",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://sun9-46.userapi.com/impg/UZGqGTyJoTs-7eB0Yt-Bq5CK3HZRN7GneiOl0g/VghlnFMXU9A.jpg?size=800x509&quality=95&sign=4dd7b21a7c9f62d68d1daf7d5ffcb756&type=album",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              }
                );
        }
    }
}
