using System.ComponentModel.DataAnnotations;

namespace RoleRightApp.RequestModels
{
    public class RequestRequestModel
    {
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
