using ExerciseTrackerAPI.Models;
using ExerciseTrackerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
  private readonly IExerciseRepository _exerciseRepository;
  public ExercisesController(IExerciseRepository exerciseRepository)
  {
    _exerciseRepository = exerciseRepository;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercises()
  {
    IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllExercises();
    if (exercises == null) return NotFound();
    return Ok(exercises);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Exercise?>> GetExerciseById(int id)
  {
    Exercise? exercise = await _exerciseRepository.GetExerciseById(id);
    if (exercise == null) return NotFound();
    return exercise;
  }

  [HttpPost]
  public async Task<ActionResult> AddExercise(Exercise exercise)
  {
    if (exercise == null) return BadRequest();
    await _exerciseRepository.AddExercise(exercise);
    return CreatedAtAction(nameof(AddExercise), exercise);
  }

  [HttpPut]
  public async Task<ActionResult> UpdateExercise(Exercise exercise)
  {
    if (exercise == null) return BadRequest();
    await _exerciseRepository.UpdateExercise(exercise);
    return NoContent();
  }

  [HttpDelete]
  public async Task<ActionResult> DeleteExercise(Exercise exercise)
  {
    if (exercise == null) return BadRequest();
    await _exerciseRepository.DeleteExercise(exercise);
    return NoContent();
  }
}
