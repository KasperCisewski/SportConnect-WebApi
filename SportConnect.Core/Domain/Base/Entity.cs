using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportConnect.Core.Domain.Base
{
    public abstract class Entity<TPrimaryKey>
    {
        [Column(Order = 0)]
        public virtual TPrimaryKey Id { get; set; }

        [Column(Order = 1)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
    }
}
