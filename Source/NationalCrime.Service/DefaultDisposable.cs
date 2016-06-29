using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCrime.Dal;

namespace NationalCrime.Service
{
    public abstract class DefaultDisposable
    {
        protected readonly NationalCrimeDataContext context;

        private bool _disposed;
        private readonly object _disposeLock = new object();

        protected DefaultDisposable()
        {
            context = new NationalCrimeDataContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
    }
}