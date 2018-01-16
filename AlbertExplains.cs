using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgDuckTV
{
    class AlbertExplains
    {
        public static void AlbExp()
        {
            try
            {
                WebClient client = new WebClient();

                client.DownloadFile("https://www.ducktv.tv/series/albert-explains-31.html", @"..\...\Data\albertExplains.txt");

                try
                {
                    FileStream file = new FileStream(@"..\...\Data\albertExplains.txt", FileMode.Open);
                    StreamReader re1 = new StreamReader(file);
                    string t = re1.ReadToEnd();

                    Regex tvAlbertExplains = new Regex("serie_sd.png|serie_hd.png|Today|Tomorrow|[0-2][0-9]:[0-9][0-9]");


                    foreach (Match match in tvAlbertExplains.Matches(t))
                        Console.WriteLine("Profesor:  {0}", match.Value);
                }
                catch (Exception)
                {
                    Console.WriteLine("Błąd odczytu programu profesora");
                }
            }
            catch(WebException)
            {
                Console.WriteLine("Nie można pobrać programu profesora");
            }
        }
    }
}
