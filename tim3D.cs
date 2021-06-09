using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_2
{
    public class Tim3D : Karyawan
    {
        public int nProject { get; set; } //banyak project yang dikerjakan

        public int Fee { get; set; } //upah tiap satu project

        public string nama { get; set; }
        public int Id { get; set; }
        public double Gaji { get; set; }

        public int teamType { get; set; }
        public Tim3D(int _id, string _nama, int _nProject, double _gaji, int _fee = 15000)
        {
            nama = _nama;
            Id = _id;
            nProject = _nProject;
            Fee = _fee;
            teamType = 1;
            Gaji = _gaji;
        }

        public void calcSalary()
        {
            if (nProject <= 10)
                Gaji = nProject * Fee;
            else
                Gaji = (Fee * nProject + ((Fee - 24) * Fee * 0.1));
        }

        public void display()
        {
            //double a = Gaji();
            Console.WriteLine("Tim 3D\nNama\t: {0}\nProject\t: {1} Projects\nGaji\t: Rp{2}\n", nama, nProject, Gaji);
        }

    }

}
