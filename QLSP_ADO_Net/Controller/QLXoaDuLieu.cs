using QLSP_ADO_Net.DBConnect;
using QLSP_ADO_Net.Validate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLSP_ADO_Net.Controller
{
    public class QLXoaDuLieu
    {
        private DBThemSuaXoa qlThemSuaXoa = new DBThemSuaXoa();
        private DBCheckDuLieuTonTai dbCheck = new DBCheckDuLieuTonTai();

        public void XoaSanPham()
        {
            int productId;
            bool productExists = false;

            do
            {
                productId = KiemTraValidate.GetIntegerInput("Nhập ProductID của sản phẩm cần xóa: ");
                using (var conn = ConnectSQLSeverDB.GetSqlConnection())
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        productExists = dbCheck.KiemTraSanPhamTonTai(conn, transaction, productId);
                        if (!productExists)
                        {
                            Console.WriteLine($"Sản phẩm với ProductID = {productId} không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            qlThemSuaXoa.XoaSanPham(conn, transaction, productId);
                            transaction.Commit();
                            Console.WriteLine($"Đã xóa sản phẩm với ProductID = {productId}");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Đã xảy ra lỗi khi xóa sản phẩm: " + ex.Message);
                    }
                }
            } while (!productExists);
        }

        public void XoaThuocTinh()
        {
            Console.WriteLine("1. Xóa từng thuộc tính của sản phẩm");
            Console.WriteLine("2. Xóa nhiều thuộc tính của sản phẩm");
            string choice = KiemTraValidate.GetStringInput("Chọn một tùy chọn: ");

            switch (choice)
            {
                case "1":
                    XoaTungThuocTinh();
                    break;
                case "2":
                    XoaNhieuThuocTinh();
                    break;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }

        private void XoaTungThuocTinh()
        {
            int productId;
            bool productExists = false;

            do
            {
                productId = KiemTraValidate.GetIntegerInput("Nhập ProductID của sản phẩm: ");
                using (var conn = ConnectSQLSeverDB.GetSqlConnection())
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        productExists = dbCheck.KiemTraSanPhamTonTai(conn, transaction, productId);
                        if (!productExists)
                        {
                            Console.WriteLine($"Sản phẩm với ProductID = {productId} không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            int attributeId = KiemTraValidate.GetIntegerInput("Nhập AttributeID của thuộc tính cần xóa: ");
                            qlThemSuaXoa.XoaThuocTinh(conn, transaction, attributeId);
                            transaction.Commit();
                            Console.WriteLine($"Đã xóa thuộc tính với AttributeID = {attributeId} của sản phẩm với ProductID = {productId}");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Đã xảy ra lỗi khi xóa thuộc tính: " + ex.Message);
                    }
                }
            } while (!productExists);
        }

        private void XoaNhieuThuocTinh()
        {
            int productId;
            bool productExists = false;

            do
            {
                productId = KiemTraValidate.GetIntegerInput("Nhập ProductID của sản phẩm: ");
                using (var conn = ConnectSQLSeverDB.GetSqlConnection())
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        productExists = dbCheck.KiemTraSanPhamTonTai(conn, transaction, productId);
                        if (!productExists)
                        {
                            Console.WriteLine($"Sản phẩm với ProductID = {productId} không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            Console.WriteLine("Nhập danh sách AttributeID của các thuộc tính cần xóa (cách nhau bởi dấu phẩy): ");
                            string input = Console.ReadLine();
                            List<int> attributeIds = new List<int>();

                            foreach (var id in input.Split(','))
                            {
                                if (int.TryParse(id.Trim(), out int attributeId))
                                {
                                    attributeIds.Add(attributeId);
                                }
                            }

                            foreach (var attributeId in attributeIds)
                            {
                                qlThemSuaXoa.XoaProductAttribute(conn, transaction, attributeId);
                            }
                            transaction.Commit();
                            Console.WriteLine($"Đã xóa các thuộc tính với AttributeIDs = {string.Join(", ", attributeIds)} của sản phẩm với ProductID = {productId}");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Đã xảy ra lỗi khi xóa thuộc tính: " + ex.Message);
                    }
                }
            } while (!productExists);
        }

    }
}
