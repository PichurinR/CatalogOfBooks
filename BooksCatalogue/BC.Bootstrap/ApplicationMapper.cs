using AutoMapper;

namespace BC.Bootstrap
{
    public static class ApplicationMapper
    {
        public static void Init()
        {
            Mapper.Initialize((mapper) =>
            {
                //TODO This Will be Mapping
                //mapper.CreateMap<SomeClass, SomeClassTwo>();
            });
        }
    }
}
