using Bastis.Data.Context;
using System;

namespace Bastis.Service
{
    public class ServiceBase : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        //private GenericRepository<AporteParafiscales> aporteParafiscalesRepository;

        //public GenericRepository<Zonas> ZonasRepository
        //{
        //    get
        //    {
        //        if (this.zonasRepository == null)
        //        {
        //            this.zonasRepository = new GenericRepository<Zonas>(context);
        //        }
        //        return zonasRepository;
        //    }
        //}



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