using AutoMapper;
using SQLite.DAL.Models;
using SQLite.WEB.Models;

namespace SQLite.WEB
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewToDomainModelMappingProfile>();
            });
        }
    }

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
        }
    }

    public class ViewToDomainModelMappingProfile : Profile
    {
        public override string ProfileName => "ViewToDomainModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<PersonViewModel, Person>();
        }
    }

}