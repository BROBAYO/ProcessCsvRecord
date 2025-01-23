using FileProcessorDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileProcessorInfrastructure.Context
{
    public class RecordsDbContext : DbContext
    {
        public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        public DbSet<CsvRecordEntity> CsvRecords { get; set; }
    }
}
