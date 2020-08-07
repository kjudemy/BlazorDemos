using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BlazorTimes.Shared.Models.Service
{
    public class RunTime
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="{0} length must be less or equal to {1}!")]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public DateTime Time { get; set; }
    }
}
