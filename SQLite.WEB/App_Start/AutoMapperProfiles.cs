using AutoMapper;
using SQLite.DAL.DomainModels;
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
            Mapper.CreateMap<ByName, ByNameViewModel>();
            Mapper.CreateMap<Place, PlaceViewModel>();
            Mapper.CreateMap<Event, EventViewModel>();
            Mapper.CreateMap<EventType, EventTypeViewModel>();
        }
    }

    public class ViewToDomainModelMappingProfile : Profile
    {
        public override string ProfileName => "ViewToDomainModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<PersonViewModel, Person>();
            Mapper.CreateMap<ByNameViewModel, ByName>();
            Mapper.CreateMap<PlaceViewModel, Place>();
            Mapper.CreateMap<EventViewModel, Event>();
            Mapper.CreateMap<EventTypeViewModel, EventType>();
        }
    }

}