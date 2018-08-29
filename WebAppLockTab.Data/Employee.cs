using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    [Table("Employee")]
    public class Employee : Person
    {
        public string Funcao { get; set; }

        public virtual Person Person { get; set; }
    }
}
