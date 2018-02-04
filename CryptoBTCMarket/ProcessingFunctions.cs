using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CryptoBTCMarket
{
    class ProcessingFunctions
    {
        private static string RegexString;

        public static string[] ExtractData()
        {
            string RawTick = BTCFunctions.GetMarketTick();
            string[] TickString= new string[2];
            RegexString = "{\"([a-zA-Z]+)\":([-+]?[0-9]*.?[0-9]+),\"([a-zA-Z]+)\":([-+]?[0-9]*.?[0-9]+),\"([a-zA-Z]+)\":([-+]?[0-9]*.?[0-9]+),\"([a-zA-Z]+)\":\"([a-zA-Z]+)\",\"([a-zA-Z]+)\":\"([a-zA-Z]+)\",\"([a-zA-Z]+)\":([-+]?[0-9]*.?[0-9]+),\"([a-zA-Z0-9]+)\":([-+]?[0-9]*.?[0-9]+)}";

            var objRegex = new System.Text.RegularExpressions.Regex(RegexString);
            var objMatch = objRegex.Match(RawTick);

            if (objMatch.Success)
            {
                TickString[0]=objMatch.Groups[5].ToString();
                TickString[1]=objMatch.Groups[6].ToString();
            }
            return TickString;
        }

        public static DataTable DataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Title");
            table.Columns.Add("Price");
            return table;
        }

        public static DataTable AddRow(DataTable table, string[] tick)
        {
            table.Rows.Add(tick);
            return table;
        }

        public static void WiriteXMLData(DataTable Table)
        {
            DataSet DataSet = new DataSet();
            DataSet.Tables.Add(Table);
            DataSet.WriteXml(@"C:\Users\Win10Dev\Desktop\CryptoBTCMarket\Data\MyDataset.xml");

        }

        public static DataTable ReadXMLData()
        {
            DataSet DataSet = new DataSet();
            DataSet.ReadXml(@"C:\Users\Win10Dev\Desktop\CryptoBTCMarket\Data\MyDataset.xml");
            return DataSet.Tables[0];
        }
      
        

    }
}
