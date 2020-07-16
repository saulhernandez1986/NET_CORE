using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Jobs
    {
        [Key]
        public Guid Job { get; set; }

        [Required]
        [DisplayName("Job Title")]
        [Column(TypeName = "nvarchar(50)")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Created At")]
        [Column(TypeName = "datetime")]
        //[DefaultValue(typeof(DateTime),"")]
        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DisplayName("Expires At")]
        [Column(TypeName = "datetime")]
        public DateTime ExpiresdAt { get; set; }
    }

}
