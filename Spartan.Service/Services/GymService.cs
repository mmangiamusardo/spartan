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
    public interface IGymService : IDisposable
    {
        IQueryable<Gym> GetAllGyms();
        PagedCollection<Gym> GetPagedGyms(int? page, int? pageSize);
        void CreateGym(Gym gym);
    }

    public class GymService : IGymService, IDisposable
    {
        private IGymRepository gymRepository;
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    gymRepository = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GymService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion




    }
}