using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyApi.Model
{
    public class UdemyRootModel<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public T results { get; set; }
    }
}
