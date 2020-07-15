using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_JOB_ENTITY.Models
{
    public class JobEntity
    {
        [Key]
        public Guid Job { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string JobTitle { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        //[DefaultValue(typeof(DateTime),"")]
        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiresdAt { get; set; }
    }
}
