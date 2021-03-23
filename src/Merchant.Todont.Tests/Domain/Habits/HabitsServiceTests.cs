using System;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Domain.Habits;
using Moq;
using Xunit;

namespace Merchant.Todont.Tests.Domain.Habits
{
    public class HabitsServiceTests
    {
        [Fact]
        public async Task ItCalculatesStreaks()
        {
            var habitId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var repository = new Mock<IHabitsRepository>();
            repository.Setup(z => z.LoadByUserId(It.Is<Guid>(y => y == userId))).ReturnsAsync(new[]
            {
                new Habit
                {
                    Id = habitId,
                    UserId = userId,
                    Name = "Bad Habit",
                    Created = new DateTimeOffset(new DateTime(2021, 01, 01)),
                    Entries = new []
                    {
                        // 01 - 02 ( 2 days )
                        new HabitEntry(Guid.NewGuid(), habitId, new DateTimeOffset(new DateTime(2021, 01, 03)), ""),
                        // 03 - 04 ( 2 days )
                        new HabitEntry(Guid.NewGuid(), habitId, new DateTimeOffset(new DateTime(2021, 01, 05)), ""),
                        // 04 - 09 ( 5 days )
                        new HabitEntry(Guid.NewGuid(), habitId, new DateTimeOffset(new DateTime(2021, 01, 10)), ""),
                        // 11 - now 
                    }
                }
            });
            var service = new HabitsService(repository.Object);
            var habits = await service.GetHabitsByUserId(userId);
            var habit = habits.Single();
            Assert.Equal(2, habit.Streaks[0].Days);
            Assert.Equal(2, habit.Streaks[1].Days);
            Assert.Equal(5, habit.Streaks[2].Days);
            Assert.Equal(4, habit.Streaks.Count);
            Assert.Equal(DateTime.Today, habit.Streaks[3].ToDate); 
        }
    }
}