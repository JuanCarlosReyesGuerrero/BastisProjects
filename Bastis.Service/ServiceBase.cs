using Bastis.Data.Context;
using Bastis.Data.Entities;
using Bastis.Repository;
using System;

namespace Bastis.Service
{
    public class ServiceBase : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();       

        private GenericRepository<State> stateRepository;
        private GenericRepository<City> cityRepository;

        public GenericRepository<State> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new GenericRepository<State>(context);
                }
                return stateRepository;
            }
        }

        public GenericRepository<City> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}