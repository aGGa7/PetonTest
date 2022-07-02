using Service.Context;
using Service.Interface;
using Service.Models;
using System;

namespace Service.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _dataContext { get; }
        private IGenericRepository<Project> projectRepository;
        private IGenericRepository<ProjectObject> objectRepository;
        public UnitOfWork(DataContext context)
        {
            this._dataContext = context;
        }

        public IGenericRepository<Project> Projects
        {
            get
            {

                if (this.projectRepository == null)
                {
                    this.projectRepository = new GenericRepository<Project>(_dataContext);
                }
                return projectRepository;
            }
        }

        public IGenericRepository<ProjectObject> ProjectRepository
        {
            get
            {

                if (this.objectRepository == null)
                {
                    this.objectRepository = new GenericRepository<ProjectObject>(_dataContext);
                }
                return objectRepository;
            }
        }
        public void Save()
        {
            _dataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
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
