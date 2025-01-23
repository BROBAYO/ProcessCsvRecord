using FileProcessorApplication.UsesCases;
using FileProcessorDomain.Entities;
using FileProcessorDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileProcessorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CsvRecordsController : ControllerBase
{
    private readonly FileRecord _useCase;

    public CsvRecordsController(FileRecord useCase)
    {
        _useCase = useCase;
    }

    /// <summary>
    /// Uploads and processes a CSV file.
    /// </summary>
    /// <param name="file">The CSV file to upload.</param>
    /// <returns>Response with status and details of the file processing result.</returns>
    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(new ResponseBase<string>(400, "No se cargo ningun archivo", string.Empty));
        }

        var records = new List<CsvRecordEntity>();

        try
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var header = await stream.ReadLineAsync();
                if (string.IsNullOrEmpty(header))
                {
                    return BadRequest(new ResponseBase<string>(400, "El archivo esta vacio o esta corrupto.", string.Empty));
                }

                string? line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var columns = line.Split(',');

                    var record = new CsvRecordEntity
                    {
                        Name = columns.Length > 0 ? columns[0].Trim() : null,
                        LastName = columns.Length > 1 ? columns[1].Trim() : null,
                        Phone = columns.Length > 2 ? columns[2].Trim() : null,
                    };

                    records.Add(record);
                }
            }

            await _useCase.ProcessCsvRecordsAsync(records);

            return Ok(new ResponseBase<int>(200, "Archivo procesado correctamente.", records.Count));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseBase<string>(500, "Error inesperado en el sistema.", ex.Message));
        }
    }

    /// <summary>
    /// Gets all CSV records stored in the system.
    /// </summary>
    /// <returns>A list of CSV records.</returns>
    [HttpGet]
    public async Task<IActionResult> GetRecords()
    {
        try
        {
            var records = await _useCase.GetCsvRecordsAsync();
            return Ok(new ResponseBase<List<CsvRecordEntity>>(200, "Registros encontrados.", (List<CsvRecordEntity>)records));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseBase<string>(500, "Error inesperado en el sistema.", ex.Message));
        }
    }
}