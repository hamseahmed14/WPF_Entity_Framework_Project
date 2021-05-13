using LibraryApp;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\hamse\github\LibraryBooks.csv");

            //var books = new List<string>();

            //for (int i = 0; i < csvLines.Length; i++)
            //{
            //    var a = csvLines[i];
            //    books.Add(a);

            //}

            //books.ForEach(a => Console.WriteLine(a));

            //var cm = new MemberCRUDManager();

            // cm.InputAuthorCSV(student);

            for (int i = 0; i < csvLines.Length; i++)
            {

                string[] data = csvLines[i].Split('|');
                for (int j = 0; j < data.Length; j++)
                {
                    Console.WriteLine(data[j]);
                }
     

            }



        }
    }
}
