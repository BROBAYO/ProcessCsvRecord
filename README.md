# ProcessCsvRecord
This project is created in order to present the technical test for Software Developer

## Descripción
Esta aplicación permite:
- Subir archivos CSV desde la interfaz web.
- Guardar los registros del archivo en una base de datos SQL Server.
- Consultar y visualizar los registros almacenados desde la web app.

## Tecnologías Utilizadas
- **Frontend**: Angular //Ajustar el apuntamiento del api en el archivo csv-records.service
- **Backend**: .NET Core (C#) //Configurar las credenciales de la base de datos en la cual se va ejecutar el script de la tabla en appsettings.json revisar que el llamado a la conexción este bien configurado en Program.cs
- **Base de Datos**: SQL Server

## Instalación y Configuración

### 1. Clonar el repositorio rama develop
```bash
git clone https://github.com/BROBAYO/ProcessCsvRecord.git
cd csv-processor-app