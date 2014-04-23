using FluentNHibernate.Mapping;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Data.Repositories.Nh.Mappings
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("Cities");
            Id(x => x.Id).Column("CityId");
            Map(x => x.Name);
        }
    }
}