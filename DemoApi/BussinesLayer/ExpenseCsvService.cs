﻿using CsvHelper;
using DemoApi.BussinesLayer.Interfaces;
using System.Globalization;

namespace DemoApi.BussinesLayer
{
    public class ExpenseCsvService: IExpenseCsv
    {
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
        public void WriteCSV<T>(List<T> records)
        {
            using (var writer = new StreamWriter("D:\\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

    }
}