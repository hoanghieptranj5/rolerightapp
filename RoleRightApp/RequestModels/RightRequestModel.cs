using System.ComponentModel.DataAnnotations;

namespace RoleRightApp.RequestModels
{
    public class RightRequestModel
    {
        [Required]
        public string Description { get; set; }
    }
}
