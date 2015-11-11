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
        IList<Gym> GetAllGyms();
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

        public IList<Gym> GetAllGyms()
        {
            return gymRepository.GetAll();
        }

        public void CreateGym(Gym gym)
        {
            gymRepository.Add(gym);
            unitOfWork.Commit();
        }
    }
}