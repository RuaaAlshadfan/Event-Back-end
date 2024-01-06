using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AuditModel
{
    public class AuditModelClass
    {
        public virtual int CreaterUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual int UpdateUserId { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int? DeletedUserId { get; set; }
    }
}
