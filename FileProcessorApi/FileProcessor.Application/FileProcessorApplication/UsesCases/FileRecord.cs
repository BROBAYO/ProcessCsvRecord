using FileProcessorDomain.Entities;
using FileProcessorDomain.Ports;

namespace FileProcessorApplication.UsesCases;

public class FileRecord
{
    private readonly IFileProcessorRepository _repository;

    public FileRecord(IFileProcessorRepository repository)
    {
        _repository = repository;
    }

    public async Task ProcessCsvRecordsAsync(IEnumerable<CsvRecordEntity> records)
    {
        await _repository.AddCsvRecordsAsync(records);
    }

    public async Task<IEnumerable<CsvRecordEntity>> GetCsvRecordsAsync()
    {
        return await _repository.GetAllCsvRecordsAsync();
    }
}
