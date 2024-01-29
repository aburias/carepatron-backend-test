using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common
{
    public class Response<T>
    {
        public bool IsSuccessful { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
