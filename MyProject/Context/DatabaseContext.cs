using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;
using System;

namespace MyProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chat>(chat =>
            {
                chat.HasOne(chat => chat.ToUser)
                    .WithMany(user => user.ReceivedChats)
                    .HasForeignKey(chat => chat.ToUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                chat.HasOne(chat => chat.FromUser)
                    .WithMany(user => user.SentChats)
                    .HasForeignKey(chat => chat.FromUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Follower>(follower =>
            {
                follower.HasOne(follower => follower.User)
                    .WithMany(user => user.FollowedUsers)
                    .HasForeignKey(follower => follower.FollowingUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                follower.HasOne(follower => follower.FollowingUser)
                    .WithMany(user => user.FollowingUsers)
                    .HasForeignKey(follower => follower.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}