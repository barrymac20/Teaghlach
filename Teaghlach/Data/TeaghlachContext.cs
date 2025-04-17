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
        public TeaghlachContext (DbContextOptions<TeaghlachContext> options)
            : base(options)
        {
        }

        public DbSet<FamilyMember> FamilyMembers { get; set; } = default!;
        public DbSet<Chore> Chores { get; set; }
        public DbSet<FamilyEvent> FamilyEvents { get; set; }

    }
}
