using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DevHabit.Api.Controllers;

[ApiController]
[Route("habits")]
public class HabitsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<HabitDto>> GetHabits()
    {
        List<Habit> habits = await dbContext.Habits.ToListAsync();

        var habitsCollectionDto = new HabitsCollectionDto
        {
            Data = habits.Select(habit => new HabitDto
            {
                Id = habit.Id,
                Name = habit.Name,
                Description = habit.Description,
                Type = habit.Type,
                Frequency = new FrequencyDto
                {
                    Type = habit.Frequency.Type,
                    TimesPerPeriod = habit.Frequency.TimesPerPeriod
                },
                Target = new TargetDto
                {
                    Value = habit.Target.Value,
                    Unit = habit.Target.Unit
                },
                Status = habit.Status,
                IsArchived = habit.IsArchived,
                EndDate = habit.EndDate,
                Milestone = habit.Milestone == null ? null : new MilestoneDto
                {
                    Current = habit.Milestone.Current,
                    Target = habit.Milestone.Target,
                },
                CreatedAtUtc = habit.CreatedAtUtc,
                UpdatedAtUtc = habit.UpdatedAtUtc,
                LastCompletedAtUtc = habit.LastCompletedAtUtc
            }).ToList()
        };

        return Ok(habitsCollectionDto);

    }


}
