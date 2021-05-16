using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace AimpAPI
{
    class Program
    {
        const string FILENAME = "song_title.txt";
        const string PLAYER = "AIMP";
        const int DELAY = 300;

        static bool working = true;

        static void Main(string[] args)
        {
            Console.Title = "Player API";
            if (!File.Exists(FILENAME)) File.Create(FILENAME).Dispose();

            while (working)
            {
                Process player = Process.GetProcessesByName(PLAYER).FirstOrDefault();
                if (player != null)
                {
                    if (player.MainWindowTitle == "") Output("Ожидание...");
                    else Output("Сейчас играет: " + player.MainWindowTitle); 
                }
                else Output("Музыка не играет!");

                Thread.Sleep(DELAY);
                Console.Clear();
            }
            Output("Музыка не играет!");
        }

        static void Output(string text)
        {
            File.WriteAllText(FILENAME, text);
            Console.WriteLine(text);
        }
    }
}
