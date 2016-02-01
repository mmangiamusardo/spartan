using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartan.Data.Infrastructure;
using Spartan.Data.Repositories;
using Spartan.Domain;


namespace Spartan.Service
{
    public interface IGymService
    {
        IQueryable<Gym> GetAllGyms();
        PagedCollection<Gym> GetPagedGyms(int? page, int? pageSize);
        void CreateGym(Gym gym);
    }

    public class GymService : IGymService
    {
        private readonly IGymRepository gymRepository;
        private readonly IUnitOfWork unitOfWork;

        public GymService(IGymRepository gymRepository, IUnitOfWork unitOfWork)
        {
            this.gymRepository = gymRepository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Gym> GetAllGyms()
        {
            return gymRepository.GetAll();
        }

        public PagedCollection<Gym> GetPagedGyms(int? page, int? pageSize)
        {
            var currPage = page.GetValueOrDefault(0);
            var currPageSize = pageSize.HasValue && pageSize.Value > 0 ? pageSize.Value : 10;

            var paged = gymRepository.GetAll().OrderBy(g => g.Name).Skip(currPage * currPageSize)
                                .Take(currPageSize)
                                .ToArray();

            var totalCount = gymRepository.GetAll().Count();

            return new PagedCollection<Gym>()
            {
                Page = currPage,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / currPageSize),
                Items = paged
            };
        }

        public void CreateGym(Gym gym)
        {
            gymRepository.Add(gym);
            unitOfWork.Commit();
        }
    }
}