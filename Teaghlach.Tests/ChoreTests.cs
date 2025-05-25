using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Teaghlach.Data;
using Teaghlach.Models;

namespace Teaghlach.Tests
{
    public class ChoreTests
    {
        // This helper method sets up a fresh in-memory database for each test
        private TeaghlachContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TeaghlachContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new TeaghlachContext(options);
        }

        [Fact]
        public async Task AddChore_SavesToDatabase()
        {
            // Set up a new in-memory DB context
            using var context = GetInMemoryDbContext();

            // Create a new Chore object with test data
            var chore = new Chore
            {
                Type = ChoreType.EmptyDishwasher,
                AssignedToId = 1,
                DueDate = new DateTime(2025, 6, 6),
            };

            // Add it to the database and commit the changes
            context.Chores.Add(chore);
            await context.SaveChangesAsync();

            // Retrieve the inserted chore to confirm it was saved
            var result = await context.Chores.FirstOrDefaultAsync(f => f.Type == ChoreType.EmptyDishwasher);

            // Check each field to make sure the data was saved correctly
            Assert.NotNull(result);
            Assert.Equal(ChoreType.EmptyDishwasher, result.Type);
            Assert.Equal(1, result.AssignedToId);
            Assert.Equal(new DateTime(2025, 6, 6), result.DueDate);
        }

        [Fact]
        public void MissingAssignedToId_ShouldFailValidation()
        {
            // Set up a Chore without an AssignedToId (should fail if it's marked as required)
            var chore = new Chore
            {
                Type = ChoreType.Vaccuuming,
                DueDate = DateTime.Today,
                AssignedToId = null // Leaving this out to trigger validation failure
            };

            // Use shared validation helper to check for any issues
            var (isValid, validationResults) = ValidateModel(chore);

            // Make sure the validation fails and AssignedToId is one of the flagged fields
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("AssignedToId"));
        }


        [Fact]
        public void DueDate_BeforeCreatedAt_ShouldFailValidation()
        {
            // Create a new chore where the due date is before the created date
            // This should trigger a validation failure because of the logic in IValidatableObject
            var chore = new Chore
            {
                Type = ChoreType.CleanBedroom,
                CreatedAt = DateTime.Today,
                DueDate = DateTime.Today.AddDays(-1), // invalid: due date is earlier than created date
                AssignedToId = 1
            };

            // Validate using helper
            var (isValid, results) = ValidateModel(chore);

            // Should fail because of the invalid date combination
            Assert.False(isValid);
        }

        private static (bool IsValid, List<ValidationResult> Results) ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return (isValid, results);
        }
    }
}
