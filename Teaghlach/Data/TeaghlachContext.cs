using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teaghlach.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Teaghlach.Data
{
    public class TeaghlachContext : IdentityDbContext<IdentityUser>
    {
        public TeaghlachContext(DbContextOptions<TeaghlachContext> options)
            : base(options)
        {
        }
        public DbSet<FamilyMember> FamilyMembers { get; set; } = default!;
        public DbSet<Chore> Chores { get; set; }
        public DbSet<FamilyEvent> FamilyEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventSubCategory> EventSubCategories { get; set; }
        public DbSet<FamilyRole> FamilyRoles { get; set; }
        public DbSet<FamilySubRole> FamilySubRoles { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<List> Lists { get; set; }

        public DbSet<Reward> Reward { get; set; } = default!;
        public DbSet<Meal> Meal { get; set; } = default!;
        public DbSet<List> List { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed EventCategories
            modelBuilder.Entity<EventCategory>().HasData(
                new EventCategory { Id = 1, Name = "School" },
                new EventCategory { Id = 2, Name = "Sports" },
                new EventCategory { Id = 3, Name = "Birthday" }
            );

            // Seed EventSubCategories
            modelBuilder.Entity<EventSubCategory>().HasData(
                new EventSubCategory { Id = 1, Name = "Parent-Teacher Meeting", EventCategoryId = 1 },
                new EventSubCategory { Id = 2, Name = "School Play", EventCategoryId = 1 },
                new EventSubCategory { Id = 3, Name = "Football", EventCategoryId = 2 },
                new EventSubCategory { Id = 4, Name = "Camogie", EventCategoryId = 2 },
                new EventSubCategory { Id = 5, Name = "Child's Birthday", EventCategoryId = 3 },
                new EventSubCategory { Id = 6, Name = "Party", EventCategoryId = 3 }
            );

            // Seed FamilyRoles
            modelBuilder.Entity<FamilyRole>().HasData(
                new FamilyRole { Id = 1, Name = "Parent" },
                new FamilyRole { Id = 2, Name = "Child" }
            );

            // Seed FamilySubRoles
            modelBuilder.Entity<FamilySubRole>().HasData(
                new FamilySubRole { Id = 1, Name = "Father", FamilyRoleId = 1 },
                new FamilySubRole { Id = 2, Name = "Mother", FamilyRoleId = 1 },
                new FamilySubRole { Id = 3, Name = "Son", FamilyRoleId = 2 },
                new FamilySubRole { Id = 4, Name = "Daughter", FamilyRoleId = 2 }
            );
        }
        public DbSet<Teaghlach.Models.Settings> Settings { get; set; } = default!;
    }
}
