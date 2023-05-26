using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete
{
    public class Result
    {
        public Result()
        {
            Messages= new List<string>();
        }
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> Messages { get; set; }

    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
