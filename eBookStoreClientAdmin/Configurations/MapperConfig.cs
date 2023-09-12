using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;

namespace eBookStoreClientAdmin.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
