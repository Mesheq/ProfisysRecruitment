
using Microsoft.EntityFrameworkCore;
using ProfiSys.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace ProfiSys.Data
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        public DbSet<ProfiSys.Models.Document> Document { get; set; } = default!;
    
        public DbSet<ProfiSys.Models.DocumentItem> DocumentItem { get; set; } = default!;
    
    }


}

