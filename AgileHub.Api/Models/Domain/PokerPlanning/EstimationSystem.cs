using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.Domain.PokerPlanning
{
    public class EstimationSystem
    {
        public EstimationSystem()
        {
            Values = [];
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}
