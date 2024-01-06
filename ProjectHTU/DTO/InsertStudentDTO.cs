using System.ComponentModel.DataAnnotations;

namespace ProjectHTU.DTO
{
    public class InsertStudentDTO
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string secondName { get; set; }
        [Required]
        public string thiredName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string major {  get; set; }

        public string roleIds { get; set; }
    }
}
