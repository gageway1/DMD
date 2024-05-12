using DMD.Data.Models;
using DMD.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DMD.Data
{
    public class DMDContext(DbContextOptions<DMDContext> options) : DbContext(options)
    {
        public DbSet<DbBand> Bands { get; set; }
        public DbSet<DbSong> Songs { get; set; }
        public DbSet<DbAlbum> Albums { get; set; }
        public DbSet<DbBandMember> BandMembers { get; set; }
    }
}
