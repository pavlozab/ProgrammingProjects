﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            var collection = new MyCollection<Address>();
            do
            {
                PrintHelp();
                choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1": ReadJson(collection);
                            break;
                        case "2": Search(collection);
                            break;
                        case "3": SortBy(collection);
                            break;
                        case "4": Delete(collection);
                            break;
                        case "5":
                            collection.AddNewObj();
                            collection.WriteInFile();
                            break;
                        case "6": Edit(collection);
                            break;
                        case "7": Console.WriteLine(collection.ToString());
                            break;
                        case "exit": Console.WriteLine("Goodbye!");
                            break;
                        default: Console.WriteLine("Wrong input!");
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("\nArgument error:\n");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError:");
                    Console.WriteLine(e.Message);
                }
            } while ( choice != "exit");
        }
            
        #region MenuFunc
        /// <summary>The function that returns help message.</summary>
        static void PrintHelp()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - -");
            Console.WriteLine("| Help:                           |");
            Console.WriteLine("| 1 - to read from file.          |");
            Console.WriteLine("| 2 - to search.                  |");
            Console.WriteLine("| 3 - to sort by.                 |");
            Console.WriteLine("| 4 - to delete.                  |");
            Console.WriteLine("| 5 - to add new.                 |");
            Console.WriteLine("| 6 - to edit element.            |");
            Console.WriteLine("| 7 - to print collection.        |");
            Console.WriteLine("|  exit - to exit.                |");
            Console.WriteLine("- - - - - - - - - - - - - - - - - -\n");
        }
        
        /// <summary>The function that returns string representation of possible address parameter.</summary>
        static void WritePossibleParameter()
        {
            Console.Write("\nPOSSIBLE: ");
            
            foreach (var i in typeof(Address).GetProperties())
            {
                Console.Write("{0}, ", i.Name);
            }
            Console.WriteLine();
        }
        
        static void ReadJson(MyCollection<Address> collection)
        {
            Console.WriteLine("File name: ");
            var fileName = Console.ReadLine();
            collection.ReadJson(fileName);
        }
        
        static void Search(MyCollection<Address> collection)
        {
            Console.Write("Enter parameter which elements you want to find:  ");
            var searchValue = Console.ReadLine();
            
            var searchRes =  collection.Search(searchValue);
            
            if (searchRes.Any()) Console.WriteLine(JsonConvert.SerializeObject(searchRes, Formatting.Indented));
            else
            {
                Console.WriteLine("\nWe couldn't find for {0}. \nTry different or less specific keywords.",
                    searchValue);
            }
        }

        static void SortBy(MyCollection<Address> collection)
        {
            Console.Write("Enter field for which you want to sort:");
            WritePossibleParameter();
            var searchValue = Console.ReadLine();
            collection.Sort(searchValue);
        }

        static void Delete(MyCollection<Address> collection)
        {
            Console.WriteLine("Enter id to delete: ");
            var id = Guid.Parse(Console.ReadLine() ?? string.Empty);
            collection.Delete(id);
            collection.WriteInFile();
        }
        
        static void Edit(MyCollection<Address> collection)
        {
            Console.WriteLine("Enter id to edit: ");
            var id = Guid.Parse(Console.ReadLine() ?? string.Empty);
        
            Console.Write("Enter param to edit: ");
            WritePossibleParameter();
            var param = Console.ReadLine();
            
            Console.WriteLine("Enter value to change: ");
            var value = Console.ReadLine();
            
            collection.EditObject(id, param, value);
            collection.WriteInFile();
        }
        #endregion
    }
}