using FluentNHibernate.Mapping;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Data.Repositories.Nh.Mappings
{
    public class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            Table("Phones");
            Id(x => x.Id).Column("PhoneId");
            Map(x => x.PersonId);
            Map(x => x.Type).CustomType<PhoneType>();
            Map(x => x.Number);
            Map(x => x.RecordDate);
        }
    }
}