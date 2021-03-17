namespace apiDoble.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Random
    {
        [Key]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public int random { get; set; }
    }
}
