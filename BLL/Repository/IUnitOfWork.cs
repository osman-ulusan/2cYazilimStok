using DAL.Context;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }

    public class UnitOfWork
        : IUnitOfWork
    {
        private Context2c _context = new Context2c();
        private Repository<Trademark> _trademarkRepository;
        private Repository<Product> _productRepository;
        private bool _disposed = false;
        public Repository<Trademark> TrademarkRepository
        {
            get
            {
                if (_trademarkRepository == null)
                    _trademarkRepository = new Repository<Trademark>(_context);
                return _trademarkRepository;
            }
        }
        public Repository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new Repository<Product>(_context);
                return _productRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
