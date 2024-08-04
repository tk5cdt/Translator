using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TranslatePostContent
    {
        public string q { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string format { get; set; }
        public int alternatives { get; set; }
        public string api_key { get; set; }
    }
}
