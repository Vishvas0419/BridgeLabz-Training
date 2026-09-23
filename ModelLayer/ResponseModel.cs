using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class ResponseModel<T>
    {
        public bool success { get; set; } = true;
        public string Message { get; set; } = "";
        public T data { get; set; } = default(T);
    }
}
