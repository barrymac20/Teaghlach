using Microsoft.EntityFrameworkCore;
using Teaghlach.Data;
using Teaghlach.Models;

namespace Teaghlach.Tests
{
    public class FamilyMemberTests
    {
        // This helper method sets up a fresh in-memory database for each test
        private TeaghlachContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TeaghlachContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Makes sure the DB is isolated per test
                .Options;

            return new TeaghlachContext(options);
        }

        [Fact]
        public async Task AddFamilyMember_SavesToDatabase()
        {
            // Set up a new in-memory DB context
            using var context = GetInMemoryDbContext();

            // Create a new FamilyMember object with test data
            var member = new FamilyMember
            {
                Name = "Test User",
                FamilyRoleId = 1,
                Role = "Parent",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                DateOfBirth = new DateTime(1990, 1, 1),
                FamilySubRoleId = 2
            };

            // Add it to the database and commit the changes
            context.FamilyMembers.Add(member);
            await context.SaveChangesAsync();

            // Retrieve the inserted member to confirm it was saved
            var result = await context.FamilyMembers.FirstOrDefaultAsync(f => f.Name == "Test User");

            // Check each field to make sure the data was saved correctly
            Assert.NotNull(result);
            Assert.Equal("Test User", result.Name);
            Assert.Equal(1, result.FamilyRoleId);
            Assert.Equal("Parent", result.Role);
            Assert.Equal("test@example.com", result.Email);
            Assert.Equal("1234567890", result.PhoneNumber);
            Assert.Equal(new DateTime(1990, 1, 1), result.DateOfBirth);
            Assert.Equal(2, result.FamilySubRoleId);
        }


    }
}
