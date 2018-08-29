using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    [Table("ScheduleDay")]
    public class ScheduleDay
    {
        [Key]
        public int ScheduleDayId { get; set; }
        public DateTime Data { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
