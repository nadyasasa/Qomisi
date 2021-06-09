using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_2
{

    public interface Karyawan
    {
        string nama { get; set; }
        int Id { get; set; }
        double Gaji { get; set; }

        int teamType { get; set; }
        void calcSalary();
        void display();
        //{
        //double a = Gaji();
        //Console.WriteLine("Tim Denah\nNama\t: {0}\nJam\t: {1} Hours\nGaji\t: {2}\n", nama, waktu, a);
        //}

    }


}
