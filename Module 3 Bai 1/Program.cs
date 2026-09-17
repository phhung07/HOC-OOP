using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_Bai_1
{
    public class ChuyenXe
    {
        protected string maSoChuyen;
        protected string hoTenTaiXe;
        protected string soXe;
        protected double doanhThu;
        public ChuyenXe(string maSoChuyen, string hoTenTaiXe,
                        string soXe, double doanhThu)
        {
            this.maSoChuyen = maSoChuyen;
            this.hoTenTaiXe = hoTenTaiXe;
            this.soXe = soXe;
            this.doanhThu = doanhThu;
        }
        public virtual double TinhDoanhThu()
        {
            return doanhThu;
        }
    }
    public class ChuyenXeNoiThanh : ChuyenXe
    {
        private int soTuyen;
        private double soKm;
        public ChuyenXeNoiThanh(
            string maSoChuyen,
            string hoTenTaiXe,
            string soXe,
            int soTuyen,
            double soKm,
            double doanhThu)
            : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            this.soTuyen = soTuyen;
            this.soKm = soKm;
        }
        public override double TinhDoanhThu()
        {
            return doanhThu;
        }
    }
    public class ChuyenXeNgoaiThanh : ChuyenXe
    {
        private string noiDen;
        private int soNgay;
        public ChuyenXeNgoaiThanh(
            string maSoChuyen,
            string hoTenTaiXe,
            string soXe,
            string noiDen,
            int soNgay,
            double doanhThu)
            : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            this.noiDen = noiDen;
            this.soNgay = soNgay;
        }
        public override double TinhDoanhThu()
        {
            return doanhThu;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChuyenXe[] danhSach = new ChuyenXe[4];

            danhSach[0] = new ChuyenXeNoiThanh(
                "NT01", "Nguyen Van A", "59A-12345",
                5, 100, 500000);

            danhSach[1] = new ChuyenXeNoiThanh(
                "NT02", "Nguyen Van B", "59B-67890",
                8, 150, 700000);

            danhSach[2] = new ChuyenXeNgoaiThanh(
                "NT03", "Nguyen Van C", "59C-11111",
                "Da Lat", 3, 2000000);

            danhSach[3] = new ChuyenXeNgoaiThanh(
                "NT04", "Nguyen Van D", "59D-22222",
                "Vung Tau", 2, 1500000);

            double tongNoiThanh = 0;
            double tongNgoaiThanh = 0;

            foreach (ChuyenXe xe in danhSach)
            {
                if (xe is ChuyenXeNoiThanh)
                {
                    tongNoiThanh += xe.TinhDoanhThu();
                }
                else if (xe is ChuyenXeNgoaiThanh)
                {
                    tongNgoaiThanh += xe.TinhDoanhThu();
                }
            }
            double tongTatCa = tongNoiThanh + tongNgoaiThanh;
            Console.WriteLine("Tong doanh thu noi thanh: " + tongNoiThanh);
            Console.WriteLine("Tong doanh thu ngoai thanh: " + tongNgoaiThanh);
            Console.WriteLine("Tong doanh thu tat ca: " + tongTatCa);
            Console.ReadLine();
        }
    }
}
