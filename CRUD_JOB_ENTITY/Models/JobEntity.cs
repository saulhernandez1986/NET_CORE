using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_JOB_ENTITY.Models
{
    public class JobEntityDTO
    {
        [Key]
        public Guid Job { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Created At")]
        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DisplayName("Expires At")]
        public DateTime ExpiresdAt { get; set; }
    }
}
