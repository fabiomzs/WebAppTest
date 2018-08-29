using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Nome { get; set; }
    }
}
