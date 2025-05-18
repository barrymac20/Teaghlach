using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teaghlach.Models;

namespace Teaghlach.Data
{
    public class TeaghlachContext : DbContext
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
        }


    }



}
