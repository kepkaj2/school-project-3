using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp6
{
    class Program
    {

        static void Main(string[] args)
        {
            char c;
            int maxId = 1;
            
            List<Player> players = new List<Player>();
            do

            {
                PrintMenu();


                c = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                switch (c)
                {
                    case '1':
                        InsertPlayer(players, maxId);
                        break;
                    case '2':
                        Listplayer(players);
                        break;

                    case '3':
                        SavePlayer(players);
                        break;

                    case '4':
                        players = LoadPlayer();
                        break;

                    case '5':

                        break;

                }
            } while (c != 'k');
        }

     

        static public List<Player> LoadPlayer()
            
        {
            
            List<Player> players = new List<Player>(); 
            string path = @"d:\Škola\programko\MyText.txt";
            if (File.Exists(path))
             {
                
                string json = File.ReadAllText(path);
                players = JsonConvert.DeserializeObject<List<Player>>(json);
                
             }
             
             Console.ReadKey();
             Console.Clear();
             return players;

        }










        static public void SavePlayer(List<Player> players)
        {

            string path = @"d:\Škola\programko\MyText.txt";
            if (!File.Exists(path))


            {
                string result = JsonConvert.SerializeObject(players);
                string createtext = result; 
                File.WriteAllText(path, createtext);

            }

            Console.ReadKey();
            Console.Clear();
        }



        static public void PrintMenu()
        {
            Console.WriteLine("Přidat hráče [1]"); //Přidá fotbalového hráče a udělí ID.
            Console.WriteLine("Vypsat hráče [2]"); //Vypíše hráče načtené v proměnné players.
            Console.WriteLine("Ulož hráče do souboru [3]"); //Načte hráče ze souboru. 
            Console.WriteLine("Načíst hráče ze souboru[4]"); //Načte hráče a jejich ID ze souboru.
            Console.WriteLine("Ukončit program[k]"); //Vypne program.


        }


        static public void InsertPlayer(List<Player> players, int maxId)
        {
            const int POCET = 5;

            Console.WriteLine($"Maximalni pocet hracu v DB je {POCET}");
            for (int i = 0; i < POCET; i++)
            {
                Console.Write("Zadejte jmeno {0}; ", i + 1);

                Player player = new Player();
                player.Id = maxId++;

                player.Name = Console.ReadLine();
                players.Add(player);

            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void Listplayer(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine("Hrac: ({0}){1}", player.Id, player.Name);

            }
            Console.ReadKey();
            Console.Clear();
        }







        public class Player
        {
            public int Id;
            public string Name;
        }
    }
}

