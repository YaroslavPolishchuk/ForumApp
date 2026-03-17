using Forum.Application.Common.Mapping;
using Forum.Domain.Entities;

namespace Forum.Application.Forums.Models
{
    public class BoardListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Answers { get; set; }
        public string Description { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Board, BoardListDto>()
        //        .ForMember(a => a.Id, opt => opt.MapFrom(x => x.Id))
        //        .ForMember(a => a.Title, opt => opt.MapFrom(x => x.Title))
        //        .ForMember(a => a.Answers, opt => opt.MapFrom(x => x.Answers))
        //        .ForMember(a => a.Description, opt => opt.MapFrom(x => x.Description));
        //}
    }
}
