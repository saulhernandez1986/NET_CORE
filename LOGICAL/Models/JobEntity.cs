using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOGIC.Models
{
    public class JobEntity
    {

        [Key]
        public Guid Job { get; set; }


        public string JobTitle { get; set; }


        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }


        public DateTime ExpiresdAt { get; set; }
    }

}

    

