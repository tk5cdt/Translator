using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TranslatePostResponse
    {
        public List<string> alternatives { get; set; }
        public DetectedLanguage detectedLanguage { get; set; }
        public string translatedText { get; set; }
    }
}
