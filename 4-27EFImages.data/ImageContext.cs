using System;
using Microsoft.EntityFrameworkCore;


namespace _4_27EFImages.data
{
    public class ImageContext : DbContext
    {
        private readonly string _conn;
        public ImageContext(string conn)
        {
            _conn = conn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }

        public DbSet<Image> Images { get; set; }
        

    }
}
