using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public  class AppLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
    }
}
