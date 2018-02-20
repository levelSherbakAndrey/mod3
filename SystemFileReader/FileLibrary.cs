using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemFileReader
{
    public class FileLibrary
    {
        List<string> back = new List<string>();
        int count = 0;
        public string path = "e:/";
        static object locker = new object();
        bool bl;
        public static string[] Files;
        int place = 0;



        public void Show()
        {
           
            Files = Directory.GetFileSystemEntries(path);
            lock (locker)
            {
                while (!bl)
                {
                    if (place == count)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(Files[count]);
                        Console.ResetColor();
                        count++;
                    }
                    else if (count == Files.Length - 1)
                    {
                        bl = true;
                    }
                    else
                    {
                        Console.WriteLine(Files[count]);
                        count++;
                    }
                }
            }
            
        }


        public void _keys()
        {

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (place < Files.Length - 1)
                        place++;
                    break;
                case ConsoleKey.UpArrow:
                    if (place > 0)
                        place--;
                    break;
                case ConsoleKey.Enter:
                    back.Add(path);
                    path = Files[place];
                    place = 0;
                    break;
                case ConsoleKey.Escape:
                    if (back.Count != 0)
                    {
                        path = back.Last();
                        back.RemoveAt(back.Count - 1);
                    }
                    break;
            }
        }


    }
}
