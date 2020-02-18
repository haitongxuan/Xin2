using System;
using System.ComponentModel.DataAnnotations;

namespace Xin.Repository
{
    [Serializable]
    public class Entity<TKey>:IComparable<Entity<TKey>> where TKey: IComparable
    {
        [Key]
        public TKey Id { get; set; }

        public int CompareTo(Entity<TKey> other)
        {
            if (other == null)
                return -1;
            return Id.CompareTo(other.Id);
        }
    }
}
