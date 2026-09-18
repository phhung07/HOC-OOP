using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_Bai_2
{
    public abstract class Sach
    {
        protected string maSach;
        protected DateTime ngayNhap;
        protected double donGia;
        protected int soLuong;
        protected string nhaXuatBan;
        public Sach(string maSach, DateTime ngayNhap,double donGia, int soLuong,string nhaXuatBan)
        {
            this.maSach = maSach;
            this.ngayNhap = ngayNhap;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.nhaXuatBan = nhaXuatBan;
        }
        public abstract double ThanhTien();
        public string MaSach
        {
            get { return maSach; }
        }
        public string NhaXuatBan
        {
            get { return nhaXuatBan; }
        }
        public override string ToString()
        {
            return "Ma sach: " + maSach +", Ngay nhap: " + ngayNhap.ToShortDateString() +", Don gia: " + donGia +", So luong: " + soLuong +", NXB: " + nhaXuatBan +", Thanh tien: " + ThanhTien();
        }
    }
    public class SachGiaoKhoa : Sach
    {
        private string tinhTrang;
        public SachGiaoKhoa(string maSach,DateTime ngayNhap,double donGia,int soLuong,string nhaXuatBan,string tinhTrang)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.tinhTrang = tinhTrang;
        }
        public override double ThanhTien()
        {
            if (tinhTrang.ToLower() == "moi")
            {
                return soLuong * donGia;
            }
            else
            {
                return soLuong * donGia * 0.5;
            }
        }
        public override string ToString()
        {
            return base.ToString() + ", Tinh trang: " + tinhTrang;
        }
    }
    public class SachThamKhao : Sach
    {
        private double thue;
        public SachThamKhao(string maSach,DateTime ngayNhap,double donGia,int soLuong,string nhaXuatBan,double thue)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.thue = thue;
        }
        public override double ThanhTien()
        {
            return soLuong * donGia + thue;
        }
        public override string ToString()
        {
            return base.ToString() + ", Thue: " + thue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sach[] danhSach = new Sach[6];
            danhSach[0] = new SachGiaoKhoa("SGK01",new DateTime(2026, 9, 1),50000,10,"K","moi");
            danhSach[1] = new SachGiaoKhoa("SGK02",new DateTime(2026, 9, 2),60000,5,"A","cu");
            danhSach[2] = new SachGiaoKhoa("SGK03",new DateTime(2026, 9, 3),70000,8,"K","moi");
            danhSach[3] = new SachThamKhao("STK01",new DateTime(2026, 9, 1),80000,5,"B",10000);
            danhSach[4] = new SachThamKhao("STK02",new DateTime(2026, 9, 2),90000,10,"C",20000);
            danhSach[5] = new SachThamKhao("STK03",new DateTime(2026, 9, 3),100000,6,"D",15000);
            double tongSGK = 0;
            double tongSTK = 0;
            foreach (Sach sach in danhSach)
            {
                if (sach is SachGiaoKhoa)
                {
                    tongSGK += sach.ThanhTien();
                }
                else if (sach is SachThamKhao)
                {
                    tongSTK += sach.ThanhTien();
                }
            }
            Console.WriteLine("Tong thanh tien sach giao khoa: " + tongSGK);
            Console.WriteLine("Tong thanh tien sach tham khao: " + tongSTK);
            Console.Write("\nNhap nha xuat ban K: ");
            string K = Console.ReadLine();
            Console.WriteLine("\nSach giao khoa cua NXB " + K + ":");
            foreach (Sach sach in danhSach)
            {
                if (sach is SachGiaoKhoa && sach.NhaXuatBan.Equals(K, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(sach);
                }
            }
            Sach sachMax = danhSach[0];
            foreach (Sach sach in danhSach)
            {
                if (sach.ThanhTien() > sachMax.ThanhTien())
                {
                    sachMax = sach;
                }
            }
            Console.WriteLine("\nSach co thanh tien cao nhat:");
            Console.WriteLine(sachMax);
            Console.ReadLine();
        }
    }
}