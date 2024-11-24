using System.ComponentModel;

namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class CreateEstimationSystemDto
    {
        public string Name { get; set; }

        [Description("Values seperated by comma")]
        public string Values { get; set; }
    }
}
