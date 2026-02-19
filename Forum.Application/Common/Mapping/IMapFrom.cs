namespace Forum.Application.Common.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(AutoMapper.Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
    public interface IMapFrom<T, K>
    {
        void Mapping(AutoMapper.Profile profile) => profile.CreateMap(typeof((T, K)), GetType());
    }
}
