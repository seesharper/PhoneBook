using System;

namespace Hik.PhoneBook.Data.Entities
{
    public class Person : Entity<int>
    {
        public virtual int CityId { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime BirthDay { get; set; }

        public virtual string Notes { get; set; }

        public virtual DateTime RecordDate { get; set; }

        public Person()
        {
            Notes = "";
            RecordDate = DateTime.Now;
        }
    }
}
