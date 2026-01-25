using ASP_app.Business.Types;
using ASP_app.Models;
using AutoMapper;

namespace ASP_app.Config.Mapper;

public class AppMapperProfile : Profile
{
  public AppMapperProfile()
  {
    CreateMap<Blog, BlogData>().ReverseMap();

    CreateMap<Comment, CommentData>().ReverseMap();
  }
}