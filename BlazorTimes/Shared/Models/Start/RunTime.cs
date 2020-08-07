using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BlazorTimes.Shared.Models.Start
{
    public class RunTime
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="{0} length must be less or equal to {1}!")]
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime Time { get; set; }
    }
}
