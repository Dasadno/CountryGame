using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryGame
{
    public class main
    {
        static public void Main(string[] args)
        {
            DataCollector collector = new DataCollector(true);
            
            Game game = new Game(5);
            List<string> list = new List<string>();
            list = collector.GetCountryList();

        }
    }
}
