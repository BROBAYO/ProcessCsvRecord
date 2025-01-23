using System.Threading.Tasks;
using FileProcessorDomain.Entities;

namespace FileProcessorDomain.Ports;

public interface IFileProcessorRepository
{
    Task AddCsvRecordsAsync(IEnumerable<CsvRecordEntity> records);
    Task<IEnumerable<CsvRecordEntity>> GetAllCsvRecordsAsync();
}
