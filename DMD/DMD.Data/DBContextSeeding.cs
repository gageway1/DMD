using DMD.Data.Models;
using Microsoft.EntityFrameworkCore;
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
            context.Songs.RemoveRange(context.Songs);
            context.BandMembers.RemoveRange(context.BandMembers);
            context.Bands.RemoveRange(context.Bands);
            context.Albums.RemoveRange(context.Albums);

            if (!context.Bands.Any())
            {
                var bandId = Guid.NewGuid();
                var bands = new List<DbBand>
                {
                    new()
                    {
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        ModifiedBy = "Seeding",
                        CreatedBy = "Seeding",
                        Genre = "Death Metal",
                        Name = "Death"
                    }
                };

                context.AddRange(bands);
                await context.SaveChangesAsync();

                var band = await context.Bands.FirstAsync();

                var bandMembers = new List<DbBandMember>
                {
                    new()
                    {
                        Instrument = "Guitar/Vocals",
                        CreatedBy = "Seeding",
                        ModifiedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        DbBandId = band.Id
                    }
                };

                await context.BandMembers.AddRangeAsync(bandMembers);
                band.Members = bandMembers;
                context.Bands.Update(band);
                await context.SaveChangesAsync();

                var albums = new List<DbAlbum>
                {
                    new()
                    {
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        ModifiedBy = "Seeding",
                        DbBandId = bandId,
                        ModifiedOn = DateTime.Now,
                        Name = "Sound Of Perseverance"
                    }
                };

                await context.Albums.AddRangeAsync(albums);
                band.Albums = albums;
                context.Bands.Update(band);
                await context.SaveChangesAsync();

                var album = await context.Albums.FirstAsync();

                var songs = new List<DbSong>
                {
                    new() {
                        Name = "Scavenger of Human Sorrow",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 6, 55),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Bite the Pain",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 4, 29),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Spirit Crusher",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 6, 44),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Story to Tell",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 6, 34),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Flesh and the Power It Holds",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 8, 25),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Voice of the Soul",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 3, 42),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "To Forgive Is to Suffer",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 5, 55),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "A Moment of Clarity",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 7, 25),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    },
                    new() {
                        Name = "Painkiller",
                        ModifiedOn = DateTime.Now,
                        CreatedBy = "Seeding",
                        CreatedOn = DateTime.Now,
                        Length = new TimeSpan(0, 6, 3),
                        ModifiedBy = "System",
                        DbAlbumId = album.Id
                    }
                };

                await context.Songs.AddRangeAsync(songs);
                album.Songs = songs;
                context.Albums.Update(album);
                await context.SaveChangesAsync();
            }
        }

        public static async Task<T> SaveEntity<T>(DMDContext context, T entity) where T : class
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public static async Task<IList<T>> SaveEntityRangeAsync<T>(DMDContext context, IList<T> entities) where T : class
        {
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
            return entities;
        }
    }
}
