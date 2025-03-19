using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Models.Exception
{
    public class ApiException
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString() //when ToString is called, the object is taken and converted to Json
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
