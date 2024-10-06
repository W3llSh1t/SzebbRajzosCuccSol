using System.Text;
using System.IO;
using System;

namespace SzebbRajzosCuccProj
{
    internal class Program
    {
        private static void Frame()
        {
            string topleft = "╔";
            string topright = "╗";
            string bottomleft = "╚";
            string bottomright = "╝";
            StringBuilder sb = new StringBuilder(topleft);
            sb.Append(new string('═', Console.WindowWidth - 2));
            sb.Append(topright);
            Console.WriteLine(sb.ToString());
            sb.Clear();
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                sb.Append("║");
                sb.Append(new string(' ', Console.WindowWidth - 2));
                sb.Append("║");
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            sb.Append(bottomleft);
            sb.Append(new string('═', Console.WindowWidth - 2));
            sb.Append(bottomright);
            Console.Write(sb.ToString());
            sb.Clear();
        }
        private static void DisplayButtons(string[] options)
        {
            int btnNum = options.Length;
            int sections = 0;
            if (btnNum % 2 == 0)
            {
                if(btnNum <= 4)
                {
                    int center = Console.WindowWidth / 2;
                    int firstBtn = center - ((btnNum / 2) * 10);
                }
                else
                {
                    int center = Console.WindowWidth / 2;
                }
            }
            else
            {
                
            }
            int buttonXPos = 0;
            int buttonYPos = 0;
            string btnTopLeft = "┌";
            string btnTopRight = "┐";
            string btnBottomLeft = "└";
            string btnBottomRight = "┘";
            string btnHorizontal = "─";
            string btnVertical = "│";
            
        }
        static void Main(string[] args)
        {           
            Console.SetWindowSize(150, 50);
            Frame();

            string[] options = { "Create File", "Open File", "Delete File", "Exit" };
            DisplayButtons(options);
            Console.ReadKey();
        }
    }
}
