using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ServicesModel
    {
        public int Service_id { get; set; }
        public decimal Sum { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime Date_post { get; set; }
        public decimal Limit { get; set; }
    }
}
