using Core.Entities;

using System.Text.Json;

namespace Infrastructure.Data
{
    public class MuseumContextSeed
    {
        public static async Task SeedAsync(MuseumContext context)
        {
            if (!context.ExhibitCulture.Any())
            {
                var exhibitCultureData = File.ReadAllText("../Infrastructure/Data/SeedData/culture.json");
                var cultures = JsonSerializer.Deserialize<List<ExhibitCulture>>(exhibitCultureData);
                context.ExhibitCulture.AddRange(cultures);
            }

            if (!context.ExhibitTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ExhibitType>>(typesData);
                context.ExhibitTypes.AddRange(types);
            }

            if (!context.Exhibits.Any())
            {
                var exhibitsData = File.ReadAllText("../Infrastructure/Data/SeedData/exhibits.json");
                var exhibits = JsonSerializer.Deserialize<List<Exhibits>>(exhibitsData);
                context.Exhibits.AddRange(exhibits);
            }


            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
