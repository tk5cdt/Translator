using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TranslatePostContent
    {
        string q;
        string source;
        string target;
        string format;
        int alternatives;
        string api_key;

        public string Q { get => q; set => q = value; }
        public string Source { get => source; set => source = value; }
        public string Target { get => target; set => target = value; }
        public string Format { get => format; set => format = value; }
        public int Alternatives { get => alternatives; set => alternatives = value; }
        public string Api_key { get => api_key; set => api_key = value; }
    }
}
