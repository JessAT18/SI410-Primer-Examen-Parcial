namespace fncPar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Random
    {
        [Key]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }
        [Required]
        public int random { get; set; }
    }
}
