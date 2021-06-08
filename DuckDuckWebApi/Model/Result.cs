using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckDuckWebApi.Model
{
    public class Result<T>:List<T>
    {
        public string Exception { set; get; }
        public Result(IEnumerable<T> ls)
        {
            base.AddRange(ls);
        }
        public Result(string exception)
        {
            this.Exception = exception;
        }
    }
}
