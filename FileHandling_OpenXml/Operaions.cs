using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FileHandling_OpenXml
{
    internal class Operaions : IOperaions
    {
        public void CreateFile(string direct)
        {
            string fileName = GetFileName();
            string path = Path.Combine(direct, fileName);


            if (File.Exists(path))
            {
                Console.WriteLine("File Already existed");
            }
            else
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
                {
                    // Add workbook part
                    WorkbookPart workbook = document.AddWorkbookPart();
                    workbook.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    // Add worksheet part
                    WorksheetPart worksheet = workbook.AddNewPart<WorksheetPart>();
                    worksheet.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(new SheetData());

                    // Add sheets container to workbook
                    Sheets sheets = workbook.Workbook.AppendChild(new Sheets());

                    // Add a sheet definition (link workbook to worksheet)
                    Sheet sheet = new Sheet()
                    {
                        Id = workbook.GetIdOfPart(worksheet),
                        SheetId = 1,
                        Name = "sheetTest"
                    };

                    sheets.Append(sheet);

                    // Save the workbook
                    workbook.Workbook.Save(); 
                }
            }
        }

        public void ReadFile(string direct)
        {
            string fileName = GetFileName();
            string path = Path.Combine(direct, fileName);



            //not fullfilled code start to--------------
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(path, true))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                foreach (Row row in sheetData.Elements<Row>())
                {
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        string cellValue = cell.CellValue.Text;
                        Console.WriteLine(cellValue);
                    }
                }
            } //-------------end



        }

        public void AppendFile(string direct)
        {

        }

        public void DeleteFile(string direct)
        {
            string fileName = GetFileName();
            string path = Path.Combine(direct, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("File deleted successfully.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
            }
        }


        public static string GetFileName()
        {
            string fileName;
            while (true)
            {
                Console.Write("Enter the file name: ");
                fileName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("File name cannot be emptt. Please try again.");
                    continue;
                }

                if (ContainsInvalidChars(fileName))
                {
                    Console.WriteLine("File name contains invalid characters. Please try again.");
                    continue;
                }

                break;
            }

            return fileName;
        }
        public static bool ContainsInvalidChars(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                if (fileName.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
