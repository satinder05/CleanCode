using System;
using Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ProductDbContext _context;

        public CommandTestBase()
        {
            _context = ProductDbContextFactory.Create();
        }

        public void Dispose()
        {
            ProductDbContextFactory.Destroy(_context);
        }
    }
}
