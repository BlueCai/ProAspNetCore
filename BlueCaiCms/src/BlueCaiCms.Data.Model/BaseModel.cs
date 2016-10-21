using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime? EditTime { get; set; }

        public DateTime? RemoveTime { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
