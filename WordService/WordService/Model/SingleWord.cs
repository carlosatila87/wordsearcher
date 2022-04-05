using System.ComponentModel.DataAnnotations;

namespace WordService.Model
{
    public class SingleWord
    {
        [Key]
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
