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
    class Fireteam
    {

        public static void Ft()
        {

            try
            {

                WebClient client = new WebClient();

                client.DownloadFile("https://www.ducktv.tv/series/fireteam-21.html", @"..\...\Data\fireteam.txt");


                try
                {
                    FileStream file = new FileStream(@"..\...\Data\fireteam.txt", FileMode.Open);
                    StreamReader re1 = new StreamReader(file);
                    string w = re1.ReadToEnd();
               
                Regex tvFireteam = new Regex("serie_sd.png|serie_hd.png|Today|Tomorrow|[0-2][0-9]:[0-9][0-9]");


                    foreach (Match match in tvFireteam.Matches(w))
                        Console.WriteLine("Strażak:  {0}", match.Value);

                }
                catch (Exception)
                {
                    Console.WriteLine("Błąd odczytu programu strażaka");
                }
            }
            catch (WebException)
            {
                Console.WriteLine("Nie można pobrać programu strażaka");
            }
        }

    }
}
