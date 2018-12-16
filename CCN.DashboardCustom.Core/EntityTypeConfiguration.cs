using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom
{
    public abstract class AbsEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        protected AbsEntityTypeConfiguration()
        {
            this.HasKey(_ => _.Id);
            this.Property(_ => _.Id).HasColumnName("id").IsRequired();
            this.Property(_ => _.CreationTime).HasColumnName("createtime").IsRequired();
            this.Property(_ => _.LastModificationTime).HasColumnName("updatetime").IsRequired();
            this.Property(_ => _.IsDeleted).HasColumnName("isdelete").IsRequired();
        }
    }
}
