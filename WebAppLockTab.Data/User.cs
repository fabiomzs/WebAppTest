﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    [Table("User")]
    public class User : Person
    {
        public string Email { get; set; }
        public virtual Person Person { get; set; }
    }
}
