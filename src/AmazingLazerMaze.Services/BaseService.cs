using AutoMapper;
using JoelWynes.AmazingLazerMaze.Repository;

namespace JoelWynes.AmazingLazerMaze.Services
{
    public abstract class BaseService
    {
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
    }
}
