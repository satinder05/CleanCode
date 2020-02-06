using Persistence;
using System;
using AutoMapper;
using Application.Common.Mappings;

namespace Application.UnitTests.Common
{
    public class QueryTestBase : IDisposable
    {
        protected readonly ProductDbContext _context;
        protected readonly IMapper _mapper;

        public QueryTestBase()
        {
            _context = ProductDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ProductDbContextFactory.Destroy(_context);
        }
    }
}
