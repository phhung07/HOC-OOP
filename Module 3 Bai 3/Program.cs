using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_Bai_3
{
    public abstract class GiaoDich
    {
        protected string maGiaoDich;
        protected DateTime ngayGiaoDich;
        protected double donGia;
        protected int soLuong;
        public GiaoDich(string maGiaoDich, DateTime ngayGiaoDich,double donGia, int soLuong)
        {
            this.maGiaoDich = maGiaoDich;
            this.ngayGiaoDich = ngayGiaoDich;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }
        public abstract double ThanhTien();
        public int SoLuong
        {
            get { return soLuong; }
        }
        public double DonGia
        {
            get { return donGia; }
        }
        public override string ToString()
        {
            return "Ma giao dich: " + maGiaoDich +", Ngay giao dich: " + ngayGiaoDich.ToShortDateString() +", Don gia: " + donGia +", So luong: " + soLuong +", Thanh tien: " + ThanhTien();
        }
    }
    public class GiaoDichVang : GiaoDich
    {
        private string loaiVang;
        public GiaoDichVang(string maGiaoDich,DateTime ngayGiaoDich,double donGia,int soLuong,string loaiVang)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
        {
            this.loaiVang = loaiVang;
        }
        public override double ThanhTien()
        {
            return soLuong * donGia;
        }
        public override string ToString()
        {
            return base.ToString() +
                   ", Loai vang: " + loaiVang;
        }
    }
    public class GiaoDichTienTe : GiaoDich
    {
        private double tiGia;
        private string loaiTienTe;
        public GiaoDichTienTe(string maGiaoDich,DateTime ngayGiaoDich,double donGia,int soLuong,double tiGia,string loaiTienTe)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
        {
            this.tiGia = tiGia;
            this.loaiTienTe = loaiTienTe;
        }
        public override double ThanhTien()
        {
            if (loaiTienTe.ToLower() == "usd" || loaiTienTe.ToLower() == "euro")
            {
                return soLuong * donGia * tiGia;
            }
            else
            {
                return soLuong * donGia;
            }
        }
        public override string ToString()
        {
            return base.ToString() +", Ti gia: " + tiGia +", Loai tien te: " + loaiTienTe;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GiaoDich[] danhSach = new GiaoDich[6];
            danhSach[0] = new GiaoDichVang("V01",new DateTime(2026, 9, 1),80000000,2,"9999");
            danhSach[1] = new GiaoDichVang("V02",new DateTime(2026, 9, 2),90000000,3,"9999");
            danhSach[2] = new GiaoDichVang("V03",new DateTime(2026, 9, 3),1200000000,1,"9999");
            danhSach[3] = new GiaoDichTienTe("TT01",new DateTime(2026, 9, 1),25000,1000,1,"VND");
            danhSach[4] = new GiaoDichTienTe("TT02",new DateTime(2026, 9, 2),25000,2000,25000,"USD");
            danhSach[5] = new GiaoDichTienTe("TT03",new DateTime(2026, 9, 3),27000,1500,29000,"Euro");
            int tongSoLuongVang = 0;
            int tongSoLuongTienTe = 0;
            double tongThanhTienTienTe = 0;
            int soGiaoDichTienTe = 0;
            foreach (GiaoDich giaoDich in danhSach)
            {
                if (giaoDich is GiaoDichVang)
                {
                    tongSoLuongVang += giaoDich.SoLuong;
                }
                else if (giaoDich is GiaoDichTienTe)
                {
                    tongSoLuongTienTe += giaoDich.SoLuong;
                    tongThanhTienTienTe += giaoDich.ThanhTien();
                    soGiaoDichTienTe++;
                }
            }
            double trungBinhThanhTienTienTe = tongThanhTienTienTe / soGiaoDichTienTe;
            Console.WriteLine("Tong so luong giao dich vang: " + tongSoLuongVang);
            Console.WriteLine("Tong so luong giao dich tien te: " + tongSoLuongTienTe);
            Console.WriteLine("Trung binh thanh tien giao dich tien te: " + trungBinhThanhTienTienTe);
            Console.WriteLine("\nCac giao dich co don gia > 1 ty:");
            foreach (GiaoDich giaoDich in danhSach)
            {
                if (giaoDich.DonGia > 1000000000)
                {
                    Console.WriteLine(giaoDich);
                }
            }
            Console.ReadLine();
        }
    }
}
