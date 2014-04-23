using FluentNHibernate.Mapping;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Data.Repositories.Nh.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("People");
            Id(x => x.Id).Column("PersonId");
            Map(x => x.CityId);
            Map(x => x.Name);
            Map(x => x.BirthDay);
            Map(x => x.Notes);
            Map(x => x.RecordDate);
        }
    }
}
