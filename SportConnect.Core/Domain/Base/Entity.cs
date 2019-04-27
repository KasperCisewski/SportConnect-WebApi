using System;

namespace SportConnect.Core.Domain.Base
{
    public abstract class Entity<TPrimaryKey>
    {
        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 0)]
        public virtual TPrimaryKey Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 1)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
    }
}
