using QLSP_ADO_Net.Controller;
using QLSP_ADO_Net.DAL;
using QLSP_ADO_Net.InterFace;
using QLSP_ADO_Net.Model;
using System;
using System.Text;

namespace QLSP_ADO_Net
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            IHienThi productDisplay = new QLDisplay(); // Khởi tạo đối tượng QLSqlDb thông qua giao diện IProductDisplay
            QLNhapDuLieu nhapDuLieu = new QLNhapDuLieu();
            QLSuaDuLieu SuaDuLieu = new QLSuaDuLieu();
            QLXoaDuLieu XoaDuLieu = new QLXoaDuLieu();

            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("===== Menu Quản Lý Sản Phẩm =====");
                Console.WriteLine("1. Hiển thị sản phẩm Theo giá cấu hình");
                Console.WriteLine("2. Hiển thị sản phẩm Theo gia thuộc tính");
                Console.WriteLine("3. Thêm sản phẩm mới");
                Console.WriteLine("4. Sửa sản phẩm");
                Console.WriteLine("5. Xoá sản phẩm");
                Console.WriteLine("6. Xoá Thuộc Tinh Sản Phẩm");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Nhập lựa chọn của bạn: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        return;
                    case 1:
                        productDisplay.DisplayProductsCauHinh();
                        break;
                    case 2:
                        productDisplay.DisplayProductsThuocTinh();
                        break;
                    case 3:
                        nhapDuLieu.NhapSanPhamMoi();
                        break;
                    case 4:
                        SuaDuLieu.UpdateData();
                        break;
                    case 5:
                        XoaDuLieu.XoaSanPham();
                        break;
                    case 6:
                        XoaDuLieu.XoaThuocTinh();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                        break;
                }
            }
        }
        
    }
}
