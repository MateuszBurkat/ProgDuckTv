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
    class FireteamInAction
    {
        public static void FtInAction()
        {
            try
            {
                WebClient client = new WebClient();

                client.DownloadFile("https://www.ducktv.tv/series/fireteam-in-action-37.html", @"..\...\Data\fireteamInAction.txt");

                try
                {
                    FileStream file = new FileStream(@"..\...\Data\fireteamInAction.txt", FileMode.Open);
                    StreamReader re1 = new StreamReader(file);
                    string t = re1.ReadToEnd();

                    Regex tvFireteamInAction = new Regex("serie_sd.png|serie_hd.png|Today|Tomorrow|[0-2][0-9]:[0-9][0-9]");


                    foreach (Match match in tvFireteamInAction.Matches(t))
                        Console.WriteLine("Strażak w akcji:  {0}", match.Value);
                }
                catch(Exception)
                {
                    Console.WriteLine("Błąd odczytu programu strażaka w akcji");
                }
            }
            catch(WebException)
            {
                Console.WriteLine("Nie można pobrać programu strażaka w akcji");
            }
        }
    }
}
