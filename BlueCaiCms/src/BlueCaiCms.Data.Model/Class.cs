using BlueCaiCms.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Model
{
    public class Class : BaseModel
    {
        public string Name { get; set; }

        public Grade Grade { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
