using System.Text;
using System.IO;
using System;
using System.Runtime.InteropServices;

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
        private static int[] DisplayButtons(string[] options)
        {
            //┌┐─│└┘
            int btnNum = options.Length;
            int padding = 5;
            int btnWidth = 31;
            int btnHeight = 5;
            int[] btnPos = new int[btnNum];
            int btnSpace = (Console.WindowHeight - (padding * 2));
            for (int i = 0; i < btnNum; i++)
            {
                int btnXPos = (Console.WindowWidth / 2);
                int btnYPos = (btnSpace / btnNum) * (i + 1);
                btnPos[i] = btnYPos;
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
            return btnPos;

        }
        private static int Menu(int[] btnPos, string[] options, int selected)
        {
            //▀▄█▌▐
            int padding = 5;
            int btnWidth = 31;
            int btnHeight = 5;
            int btnNum = options.Length;
            int btnSpace = (Console.WindowHeight - (padding * 2));
            ConsoleKeyInfo key;
            do
            {
                Console.ResetColor();
                DisplayButtons(options);
                Console.SetCursorPosition((Console.WindowWidth - 15), (btnPos[selected] - 2));
                Console.ForegroundColor = ConsoleColor.White;
                    int btnXPos = (Console.WindowWidth / 2);
                    int btnYPos = (btnSpace / btnNum) * (selected + 1);
                    btnPos[selected] = btnYPos;
                    Console.SetCursorPosition(btnXPos - 15, btnYPos - 2);
                    StringBuilder sb = new StringBuilder(" ");
                    sb.Append(new string('▄', btnWidth - 2));
                    sb.Append(" ");
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                    for (int j = 0; j < btnHeight - 2; j++)
                    {
                        Console.SetCursorPosition(btnXPos - 15, btnYPos - 1 + j);
                        Console.WriteLine("█" + new string('█', btnWidth - 2) + "█");
                    }
                    Console.SetCursorPosition(btnXPos - 15, btnYPos + 2);
                    sb.Append(" ");
                    sb.Append(new string('▀', btnWidth - 2));
                    sb.Append(" ");
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                    Console.SetCursorPosition(btnXPos - (options[selected].Length / 2), btnYPos);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(options[selected]);
                    Console.SetCursorPosition((Console.WindowWidth - 1), (Console.WindowHeight - 1));

                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected == 0)
                        {
                            selected = options.Length - 1;
                        }
                        else
                        {
                            selected--;
                        }                     
                        break;
                    case ConsoleKey.DownArrow:
                        if (selected == options.Length - 1)
                        {
                            selected = 0;
                        }
                        else
                        {
                            selected++;
                        }                    
                        break;
                    case ConsoleKey.Enter:
                        return selected;
                }
            } while (key.Key != ConsoleKey.Escape);
            return -1;
        }
        private static void CreateFile()
        {
            //13 26 39
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
            string[] options = { "", "Create File","" };
            Console.Clear();
            Frame();
            DisplayButtons(options);

            Console.ReadKey();
        }
        private static void OpenFile()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
        }
        private static void DeleteFile()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
        }
        static void Main(string[] args)
        {           
            Console.SetWindowSize(150, 50);
            Frame();
            string[] options = { "Create File", "Open File", "Delete File", "Exit"};
            int opt = Menu(DisplayButtons(options),options,0);
            Console.ResetColor();
            switch (opt){
                case 0:
                    CreateFile();
                    break;
                case 1:
                    OpenFile();
                    break;
                case 2:
                    DeleteFile();
                    break;
                case 3:
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                case -1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}