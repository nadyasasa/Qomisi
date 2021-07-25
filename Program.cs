using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace sample_2
{
    class Program
    {
        private static int menuChoice = 0;
        private static ArrayList listKaryawan = new ArrayList();
        static void Main(string[] args)
        {
            loop();
        }

        static void loop()
        {
            while (true)
            {
                switch (menuChoice)
                {
                    case 0:
                        mainMenu();
                        break;
                    case 1:
                        calculate();
                        break;
                    case 2:
                        saveToDatabase();
                        break;
                    case 3:
                        show();
                        break;
                    default: break;
                }
            }
        }

        static void saveToJson(ArrayList list)
        {
            string fileName = "Database.json";
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(fileName, json);
        }

        static ArrayList loadJson()
        {
            string fileName = "Database.json";
            try
            {
                string jsonString = File.ReadAllText(fileName);
                var list = JArray.Parse(jsonString);
                var newArrayList = new ArrayList();
                foreach (dynamic data in list)
                {
                    if (data["teamType"] == 1)
                    {
                        newArrayList.Add(new Tim3D((int)data["Id"], (string)data["nama"], (int)data["nProject"], (double)data["Gaji"], (int)data["Fee"]));
                    }
                    else if (data["teamType"] == 2)
                    {
                        newArrayList.Add(new TimDED((int)data["Id"], (string)data["nama"], (int)data["luas"], (double)data["Gaji"], (int)data["Fee"]));
                    }
                    else if (data["teamType"] == 3)
                    {
                        newArrayList.Add(new TimDenah((int)data["Id"], (string)data["nama"], (int)data["hours"], (double)data["Gaji"], (int)data["Fee"]));
                    }

                }
                return newArrayList;
            }
            catch (FileNotFoundException error)
            {
                return new ArrayList();
            }
        }

        static void mainMenu()
        {
            if (listKaryawan.Count == 0)
            {
                var newListKaryawan = loadJson();
                listKaryawan = newListKaryawan;
            }

            Console.WriteLine("1. Calculate");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Show");
            var read = Console.ReadLine();
            menuChoice = Int32.Parse(read);
        }

        static void calculate()
        {
            Console.WriteLine("1. Tim3D");
            Console.WriteLine("2. TimDED");
            Console.WriteLine("3. TimDenah");
            var teamType = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nama: ");
            var name = Console.ReadLine();
            int special = 0;
            switch (teamType)
            {
                case 1:
                    Console.WriteLine("Project: ");
                    special = Int32.Parse(Console.ReadLine());
                    var sample = new Tim3D(listKaryawan.Count + 1, name, special, 0);
                    sample.calcSalary();
                    listKaryawan.Add(sample);
                    break;
                case 2:
                    Console.WriteLine("Luas: ");
                    special = Int32.Parse(Console.ReadLine());
                    var sample1 = new TimDED(listKaryawan.Count + 1, name, special, 0);
                    sample1.calcSalary();
                    listKaryawan.Add(sample1);
                    break;
                case 3:
                    Console.WriteLine("Jam: ");
                    special = Int32.Parse(Console.ReadLine());
                    var sample2 = new TimDenah(listKaryawan.Count + 1, name, special, 0);
                    sample2.calcSalary();
                    listKaryawan.Add(sample2);
                    break;
            }
            backToMenu();
        }

        static void saveToDatabase()
        {
            saveToJson(listKaryawan);
            backToMenu();
        }

        static void backToMenu()
        {
            Console.Clear();
            menuChoice = 0;
        }

        static void show()
        {
            for (int i = 0; i < listKaryawan.Count; i++)
            {
                var data = listKaryawan[i];
                if (data.GetType() == typeof(Tim3D))
                {
                    (data as Tim3D).display();
                }else if (data.GetType() == typeof(TimDED))
                {
                    (data as TimDED).display();
                } else if (data.GetType() == typeof(TimDenah))
                {
                    (data as TimDenah).display();
                }
            }
            Console.ReadKey();
            backToMenu();
        }
    }

}
