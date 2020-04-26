using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace BungeeCodingRound
{
    class FilterRecordHelper
    {
        public static List<Entities> ReadCSV(string inputfilepath)
        {
            CsvContext cc = new CsvContext();

            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            List<Entities> lstcontent = cc.Read<Entities>(inputfilepath, inputFileDescription).ToList();

            //foreach (var item in lstcontent)
            //{
            //    var converteditem = Convert.ToDouble(item.PRICE.Trim().Replace("$","").Replace("?","").Replace(",",""));
            //    Console.WriteLine(converteditem);
            //}
          //var obj = lstcontent.Select(a => Convert.ToInt16(a.PRICE.Trim()));
            return lstcontent;
        }


        public static void  WriteFile(List<Entities> lstusfilteredRecord,string outputfilepath)
        {
            CsvContext cc = new CsvContext();

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',', // tab delimited
                FirstLineHasColumnNames = true, // no column names in first record
                //FileCultureName = "nl-NL" // use formats used in The Netherlands
            };

            cc.Write(lstusfilteredRecord, outputfilepath, outputFileDescription);
            
        }


        public static void WriteFileFinal(List<Lowest> lstusfilteredRecord, string outputfilepath)
        {
            CsvContext cc = new CsvContext();

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',', // tab delimited
                FirstLineHasColumnNames = true, // no column names in first record
                //FileCultureName = "nl-NL" // use formats used in The Netherlands
            };

            cc.Write(lstusfilteredRecord, outputfilepath, outputFileDescription);

        }


    }
}
