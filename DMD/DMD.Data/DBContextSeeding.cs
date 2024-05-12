using DMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Data
{
    public static class DBContextSeeding
    {
        public static async Task SeedAsync(DMDContext context)
        {
            if (!context.Bands.Any())
            {
                var bands = new List<DbBand>
                {
                    new()
                    {
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        ModifiedBy = "Seeding",
                        Albums = new List<DbAlbum>(),
                        CreatedBy = "Seeding",
                        Genre = "Death Metal",
                        Id = Guid.NewGuid(),
                        Members = new List<DbBandMember>(),
                        Name = "Death"
                    }
                };

                context.Bands.AddRange(bands);
                await context.SaveChangesAsync();
            }
        }
    }
}
