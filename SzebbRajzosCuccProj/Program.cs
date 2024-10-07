using System.Text;
using System.IO;
using System;

namespace SzebbRajzosCuccProj
{
    internal class Program
    {
        private static void Frame()
        {
            string topLeft = "╔";
            string topRight = "╗";
            string bottomLeft = "╚";
            string bottomRight = "╝";
            StringBuilder sb = new StringBuilder(topLeft);
            sb.Append(new string('═', Console.WindowWidth - 2));
            sb.Append(topRight);
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
            sb.Append(bottomLeft);
            sb.Append(new string('═', Console.WindowWidth - 2));
            sb.Append(bottomRight);
            Console.Write(sb.ToString());
            sb.Clear();
        }
        private static void DisplayButtons(string[] options)
        {
            //┌┐─│└┘
            int btnNum = options.Length;
            int padding = 5;
            int btnPos = 0;
            int btnWidth = 31;
            int btnHeight = 5;
            int btnSpace = (Console.WindowHeight - (padding * 2));
            for (int i = 0; i < btnNum; i++)
            {
                int btnXPos = (Console.WindowWidth / 2);
                int btnYPos = (btnSpace / btnNum) * (i + 1);
                Console.SetCursorPosition(btnXPos - 15, btnYPos - 2);
                StringBuilder sb = new StringBuilder("┌");
                sb.Append(new string('─', btnWidth - 2));
                sb.Append("┐");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                for (int j = 0; j < btnHeight - 2; j++)
                {
                    Console.SetCursorPosition(btnXPos - 15, btnYPos - 1 + j);
                    Console.WriteLine("│" + new string(' ', btnWidth - 2) + "│");
                }
                Console.SetCursorPosition(btnXPos - 15, btnYPos + 2);
                sb.Append("└");
                sb.Append(new string('─', btnWidth - 2));
                sb.Append("┘");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.SetCursorPosition(btnXPos - (options[i].Length / 2), btnYPos);
                Console.WriteLine(options[i]);

            }


        }
        static void Main(string[] args)
        {           
            Console.SetWindowSize(150, 50);
            Frame();

            string[] options = { "Create File", "Open File", "Delete File", "Exit"};
            DisplayButtons(options);
            Console.ReadKey();
        }
    }
}
