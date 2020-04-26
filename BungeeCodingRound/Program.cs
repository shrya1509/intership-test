using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungeeCodingRound
{
    class Program
    {
        static void Main(string[] args)
        {
            //Please remove any special/junk characters from sheet.
            string inputfilepath = "E:\\Interview Problem Statements\\intership-test-master\\intership-test-master\\BungeeCodingRound\\BungeeCodingRound\\input\\main.csv";
            
            //Problem statement 1
            List<Entities> lstcontent = FilterRecordHelper.ReadCSV(inputfilepath);

            var getrecordwithusadata = lstcontent.Where(a => a.COUNTRY.Contains("USA")).ToList();
            
            string outputfilepath = "E:\\Interview Problem Statements\\intership-test-master\\intership-test-master\\BungeeCodingRound\\BungeeCodingRound\\output\\filteredCountry.csv";
            

            FilterRecordHelper.WriteFile(getrecordwithusadata,outputfilepath);

            //Problem statement 2


            //finalgroupedcollection contains grouped record with 2 lowest price
            var finalgroupedcollection = getrecordwithusadata.GroupBy(a => a.SKU)
                .SelectMany(b => b.OrderBy(c => Convert.ToDouble(c.PRICE.Trim()
                    .Replace("$", "")
                    .Replace("?", "")
                    .Replace(",", ""))).Take(2)).ToList();

            string outputfilefinalpath = "E:\\Interview Problem Statements\\intership-test-master\\intership-test-master\\BungeeCodingRound\\BungeeCodingRound\\output\\lowestPrice.csv";

            List<Lowest> lstLowest = new List<Lowest>();

            string previousSKU=string.Empty;
            string currentSKU=string.Empty;

            string minprice = string.Empty;
           

            foreach (var item in  finalgroupedcollection)
            {

                if (string.IsNullOrEmpty(previousSKU))
                {
                    //first time entry
                    previousSKU = item.SKU;
                    minprice = item.PRICE;
                    
                }
                else
                {
                    //Second time entry
                    currentSKU = item.SKU;
                    if (previousSKU == currentSKU)
                    {
                        Lowest obj = new Lowest();
                        obj.SKU = item.SKU;
                        obj.FIRST_MINIMUM_PRICE = minprice;
                        obj.SECOND_MINIMUM_PRICE = item.PRICE;

                        lstLowest.Add(obj);
                    }
                    previousSKU = currentSKU;
                    minprice = item.PRICE;
                    
                }
                    
            }


            FilterRecordHelper.WriteFileFinal(lstLowest, outputfilefinalpath);

           
            
        }
    }
}
