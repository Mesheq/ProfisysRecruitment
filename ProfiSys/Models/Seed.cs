using ChoETL;
using ProfiSys.Data;
using Microsoft.EntityFrameworkCore;


namespace ProfiSys.Models
{

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DocumentContext(
            serviceProvider.GetRequiredService<
                    DbContextOptions<DocumentContext>>()))
            {
                using (var p = new ChoCSVReader(@"C:\Users\Paweł\Desktop\algorytmy\ProfiSys\ProfiSys\Models\Documents.csv").WithFirstLineHeader()) 
                {
                    p.Bcp("Server=(localdb)\\mssqllocaldb;Database=Dokument.Data;Trusted_Connection=True;MultipleActiveResultSets=true", "[Dokument.Data].[dbo].[Document]");
                }
                String filePath = @"C:\Users\Paweł\Desktop\algorytmy\ProfiSys\ProfiSys\Models\DocumentItems.csv";


                using (var p = new ChoCSVReader(@"C:\Users\Paweł\Desktop\algorytmy\ProfiSys\ProfiSys\Models\DocumentItems.csv").WithFirstLineHeader())
                {
                    p.Bcp("Server=(localdb)\\mssqllocaldb;Database=Dokument.Data;Trusted_Connection=True;MultipleActiveResultSets=true", "[Dokument.Data].[dbo].[DocumentItem]");
                }
                // Look for any movies.
                if (context.Document.Any())
                {
                    return;   // DB has been seeded
                };
               








                context.SaveChanges();
            }
        }
    }
}

