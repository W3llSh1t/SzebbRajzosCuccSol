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
        private static string[] GetFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Substring(Directory.GetCurrentDirectory().Length + 1);
            }
            return files;
        }
        private static void CreateFile()
        {
            //asdasd
            //▀▄█
            //13 26 39
            string[] files = GetFiles();
            string[] options = { "", "Create File","" };
            string newFileName = "";
            bool fileCreated = false;
            do
            {
                Console.Clear();
                Frame();
                DisplayButtons(options);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 24);
                StringBuilder sb = new StringBuilder(" ");
                sb.Append(new string('▄', 31 - 2));
                sb.Append(" ");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                for (int j = 0; j < 5 - 2; j++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 26 - 1 + j);
                    Console.WriteLine("█" + new string('█', 31 - 2) + "█");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 26 + 2);
                sb.Append(" ");
                sb.Append(new string('▀', 31 - 2));
                sb.Append(" ");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - (options[1].Length / 2), 26);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(options[1]);
                Console.SetCursorPosition((Console.WindowWidth - 1), (Console.WindowHeight - 1));
                Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 13);
                Console.ResetColor();
                string unCheckedName = Console.ReadLine();
                bool fileExists = false;
                
                if (unCheckedName.Length > 0)
                {
                    for(int i = 0; i < files.Length; i++)
                    {
                        if (files[i] == unCheckedName)
                        {
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 39);
                            Console.WriteLine("File already exists!");
                            Thread.Sleep(1000);
                            fileExists = true;
                        }
                    }
                    if (fileExists == false)
                    {
                        for (int i = 0; i < unCheckedName.Length; i++)
                        {
                            if (unCheckedName[i] == ' ')
                            {
                                unCheckedName = unCheckedName.Remove(i, 1);
                            }
                            if (unCheckedName[i] == '.')
                            {
                                unCheckedName = unCheckedName.Remove(i, 1);
                            }
                        }
                        newFileName = unCheckedName + ".ldzs";
                        File.Create(newFileName).Close();
                        
                        string newFileString = "";
                        for (int i = 0; i < 48; i++)
                        {
                            for (int j = 0; j < 147; j++)
                            {
                                newFileString += "0,0;";
                            }
                            newFileString += "0,0";
                            if (i != 47)
                            {
                                newFileString += "\n";
                            }
                        }
                        File.WriteAllText(newFileName, newFileString);
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 39);
                        Console.WriteLine("File created!");
                        Thread.Sleep(1000);
                        fileCreated = true;
                    }
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 39);
                    Console.WriteLine("Invalid file name!");
                    Thread.Sleep(1000);
                }
            } while (fileCreated != true);
            
        }
        private static void OpenFile()
        {
            string[] files = GetFiles();
        }
        private static void DeleteFile()
        {
            string[] files = GetFiles();
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