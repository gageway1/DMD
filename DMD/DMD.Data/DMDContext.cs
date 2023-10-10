using DMD.Data.Models;
using DMD.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DMD.Data
{
    public class DMDContext : DbContext, IUnitOfWork
    {
        public DMDContext() { }

        public DMDContext(DbContextOptions<DMDContext> options) : base(options)
        {

        }

        public DbSet<DbBand> Bands { get; set; }
        public DbSet<DbSong> Songs { get; set; }
        public DbSet<DbAlbum> Albums { get; set; }
        public DbSet<DbBandMember> BandMembers { get; set; }

        public async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
