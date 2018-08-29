using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class AppLockViewModel
    {
        public string Nome { get; set; }
        public IEnumerable<ItemViewModel> Items { get; set; }
    }

    public class ItemViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Hora { get; set; }
        public DateTime? Data { get; set; }
        public string DataString { get; set; }
        public string E1 { get; set; }
        public string S1 { get; set; }
        public string E2 { get; set; }
        public string S2 { get; set; }
    }
}