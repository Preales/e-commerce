using System;

namespace Ecommerce.Infrastructure.Entities.Base
{
    public abstract class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }       
    }

    public abstract class BaseEntity
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
    }
}