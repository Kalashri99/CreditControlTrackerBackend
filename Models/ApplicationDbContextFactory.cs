using Microsoft.EntityFrameworkCore;

namespace CreditContolTrackerAPIs.Models
{

        public class ApplicationDbContextFactory
        {
            private readonly DbContextOptions<ApplicationDbContext> _options;

            public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
            {
                _options = options;
            }

            public ApplicationDbContext Create()
            {
                return new ApplicationDbContext(_options);
            }
        }

    
}
