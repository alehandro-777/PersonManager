namespace PersonManager.API
{
    using AutoMapper;
    using PersonManager.API.DTO;
    using PersonManager.Data.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO
            CreateMap<Person, PersonListDto>();
            CreateMap<Person, PersonDetailDto>();
            CreateMap<Anschrift, AnschriftDto>();
            CreateMap<Telefonverbindung, TelefonverbindungDto>();

            // DTO -> Entity
            CreateMap<PersonListDto, Person>();
            CreateMap<PersonDetailDto, Person>();
            CreateMap<AnschriftDto, Anschrift>();
            CreateMap<TelefonverbindungDto, Telefonverbindung>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }

}
