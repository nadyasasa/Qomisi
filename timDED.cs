using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_2
{
    public class TimDED : Karyawan
    {
        private double Fee { get; set; } // gaji tiap gambar luas 100m2
        private double luas { get; set; }

        public TimDED(int _id, string _nama, int _luas, double _gaji, int _fee = 40000)
        {
            nama = _nama;
            Id = _id;
            luas = _luas;
            Fee = _fee;
            teamType = 2;
            Gaji = _gaji;
         }

        public string nama { get; set; }
        public int Id { get; set; }
        public double Gaji { get; set; }
        public int teamType { get; set; }
        public void calcSalary()
        {
            if (luas % 100 == 0)
                Gaji = Fee * (luas / 100);
            else
                Gaji = (luas * 7500);
        }
        public void display()
        {
            //double a = Gaji();
            Console.WriteLine("Tim DED\nNama\t: {0}\nLuas\t: {1} m2\nGaji\t: Rp{2}\n", nama, luas, Gaji);
        }
    }

}
