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
            if (btnNum < 6)
            {
                sections = (Console.WindowHeight / 2) / btnNum;
            }
            else
            {
                sections = Console.WindowHeight / btnNum;
            }
            int buttonXPos = 0;
            int buttonYPos = 0;
            string btnTopLeft = "┌";
            string btnTopRight = "┐";
            string btnBottomLeft = "└";
            string btnBottomRight = "┘";
            string btnHorizontal = "─";
            string btnVertical = "│";
            //write background for buttons with 20 width and 3 height
            for(int i = 0; i < btnNum; i++)
            {
                buttonYPos = sections * i + sections / 2;
                buttonXPos = Console.WindowWidth / 2 - 10;
                Console.SetCursorPosition(buttonXPos, buttonYPos - 1);
                Console.Write(btnTopLeft + new string(btnHorizontal[0], 20) + btnTopRight);
                Console.SetCursorPosition(buttonXPos, buttonYPos);
                Console.Write(btnVertical + new string(' ', 20) + btnVertical);
                Console.SetCursorPosition(buttonXPos, buttonYPos + 1);
                Console.Write(btnBottomLeft + new string(btnHorizontal[0], 20) + btnBottomRight);
            }

            for (int i = 0; i < btnNum; i++)
            {
                buttonYPos = sections * i + sections / 2;
                buttonXPos = Console.WindowWidth / 2 - options[i].Length / 2;
                Console.SetCursorPosition(buttonXPos, buttonYPos);
                Console.Write(options[i]);
            }
        }
        static void Main(string[] args)
        {           
            Console.SetWindowSize(150, 50);
            Frame();

            string[] options = { "Start", "Options", "Exit", "Igen" };
            DisplayButtons(options);
            Console.ReadKey();
        }
    }
}
