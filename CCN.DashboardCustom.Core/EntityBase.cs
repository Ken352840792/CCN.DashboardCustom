using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom
{
    public class EntityBase : Entity<Guid>, IHasCreationTime, IHasModificationTime, ISoftDelete
    {
        public EntityBase()
        {
            IsDeleted = false;
            CreationTime = Clock.Now;
            LastModificationTime = CreationTime;
            Id = Guid.NewGuid();
        }
        [Column("CreateTime")]
        public   DateTime CreationTime { get; set; }
        [Column("ModifyTime")]
        public   DateTime? LastModificationTime { get; set; }
        [Column("Flag")]
        public   bool IsDeleted { get; set; }
    }
}
