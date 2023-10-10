using DotnetAngular.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace DotnetAngular.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Slide>((option) =>
            {
                option.HasKey(x => x.Id);
            });
            builder.Entity<PostType>((option) =>
            {
                option.HasKey(x => x.Id);
                option.HasMany(x => x.Posts)
                .WithOne(x => x.PostType)
                .HasForeignKey(x => x.PostTypeId);
            });
            builder.Entity<Post>((option) =>
            {
                option.HasKey(x => x.Id);
                option.HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);
            });
            builder.Entity<Comment>((option) =>
            {
                option.HasKey(x => x.Id);
                option.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId);
            });
            base.OnModelCreating(builder);
            ModelBuilderExtentions.Seed(modelBuilder:builder);
        }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
    }
}