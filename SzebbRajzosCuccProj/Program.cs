using System.Text;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;

namespace SzebbRajzosCuccProj
{
    internal class Program
    {
        private static int winWidth = 150;
        private static int winHeight = 50;
        private static int currentRow = 1;
        private static int currentCol = 1;
        private static int writeRow = 0;
        private static int writeCol = 0;
        private static int color = 0;
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
                int btnYPos = 0;
                if (btnNum == 1)
                {
                    btnYPos = Console.WindowHeight / 2;
                }
                else
                {
                    btnYPos = (btnSpace / btnNum) * (i + 1);
                }
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
                    int btnYPos = 0;
                    if (btnNum == 1)
                    {
                        btnYPos = Console.WindowHeight / 2;
                    }
                    else
                    {
                        btnYPos = (btnSpace / btnNum) * (selected + 1);
                    }
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
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i] == newFileName)
                            {
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 39);
                                Console.WriteLine("File already exists!");
                                Thread.Sleep(1000);
                                fileExists = true;
                            }
                        }
                        if (!fileExists)
                        {
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
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 12, 39);
                    Console.WriteLine("Invalid file name!");
                    Thread.Sleep(1000);
                }
            } while (fileCreated != true);
            
        }
        private static string OpenFile()
        {
            string[] files = GetFiles();
            Console.Clear();
            Frame();
            int opt = Menu(DisplayButtons(files),files,0);
            Console.ResetColor();
            return files[opt];
        }
        private static string DeleteFile()
        {
            string[] files = GetFiles();
            Console.Clear();
            Frame();
            int opt = Menu(DisplayButtons(files), files, 0);
            Console.ResetColor();
            return files[opt];
        }
        static void Main(string[] args)
        {
            bool fileDone = false;
            string[,] currentFile = new string[48, 148];
            ConsoleKeyInfo input;
            int toggleDraw = 0;
            string fileToOpen = "";
            int l = 0;
            do
            {
                Console.Clear();
                Console.SetWindowSize(150, 50);
                Frame();
                string[] options = { "Create File", "Open File", "Delete File", "Close" };
                int opt = Menu(DisplayButtons(options), options, 0);
                Console.ResetColor();
                switch (opt)
                {
                    case 0:
                        CreateFile();
                        break;
                    case 1:
                        fileToOpen = OpenFile();
                        string[] fileContent = File.ReadAllLines(fileToOpen);
                        for (int i = 0; i < fileContent.Length; i++)
                        {
                            string[] line = fileContent[i].Split("\n");
                            for (int j = 0; j < line.Length; j++)
                            {
                                string[] cell = line[j].Split(";");
                                for (int k = 0; k < cell.Length; k++)
                                {
                                    string[] data = cell[k].Split(",");
                                    currentFile[i, k] = $"{data[0]},{data[1]};";
                                }
                            }
                        }
                        fileDone = true;
                        break;
                    case 2:
                        string fileToDelete = DeleteFile();
                        File.Delete(fileToDelete);
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    case 3:
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    case -1:
                        Environment.Exit(0);
                        break;
                }
            } while (fileDone != true);
            string openedFile = fileToOpen;
            Console.Clear();
            do
            {

                winWidth = Console.WindowWidth;
                winHeight = Console.WindowHeight;
                Frame();

                do
                {
                    for (int i = 0; i < winHeight - 2; i++)
                    {
                        for (int j = 0; j < winWidth - 2; j++)
                        {
                            string[] data = currentFile[i, j].Split(",");
                            int ok = 0;
                            string saturation1 = "";
                            int color = 0;
                            if (data[0] != "0")
                            {
                                ok = 1;
                                saturation1 = data[0];
                                data[1] = data[1].Substring(0, data[1].Length - 1);
                                color = int.Parse(data[1]);
                            }
                            switch (color)
                            {
                                case 0:
                                    Console.ResetColor();
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    break;
                                case 6:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                                case 7:
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case 8:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case 9:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }
                            Console.SetCursorPosition(j + 1, i + 1);
                            if (ok == 1)
                            {
                                Console.Write(saturation1);
                            }
                            l++;
                        }
                    }

                } while (l < currentFile.Length);
                string saturation = "█";
                Console.SetCursorPosition(1, 1);
                do
                {
                    Console.SetWindowSize(150, 50);
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (currentCol != 1)
                            {
                                Console.SetCursorPosition(currentCol - 1, currentRow);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentCol--;
                                writeCol--;

                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentCol != winWidth - 2)
                            {
                                Console.SetCursorPosition(currentCol + 1, currentRow);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentCol++;
                                writeCol++;

                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (currentRow != 1)
                            {
                                Console.SetCursorPosition(currentCol, currentRow - 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentRow--;
                                writeRow--;

                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentRow != winHeight - 2)
                            {
                                Console.SetCursorPosition(currentCol, currentRow + 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentRow++;
                                writeRow++;

                            }
                            break;
                        case ConsoleKey.D1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            color = 1;
                            break;
                        case ConsoleKey.D2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            color = 2;
                            break;
                        case ConsoleKey.D3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            color = 3;
                            break;
                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            color = 4;
                            break;
                        case ConsoleKey.D5:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            color = 5;
                            break;
                        case ConsoleKey.D6:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            color = 6;
                            break;
                        case ConsoleKey.D7:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            color = 7;
                            break;
                        case ConsoleKey.D8:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            color = 8;
                            break;
                        case ConsoleKey.D9:
                            Console.ForegroundColor = ConsoleColor.White;
                            color = 9;
                            break;
                        case ConsoleKey.F1:
                            saturation = "█";
                            break;
                        case ConsoleKey.F2:
                            saturation = "▓";
                            break;
                        case ConsoleKey.F3:
                            saturation = "▒";
                            break;
                        case ConsoleKey.F4:
                            saturation = "░";
                            break;
                        case ConsoleKey.Spacebar:
                            Console.Write(saturation);
                            Console.SetCursorPosition(currentCol, currentRow);
                            currentFile[writeRow, writeCol] = $"{saturation},{color};";
                            break;
                        case ConsoleKey.Backspace:
                            Console.SetCursorPosition(1, 13);
                            Console.ResetColor();
                            Frame();
                            Console.SetCursorPosition(1, 13);
                            currentCol = 1;
                            currentRow = 13;
                            break;
                        case ConsoleKey.C:
                            if (toggleDraw == 0)
                            {
                                toggleDraw = 1;
                            }
                            else
                            {
                                toggleDraw = 0;
                            }
                            break;
                        case ConsoleKey.F5:

                            File.Delete(openedFile);
                            File.Create(openedFile).Close();
                            string currentFileString = "";
                            for (int i = 0; i < winHeight - 2; i++)
                            {
                                for (int j = 0; j < 147; j++)
                                {
                                    currentFileString += currentFile[i, j];
                                }
                                currentFileString += currentFile[i, 147].Substring(0, 3);
                                if (i != winHeight - 3)
                                {
                                    currentFileString += "\n";
                                }
                            }
                            File.WriteAllText(openedFile, currentFileString);
                            Console.SetCursorPosition(11, 33);
                            Console.Write("File saved!");
                            Thread.Sleep(2500);
                            Environment.Exit(0);
                            break;

                    }

                } while (input.Key != ConsoleKey.Escape);
            } while (input.Key != ConsoleKey.Escape);
            
        }
    }
}