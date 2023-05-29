using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Entities.Concrete
{
    public class AppErrorLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string Target { get; set; }
        public DateTime? Date { get; set; }
    }
}
