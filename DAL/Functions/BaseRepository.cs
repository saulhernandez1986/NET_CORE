using AutoMapper;

namespace DAL.Functions
{
    public abstract class BaseRepository
    {
        protected readonly IMapper mapper;
        public BaseRepository(IMapper mapperImpl)
        {
            mapper = mapperImpl;
        }
    }

}
