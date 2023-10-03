using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.Models
{
    public class Cities
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
