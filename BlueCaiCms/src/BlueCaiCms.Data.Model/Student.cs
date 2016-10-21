using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Model
{
    public class Student : BaseModel
    {
        public string Name { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public Class Class { get; set; }
    }
}
