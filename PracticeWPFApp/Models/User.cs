using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
    }
}
