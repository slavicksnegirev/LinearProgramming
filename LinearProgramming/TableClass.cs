﻿using System;
using System.Collections.Generic;

namespace LinearProgramming
{
    public class TableClass
    {
        private int _freeVariablesCount;
        private int _basicVariablesCount;
        private int _maxCellWidth = 3;

        List<string> _freeVariables = new List<string>();
        List<string> _basicVariables = new List<string>();
        List<List<NumberClass>> _tableBeforeCalculations = new List<List<NumberClass>>();
        List<List<NumberClass>> _tableAfterCalculations = new List<List<NumberClass>>();

        public int FreeVariablesCount
        {
            get => _freeVariablesCount;
            set => _freeVariablesCount = value;
        }

        public int BasicVariablesCount
        {
            get => _basicVariablesCount;
            set => _basicVariablesCount = value;
        }

        public List<string> FreeVariables
        {
            get => _freeVariables;
            set => _freeVariables = value;
        }

        public List<string> BasicVariables
        {
            get => _basicVariables;
            set => _basicVariables = value;
        }

        public List<List<NumberClass>> TableBeforeCalculations
        {
            get => _tableBeforeCalculations;
            set => _tableBeforeCalculations = value;
        }

        public List<List<NumberClass>> TableAfterCalculations
        {
            get => _tableAfterCalculations;
            set => _tableAfterCalculations = value;
        }

        public TableClass(int freeVariablesCount, int basicVariablesCount)
        {
            FreeVariablesCount = freeVariablesCount;    // 2
            BasicVariablesCount = basicVariablesCount;  // 2

            for (int i = 0; i < FreeVariablesCount + 1; i++)
            {
                if (i == 0)
                {
                    FreeVariables.Add("1");
                }
                else
                {
                    FreeVariables.Add("X" + i);
                } 
            }

            for (int i = FreeVariablesCount; i < BasicVariablesCount + FreeVariablesCount + 1; i++)
            {
                if (i == FreeVariablesCount)
                {
                    BasicVariables.Add("q");
                }
                else
                {
                    BasicVariables.Add("X" + i);
                }
            }



            List<NumberClass> row1 = new List<NumberClass>() { new NumberClass("0"), new NumberClass("1"), new NumberClass("-1") };
            List<NumberClass> row2 = new List<NumberClass>() { new NumberClass("-6"), new NumberClass("-1"), new NumberClass("-4") };
            List<NumberClass> row3 = new List<NumberClass>() { new NumberClass("10"), new NumberClass("2"), new NumberClass("1") };

            TableBeforeCalculations.Add(row1);
            TableBeforeCalculations.Add(row2);
            TableBeforeCalculations.Add(row3);

            List<NumberClass> row4 = new List<NumberClass>() { new NumberClass("0"), new NumberClass("0"), new NumberClass("0") };
            List<NumberClass> row5 = new List<NumberClass>() { new NumberClass("0"), new NumberClass("0"), new NumberClass("0") };
            List<NumberClass> row6 = new List<NumberClass>() { new NumberClass("0"), new NumberClass("0"), new NumberClass("0") };

            TableAfterCalculations.Add(row4);
            TableAfterCalculations.Add(row5);
            TableAfterCalculations.Add(row6);


            //for (int i = 0; i < freeVariablesCount; i++)
            //{
            //    List<NumberClass> row = new List<NumberClass>();
            //    if (i == 0)
            //    {
            //        Console.WriteLine("________________________________");
            //        Console.WriteLine("Введите значение для строки q.");

            //    }
            //    else
            //    {
            //        Console.WriteLine("________________________________");
            //        Console.WriteLine("Введите значение для строки X" + (i + basicVariablesCount + 1) + ".");
            //    }      
            //    for (int j = 0; j < basicVariablesCount + 1; j++)
            //    {
            //        if (j == 0)
            //        {
            //            Console.WriteLine("Введите значение для столбца 1: ");
            //            row.Add(new NumberClass(Console.ReadLine()));
            //        }
            //        else
            //        {
            //            Console.WriteLine("Введите значение для столбца X" + j + ": ");
            //            row.Add(new NumberClass(Console.ReadLine()));
            //        }
            //    }
            //    myTable.Add(row);
            //}
        }

        public void PrintTable(int selectedColumn, int selectedRow)
        {
            GetMaxCellWidth();
            Console.Write("\n   | ");
            for (int i = 0; i < FreeVariablesCount + 1; i++)
            {
                for (int j = 0; j < CountFreeSpaceForVatiablesItems(i); j++)
                {
                    Console.Write(" ");
                }
                Console.Write("-" + FreeVariables[i] + " | ");
            }
            PrintUnderline();

            for (int i = 0; i < BasicVariablesCount + 1; i++)
            {
                if (BasicVariables[i] == "q")
                {
                    Console.Write(" q | ");
                    for (int j = 0; j < FreeVariablesCount + 1; j++)
                    {
                        PrintFirstRow(i, j);
                    }
                }
                else
                {
                    Console.Write(BasicVariables[i] + " | ");
                    for (int j = 0; j < FreeVariablesCount + 1; j++)
                    {
                        PrintFirstRow(i, j);
                    }                   
                }
                if (i == selectedRow)
                {
                    Console.Write("*");
                }
                Console.Write("\n   | ");
                for (int j = 0; j < FreeVariablesCount + 1; j++)
                {
                    PrintSecondRow(i, j);
                }
                PrintUnderline();
            }
            Console.Write("     ");
            for (int i = 0; i < FreeVariablesCount + 1; i++)
            {
                if (i == selectedColumn)
                {
                    Console.WriteLine("*");
                    return;
                }
                for (int j = 0; j < _maxCellWidth + 3; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        private void PrintFirstRow(int i, int j)
        {
            Console.Write(TableBeforeCalculations[i][j]);
            for (int k = 0; k < CountFreeSpaceForTableBeforeCalculatingItems(i, j); k++)
            {
                Console.Write(" ");
            }
            Console.Write(" | ");
        }

        private void PrintSecondRow(int i, int j)
        {
            for (int k = 0; k < CountFreeSpaceForTableAfterCalculatingItems(i, j); k++)
            {
                Console.Write(" ");
            }
            Console.Write(TableAfterCalculations[i][j]);
            Console.Write(" | ");
        }

        private void PrintUnderline()
        {
            Console.Write("\n---+");
            for (int i = 0; i < FreeVariablesCount + 1; i++)
            {
                for (int j = 0; j < _maxCellWidth + 2; j++)
                {
                    Console.Write("-");
                }
                Console.Write("+");
            }
            Console.WriteLine();
        }

        public NumberClass GetTableBeforeCalculationsItem(int i, int j)
        {
            return TableBeforeCalculations[i][j];
        }

        private void GetMaxCellWidth()
        {
            for (int i = 0; i < BasicVariablesCount + 1; i++)
            {
                for (int j = 0; j < FreeVariablesCount + 1; j++)
                {
                    if (TableBeforeCalculations[i][j].GetLenght() + TableAfterCalculations[i][j].GetLenght() + 1 > _maxCellWidth)
                    {
                        _maxCellWidth = TableBeforeCalculations[i][j].GetLenght() + TableAfterCalculations[i][j].GetLenght() + 1;
                    }
                }
            }
        }

        private int CountFreeSpaceForTableAfterCalculatingItems(int i, int j)
        {
            return _maxCellWidth - TableAfterCalculations[i][j].GetLenght();
        }

        private int CountFreeSpaceForTableBeforeCalculatingItems(int i, int j)
        {
            return _maxCellWidth - TableBeforeCalculations[i][j].GetLenght();
        }

        private int CountFreeSpaceForVatiablesItems(int i)
        {
            return _maxCellWidth - FreeVariables[i].Length - 1;
        }
    }
}
