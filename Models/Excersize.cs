using System.ComponentModel;

namespace BeFit.Models;

public class Excersize
{
    public int Id { get; set; }
    public int Weight { get; set; }
    public int NumOfSeries { get; set; }
    public int NumOfReps { get; set; }
    public int ExcersizeTypeId { get; set; }
    public virtual ExcersizeType? ExcersizeType { get; set; }
    public int SessionId { get; set; }
    public virtual Session? Session { get; set; }
}