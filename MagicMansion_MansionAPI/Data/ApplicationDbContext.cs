using MagicMansion_MansionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMansion_MansionAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Mansion> Mansions { get; set; }
    }
}
