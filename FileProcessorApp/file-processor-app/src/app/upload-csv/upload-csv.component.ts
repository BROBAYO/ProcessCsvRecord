import { Component, OnInit } from '@angular/core';
import { CsvRecordsService } from '../csv-records.service';

@Component({
  selector: 'app-upload-csv',
  templateUrl: './upload-csv.component.html',
  styleUrls: ['./upload-csv.component.css']
})
export class UploadCsvComponent implements OnInit {
  selectedFile: File | null = null;
  records: any[] = [];
  message: string = '';

  constructor(private csvRecordsService: CsvRecordsService) {}

  ngOnInit(): void {
    this.loadRecords();
  }

  async loadRecords() {
    try {
      this.records = await this.csvRecordsService.getRecords();
    } catch (error) {
      this.message = 'Error al cargar los registros';
    }
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  async onUpload() {
    if (!this.selectedFile) {
      this.message = 'Por favor selecciona un archivo CSV';
      return;
    }

    const formData = new FormData();
    formData.append('file', this.selectedFile);

    try {
      const result = await this.csvRecordsService.uploadCsv(formData);
      this.message = result.Message;
      this.loadRecords();
    } catch (error) {
      this.message = 'Error al subir el archivo CSV';
    }
  }
}