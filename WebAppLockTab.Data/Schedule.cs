using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string Descricao { get; set; }
        public virtual List<ScheduleDay> ScheduleDays { get; set; }

        public Schedule()
        {
            ScheduleDays = new List<ScheduleDay>();
        }
    }
}
