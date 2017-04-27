using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flickr.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostsTags> PostsTags { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostsTags>()
                 .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostsTags>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostsTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostsTags>()
               .HasOne(pt => pt.Tag)
               .WithMany(p => p.PostsTags)
               .HasForeignKey(pt => pt.TagId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
