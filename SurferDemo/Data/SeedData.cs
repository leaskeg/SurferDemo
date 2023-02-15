﻿using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SurferDemo.Models;

namespace SurferDemo.Data
{
    public class SeedData
    {
        private const string FILE_PATH = "Data/Datasheet.xlsx";

        public static void GetDataFromExcel(IServiceProvider serviceProvider)
        {
            var boards = new List<Board>();
            FileInfo existingFile = new FileInfo(FILE_PATH);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet boardWorksheet = package.Workbook.Worksheets[1];
                int rowCount = boardWorksheet.Dimension.End.Row;
                for (int row = 2; row <= rowCount; row++)
                {
                    var name = boardWorksheet.Cells[row, 1].Value?.ToString().Trim();
                    var length = boardWorksheet.Cells[row, 2].Value?.ToString().Trim();
                    var width = boardWorksheet.Cells[row, 3].Value?.ToString().Trim();
                    var thickness = boardWorksheet.Cells[row, 4].Value?.ToString().Trim();
                    var volume = boardWorksheet.Cells[row, 5].Value?.ToString().Trim();
                    var type = boardWorksheet.Cells[row, 6].Value?.ToString().Trim();
                    var price = boardWorksheet.Cells[row, 7].Value?.ToString().Trim();
                    var equipment = boardWorksheet.Cells[row, 8].Value?.ToString().Trim();

                    var board = new Board
                    {
                        Name = name,
                        Length = double.TryParse(length, out double resultLength) ? resultLength : null,
                        Width = double.TryParse(width, out double resultWidth) ? resultWidth : null,
                        Thickness = double.TryParse(thickness, out double resultThickness) ? resultThickness : null,
                        Volume = double.TryParse(volume, out double resultVolume) ? resultVolume : null,
                        Type = type,
                        Price = decimal.TryParse(price, out decimal resultPrice) ? resultPrice : null,
                        Equipment = equipment
                    };
                    boards.Add(board);
                }
            }

            using (var context = new SurferDemoContext(serviceProvider.GetRequiredService<DbContextOptions<SurferDemoContext>>()))
            {
                if (context.Board.Any()) { return; }
                foreach (var board in boards)
                {
                    context.Add(board);
                }
                context.SaveChanges();
            }
        }
    }
}
