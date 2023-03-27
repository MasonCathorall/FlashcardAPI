using System.ComponentModel.DataAnnotations;

namespace FlashcardsAPI.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string? Question { get; set; }

        public string? Answer { get; set; }
    }
}
