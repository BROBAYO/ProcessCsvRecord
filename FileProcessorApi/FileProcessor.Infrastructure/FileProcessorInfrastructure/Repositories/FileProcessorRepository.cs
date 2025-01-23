using FileProcessorDomain.Entities;
using FileProcessorDomain.Ports;
using FileProcessorInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FileProcessorInfrastructure.Repositories;

public class FileProcessorRepository : IFileProcessorRepository
{
    private readonly RecordsDbContext _dbContext;

    public FileProcessorRepository(RecordsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCsvRecordsAsync(IEnumerable<CsvRecordEntity> records)
    {
        await _dbContext.CsvRecords.AddRangeAsync(records);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CsvRecordEntity>> GetAllCsvRecordsAsync()
    {
        return await _dbContext.CsvRecords.ToListAsync();
    }
}
