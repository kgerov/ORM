using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ImportFromJson
{
    class ImportFromJson
    {
        static void Main(string[] args)
        {
            string json = "";
            
            using (StreamReader r = new StreamReader("../../mountains.json"))
            {
                json = r.ReadToEnd();
            }

            var mountains = JsonConvert.DeserializeObject<IEnumerable<MountainJ>>(json);

        }
    }
}
