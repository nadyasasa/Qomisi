using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_2
{
    class TimDenah : Karyawan
    {
        private double Fee { get; set; } //Fee per jam
        private double hours { get; set; } // jam kerja dalam seminggu

        public TimDenah(int _id, string _nama, int _hours, double _gaji, int _fee = 20000)
        {
            nama = _nama;
            Id = _id;
            hours = _hours;
            Fee = _fee;
            teamType = 3;
            Gaji = _gaji;
        }

        public string nama { get; set; }
        public int Id { get; set; }
        public double Gaji { get; set; }
        public int teamType { get; set; }
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value >= 0 && value <= 168)
                    hours = value;
                else throw new ArgumentOutOfRangeException("Jam", value, "Jam harus >=0 dan <= 168");
            }
        }
        public void calcSalary()
        {
            if (hours <= 24)
                Gaji = Fee * Hours;
            else
                Gaji = (Fee * Hours + ((Hours - 24) * Fee * 0.1));
        }
        public void display()
        {
            //double a = Gaji();
            Console.WriteLine("Tim Denah\nNama\t: {0}\nJam\t: {1} Hours\nGaji\t: Rp{2}\n", nama, Hours, Gaji);
        }

    }
}
