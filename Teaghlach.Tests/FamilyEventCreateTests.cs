using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Teaghlach.Data;
using Teaghlach.Models;
using Teaghlach.Pages.FamilyEvents;



namespace Teaghlach.Tests
{
    public class FamilyEventCreateTests : TestContext
    {
        public FamilyEventCreateTests()
        {
            // Set up an in-memory database for each test run so the data is isolated
            var options = new DbContextOptionsBuilder<TeaghlachContext>()
                .UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}")
                .Options;

            // Register a factory that gives us this in-memory context
            Services.AddSingleton<IDbContextFactory<TeaghlachContext>>(
                new TestDbContextFactory(options));

            // Swap out the real NavigationManager for a fake one we can inspect
            Services.AddSingleton<NavigationManager, FakeNavigationManager>();
        }

        [Fact]
        public async Task CreateForm_WhenAllInputsValid_NavigatesToCalendar()
        {
            // Get access to the context factory so I can pre-seed the database
            var dbFactory = Services.GetRequiredService<IDbContextFactory<TeaghlachContext>>();

            // Seed some minimal data that the form depends on
            await using (var context = dbFactory.CreateDbContext())
            {
                context.FamilyRoles.Add(new FamilyRole { Id = 1, Name = "Parent" });
                context.FamilyMembers.Add(new FamilyMember { Id = 1, Name = "Alice", FamilyRoleId = 1 });
                context.EventCategories.Add(new EventCategory { Id = 1, Name = "Birthday" });
                context.EventSubCategories.Add(new EventSubCategory { Id = 2, Name = "Party", EventCategoryId = 1 });

                await context.SaveChangesAsync(); // Needed before rendering the component
            }

            // Render the Create component (the Family Event form)
            var cut = RenderComponent<Create>();

            // Wait for the select inputs to populate before proceeding
            cut.WaitForAssertion(() =>
            {
                // Should have a default option + one real item in each dropdown
                Assert.Equal(2, cut.FindAll("#category option").Count);         // --Select-- + "Birthday"
                Assert.Single(cut.FindAll("#subcategory option"));             // Just --Select-- (Party doesn't load until category selected)
                Assert.Equal(2, cut.FindAll("#familymemberid option").Count);  // --Select-- + "Alice"
            }, timeout: TimeSpan.FromSeconds(10));

            // Simulate filling out the form with valid values
            cut.Find("#location").Change("Community Hall");
            cut.Find("#description").Change("Birthday Bash");
            cut.Find("#category").Change("1");
            cut.Find("#subcategory").Change("2");
            cut.Find("#familymemberid").Change("1");
            cut.Find("#start").Change(DateTime.Today.ToString("yyyy-MM-dd"));
            cut.Find("#startTime").Change("12:00:00");
            cut.Find("#end").Change(DateTime.Today.ToString("yyyy-MM-dd"));
            cut.Find("#endTime").Change("14:00:00");
            cut.Find("#text").Change("Bring gifts!");
            cut.Find("#allday").Change(false);

            // Submit the form
            cut.Find("form").Submit();

            // Check that navigation occurred to the expected URL
            var navManager = Services.GetRequiredService<NavigationManager>() as FakeNavigationManager;

            cut.WaitForAssertion(() =>
            {
                Assert.Contains("/calendar", navManager?.Uri);
            }, timeout: TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void CreateForm_WhenCategoryNotSelected_ShowsValidation()
        {
            // Get the DbContextFactory so I can seed minimal required data
            var dbFactory = Services.GetRequiredService<IDbContextFactory<TeaghlachContext>>();
            using var context = dbFactory.CreateDbContext();

            // Add a family member to make the form partially valid
            context.FamilyMembers.Add(new FamilyMember { Id = 1, Name = "Alice", FamilyRoleId = 1 });
            context.SaveChanges();

            // Render the Create component (no category or subcategory seeded)
            var cut = RenderComponent<Create>();

            // Fill out the required fields except for the category
            cut.Find("#familymemberid").Change("1");

            // Submit the form without selecting a category
            cut.Find("form").Submit();

            // Check that validation messages are shown (expecting a message for missing category)
            cut.WaitForAssertion(() =>
            {
                Assert.NotEmpty(cut.FindAll(".validation-message")); // Should show validation errors
            });
        }



        // Simple custom factory to give us DbContexts from the in-memory options
        class TestDbContextFactory : IDbContextFactory<TeaghlachContext>
        {
            private readonly DbContextOptions<TeaghlachContext> _opts;
            public TestDbContextFactory(DbContextOptions<TeaghlachContext> opts) => _opts = opts;
            public TeaghlachContext CreateDbContext() => new TeaghlachContext(_opts);
        }
    }
}
