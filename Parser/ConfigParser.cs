using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace TextTemplateAttempt.Parser
{
    public class ConfigParser
    {
        private readonly string _fileName;

        public ConfigParser(string fileName)
        {
            _fileName = fileName;
        }

        public bool TryParse(out int major, out int minor)
        {
            major = 0;
            minor = 0;

            var lines = File.ReadAllLines(_fileName);

            if (!GetMajAndMinLines(lines, out var maj, out var min))
            {
                return false;
            }

            var majParsed = ParseLine(maj);
            var minParsed = ParseLine(min);

            if (!ParseNumber(majParsed, out major)) return false;
            if (!ParseNumber(minParsed, out minor)) return false;

            return true;
        }

        private bool GetMajAndMinLines(string[] lines, out string maj, out string min)
        {
            maj = string.Empty;
            min = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("[__MAJ__]")){
                    maj = line;
                }
                if (line.StartsWith("[__MIN__]")){
                    min = line;
                }
            }
            return !(string.IsNullOrEmpty(maj) || string.IsNullOrEmpty(min));
        }

        private string[] ParseLine(string line)
        {
            return line.Split(' ').Where(x=>!string.IsNullOrEmpty(x)).ToArray();
        }

        private bool ParseNumber(string[] items, out int found)
        {
            var parsed = items.First(x => int.TryParse(x, out var i));

            if (parsed == null)
            {
                found = 0;
                return false;
            }

            found = int.Parse(parsed);
            return true;
        }
    }
}
