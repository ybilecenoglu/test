using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    internal class Utilities
    {
        public List<T> BuildList<T>(params T[] values)
        {
            
            return new List<T>(values);
        }
    }
}
