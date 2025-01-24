import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class CsvRecordsService {

  private apiUrl = 'http://localhost:5000/api/csvrecords';  //Ajustar segun la URL del localhost

  constructor() { }

  // Método para subir el archivo CSV
  async uploadCsv(file: FormData) {
    try {
      const response = await axios.post(`${this.apiUrl}/upload`, file, {
        headers: {
          'Content-Type': 'multipart/form-data',
        }
      });
      return response.data;
    } catch (error) {
      console.error('Error al subir el archivo CSV', error);
      throw error;
    }
  }

  // Método para obtener los registros de la base de datos
  async getRecords() {
    try {
      const response = await axios.get(this.apiUrl);
      return response.data;
    } catch (error) {
      console.error('Error al obtener los registros', error);
      throw error;
    }
  }
}
