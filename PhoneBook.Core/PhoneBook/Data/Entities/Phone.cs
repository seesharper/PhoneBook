using System;

namespace Hik.PhoneBook.Data.Entities
{
    public class Phone : Entity<int>
    {
        public virtual int PersonId { get; set; }

        public virtual PhoneType Type { get; set; }

        public virtual string Number { get; set; }

        public virtual DateTime RecordDate { get; set; }

        public Phone()
        {
            RecordDate = DateTime.Now;
        }
    }
}