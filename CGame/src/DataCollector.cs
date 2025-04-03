using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Policy;
using System.Collections;


namespace CountryGame
{
    public class DataCollector
    {
        public DataCollector(bool value)
        {
            if (value == true)
            {
                SaveCountries();
            }
        }
     
        public List<string> GetCountryList()
        {
            string path = "..\\..\\..\\res\\content.txt";
            var list = File.ReadAllLines(path).ToList();

            return list;
        } 
        public void SaveCountries()
        {
            string path = "..\\..\\..\\res\\content.txt";

            FileInfo fileInf = new FileInfo(path);

            if (!fileInf.Exists)
            {
                fileInf.Create();
                using (StreamWriter sw = new StreamWriter(path))
                {

                    foreach (string s in CountriesTitleList())
                    {
                        sw.WriteLine(s.ToLower());
                    }
                    sw.Close();
                }

            }
        }
        private static List<string> CountriesTitleList()
        {
            List<string> CultureList = new List<string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.Name);
                if(!(CultureList.Contains(GetRegionInfo.EnglishName)))
                {
                    CultureList.Add(GetRegionInfo.EnglishName);
                }
            }
            return CultureList;
        }

    }
}


