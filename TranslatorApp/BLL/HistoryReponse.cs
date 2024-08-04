using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HistoryReponse
    {
        public int wordid { get; set; }
        public string originalword { get; set; }
        public string translatedword{ get; set; }
        public string fromlanguage { get; set; }
        public string tolanguage{ get; set; }
        public DateTime timesave{ get; set; }
        public int uid { get; set; }
    }
}
