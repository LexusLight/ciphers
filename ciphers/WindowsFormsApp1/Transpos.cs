﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Transpos
    {
        private static string[,] stringmas1 = new string[,] { };
        private static string[,] stringmas3 = new string[,] { };
        private static string[] stringmas2 = new string[] { };
        private static int symblenght = 0;

        public static string MonoTrans()//Одиночная простая перестановка
        {
            Change.secondWord = "";
            symblenght = Change.firstWord.Length;
            stringmas1 = new string[2, symblenght];
            stringmas2 = Change.key.Split(Convert.ToChar(" "));
            for (int i = 0; i < symblenght; i++)
            {
                stringmas1[0, i] = Change.firstWord[i].ToString();
            }
            for (int i = 0; i < symblenght; i++)
            {
                stringmas1[1, Convert.ToInt32(stringmas2[i].ToString()) - 1] += stringmas1[0, i];
            }
            for (int i = 0; i < symblenght; i++)
            {
                Change.secondWord += stringmas1[1, i];
            }
            return (Change.secondWord);
        }
        public static string BlockTrans()//Блочная перестановка
        {
            Change.secondWord = "";
            int count = 0;
            Change.firstWord += (Change.firstWord.Length % 3 == 0) ? "" : "ЯЯ";
            symblenght = Change.firstWord.Length;
            stringmas1 = new string[2, symblenght / 3];
            stringmas2 = Change.key.Split(Convert.ToChar(" "));
            string[] stringmasblock = new string[3];
            for (int i = 0; i < 3; i++)
            {
                stringmasblock[Convert.ToInt32(stringmas2[i].ToString()) - 1] = (i + 1).ToString();
            }
            for (int i = 0; i < Change.firstWord.Length / 3; i++)
            {
                stringmas1[0, i] += Change.firstWord[count++].ToString();
                stringmas1[0, i] += Change.firstWord[count++].ToString();
                stringmas1[0, i] += Change.firstWord[count++].ToString();
            }
            for (int i = 0; i < Change.firstWord.Length / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Change.secondWord += stringmas1[0, i][Convert.ToInt32(stringmasblock[j].ToString()) - 1];
                }
            }
            return (Change.secondWord);
        }
        public static string Marchrut()//Маршрутная перестановка
        {
            Change.secondWord = "";
            stringmas1 = new string[5, 6];
            int count = 0;
            for (int i = 0; i < 30; i++) Change.firstWord += (Change.firstWord.Length < 30) ? "_" : "";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    stringmas1[i, j] = Change.firstWord[count++].ToString();
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Change.secondWord += stringmas1[j, i].ToString();
                }
            }
            return (Change.secondWord);
        }
        public static string Vertical()//Вертикальная перестановка
        {
            Change.secondWord = "";
            int count = 0;
            stringmas1 = new string[(Change.firstWord.Length / Change.key.Length) + 1, Change.key.Length];
            stringmas2 = new string[Change.key.Length];
            for (int i = 0; i < 100; i++)
            {
                Change.firstWord += (Change.firstWord.Length < ((Change.firstWord.Length / Change.key.Length) + 1) * Change.key.Length) ? "_" : "";
                if (Change.key.Length > 100) break;
            }

            for (int i = 0; i < Change.key.Length; i++) // загоняем в массив ключ
            {
                stringmas2[i] = Change.key[i].ToString();
            }

            for (int i = 0; i < Change.key.Length; i++) // ищем индексы в алфавите
            {
                stringmas2[i] = Change.alphabet.IndexOf(stringmas2[i].ToString()).ToString();
            }
            for (int i = 0; i < stringmas1.GetLength(0); i++) // заполняем сам массив
            {
                for (int j = 0; j < stringmas1.GetLength(1); j++)
                {
                    stringmas1[i, j] = Change.firstWord[count++].ToString();
                }
            }
            for (int k = 0; k < 33; k++)
            {
                for (int m = 0; m < stringmas2.Length; m++)
                    if (Convert.ToInt32(Convert.ToInt32(stringmas2[m].ToString())) == k)
                    {
                        for (int j = 0; j < stringmas1.GetLength(0); j++)
                        {
                            Change.secondWord += stringmas1[j, m].ToString();
                        }
                        Change.secondWord += "|";
                    }

            }
            return (Change.secondWord);
        }
        public static string Perekrestok() //Перекрёсток
        {
            Change.secondWord = "";
            Change.firstWord += "!%$#@$%&";
            int blocks = Change.firstWord.Length / 4;
            string[,] threemas = new string[3,blocks];
            int count = 0;
            for (int i =0; i < blocks; i++)
            {
                threemas[1, i] += Change.firstWord[count++].ToString();
                threemas[0, i] += Change.firstWord[count++].ToString();
                threemas[1, i] += Change.firstWord[count++].ToString();
                threemas[2, i] += Change.firstWord[count++].ToString();
            }
            for (int i = 0; i < blocks-1; i += 2)
            {
                Change.secondWord += threemas[0, i].ToString() + threemas[0, i + 1].ToString();
                Change.secondWord += threemas[1, i].ToString() + threemas[1, i + 1].ToString();
                Change.secondWord += threemas[2, i].ToString() + threemas[2, i + 1].ToString();
            }
            return (Change.secondWord);
        }
        public static string Reshetka()//Переворотная решётка
        {
            Change.secondWord = "";
            stringmas1 = new string[4, 4];
            int count = 0;
            for (int i = 0; i < 16; i++) Change.firstWord += (Change.firstWord.Length < 16) ? "_" : "";
            stringmas1[0, 0] = Change.firstWord[count++].ToString();
            stringmas1[0, 2] = Change.firstWord[count++].ToString();
            stringmas1[2, 1] = Change.firstWord[count++].ToString();
            stringmas1[2, 3] = Change.firstWord[count++].ToString();
            stringmas1[0, 1] = Change.firstWord[count++].ToString();
            stringmas1[0, 3] = Change.firstWord[count++].ToString();
            stringmas1[2, 0] = Change.firstWord[count++].ToString();
            stringmas1[2, 2] = Change.firstWord[count++].ToString();
            stringmas1[1, 0] = Change.firstWord[count++].ToString();
            stringmas1[1, 2] = Change.firstWord[count++].ToString();
            stringmas1[3, 1] = Change.firstWord[count++].ToString();
            stringmas1[3, 3] = Change.firstWord[count++].ToString();
            stringmas1[1, 1] = Change.firstWord[count++].ToString();
            stringmas1[1, 3] = Change.firstWord[count++].ToString();
            stringmas1[3, 0] = Change.firstWord[count++].ToString();
            stringmas1[3, 2] = Change.firstWord[count++].ToString();
            for (int i = 0; i < stringmas1.GetLength(0); i++)
            {
                for (int j = 0; j < stringmas1.GetLength(0); j++)
                {
                    Change.secondWord += stringmas1[i, j];
                }
            }
            return (Change.secondWord);
        }
        public static string MagKv()//Магические квадраты
        {
            Change.secondWord = "";
            for (int i = 0; i < 16; i++) Change.firstWord += (Change.firstWord.Length < 16) ? "_": "";
            int[,] mag = new int [4,4] { {16,3,2,13},{5,10,11,8},{9,6,7,12},{4,15,14,1}};
            string[,] mag2 = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mag2[i,j] = Change.firstWord[mag[i, j]-1].ToString();
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Change.secondWord += mag2[i,j].ToString();
                }
            }
            return (Change.secondWord);
        }
        public static string Dvoi()
        {
            Change.secondWord = "";
            stringmas1 = new string[4, 4];
            stringmas3 = new string[4, 4];
            int[] col = new int[4] {4,1,3,2};
            int[] row = new int[4] {3,1,4,2};
            for (int i = 0; i < 16; i++) Change.firstWord += (Change.firstWord.Length < 16) ? "_" : "";
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j > -1; j--)
                {
                    stringmas1[i, j] = Change.firstWord[count++].ToString();
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0 ; j < 4; j++)
                {
                    stringmas3[i, col[j] - 1] = stringmas1[i,j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    stringmas1[row[i] - 1, j] = stringmas3[i,j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Change.secondWord += stringmas1[j,i];
                }
            }
            return (Change.secondWord);
        }
    }
}
