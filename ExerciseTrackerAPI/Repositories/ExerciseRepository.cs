using ExerciseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerAPI.Repositories;

public class ExerciseRepository : IExerciseRepository
{
  private readonly ExercisesContext _context;

  public ExerciseRepository(ExercisesContext context)
  {
    _context = context;
  }

  public async Task AddExercise(Exercise exercise)
  {
    await _context.Exercises.AddAsync(exercise);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteExercise(Exercise exercise)
  {
    _context.Exercises.Remove(exercise);
    await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Exercise>> GetAllExercises()
  {
    return await _context.Exercises.ToListAsync();
  }

  public async Task<Exercise?> GetExerciseById(int id)
  {
    return await _context.Exercises.FindAsync(id);
  }

  public async Task UpdateExercise(Exercise exercise)
  {
    _context.Exercises.Update(exercise);
    await _context.SaveChangesAsync();
  }
}
