namespace ExerciseTrackerUI.Models;

internal class Exercise
{
  public int Id { get; set; }
  public string Name { get; set; } = "Exercise";
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public TimeSpan Duration => EndDate - StartDate;
  public string? Comments { get; set; }
}
