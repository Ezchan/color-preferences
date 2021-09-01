using System.ComponentModel.DataAnnotations.Schema;

namespace colors.Models
{
    [NotMapped]
    public class StatsResult
    {
      public string Color { get; set; }
      public int color_count { get; set; }
      public int filter { get; set; }
  
    }
}