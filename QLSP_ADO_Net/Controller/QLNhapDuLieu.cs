using System;
using System.Collections.Generic;
using QLSP_ADO_Net.DBConnect;
using QLSP_ADO_Net.Model;
using System.Data.SqlClient;
using QLSP_ADO_Net.Validate; // Import thư viện chứa lớp KiemTraValidate

namespace QLSP_ADO_Net.Controller
{
    public class QLNhapDuLieu
    {
        private DBThemSuaXoa qlThemSuaXoa = new DBThemSuaXoa();

        public void NhapSanPhamMoi()
        {
            // Nhập thông tin sản phẩm
            ProductModel.Product product = new ProductModel.Product();
            product.Name = KiemTraValidate.GetStringInput("Nhập tên sản phẩm: ");

            // Nhập thuộc tính
            List<ProductModel.Attribute> attributes = NhapDanhSachThuocTinh();

            // Nhập GroupID cho thuộc tính
            int groupId = KiemTraValidate.GetIntegerInput("Nhập GroupID cho thuộc tính: ");

            // Thêm sản phẩm và thuộc tính vào cơ sở dữ liệu
            ThemSanPhamVaThuocTinh(product, attributes, groupId);
        }

        private List<ProductModel.Attribute> NhapDanhSachThuocTinh()
        {
            List<ProductModel.Attribute> attributes = new List<ProductModel.Attribute>();
            bool tiepTucNhap = true;

            while (tiepTucNhap)
            {
                ProductModel.Attribute attribute = new ProductModel.Attribute();
                attribute.AttrName = KiemTraValidate.GetStringInput("Nhập tên thuộc tính: ");
                attribute.AttrValue = KiemTraValidate.GetStringInput("Nhập giá trị thuộc tính: ");
                attributes.Add(attribute);

                tiepTucNhap = KiemTraValidate.GetYesNoInput("Bạn có muốn nhập thêm thuộc tính?");
            }

            return attributes;
        }

        private void ThemSanPhamVaThuocTinh(ProductModel.Product product, List<ProductModel.Attribute> attributes, int groupId)
        {
            using (var conn = ConnectSQLSeverDB.GetSqlConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Thêm sản phẩm mới vào bảng Products
                        int productId = qlThemSuaXoa.ThemProducts(conn, transaction, product.Name);

                        // Thêm thuộc tính vào bảng Atribute và ProductAttibute
                        foreach (var attribute in attributes)
                        {
                            int price = 0;

                            while (true)
                            {
                                // Nếu groupId bằng 0, yêu cầu người dùng nhập Price
                                if (groupId == 0)
                                {
                                    Console.WriteLine($"Nhập giá cho thuộc tính {attribute.AttrName} và {attribute.AttrValue}:");
                                    price = KiemTraValidate.GetIntegerInput("");
                                    break;
                                }
                                else
                                {
                                    // Kiểm tra xem groupId có tồn tại trong bảng GroupAttribute
                                    if (!KiemTraTonTaiGroupAttribute(conn, transaction, groupId))
                                    {
                                        Console.WriteLine($"GroupID {groupId} chưa tồn tại trong bảng GroupAttribute.");
                                        Console.WriteLine("Bạn có muốn nhập lại GroupID (y/n) hay thêm mới GroupAttribute (c)?");
                                        string response = Console.ReadLine();

                                        if (response.ToLower() == "y")
                                        {
                                            groupId = KiemTraValidate.GetIntegerInput("Nhập lại GroupID: ");
                                            continue;
                                        }
                                        else if (response.ToLower() == "c")
                                        {
                                            // Nhập thông tin GroupAttribute mới
                                            string groupName = KiemTraValidate.GetStringInput("Nhập tên của Group: ");
                                            price = KiemTraValidate.GetIntegerInput("Nhập giá của Group: ");

                                            // Thêm mới GroupAttribute
                                            qlThemSuaXoa.ThemGroupAttribute(conn, transaction, groupName, price);

                                            // Lấy lại ID của GroupAttribute vừa thêm
                                            groupId = qlThemSuaXoa.LayIDGroupAttribute(conn, transaction, groupName, price);
                                            break;
                                        }
                                        else
                                        {
                                            throw new Exception("Lựa chọn không hợp lệ.");
                                        }
                                    }
                                    else
                                    {
                                        // Lấy giá từ GroupAttribute đã tồn tại
                                        price = qlThemSuaXoa.LayGiaGroup(conn, transaction, groupId);
                                        break;
                                    }
                                }
                            }

                            // Thêm vào bảng Atribute
                            int attributeId = qlThemSuaXoa.ThemAtribute(conn, transaction, attribute, groupId, price);

                            // Thêm vào bảng ProductAttibute
                            qlThemSuaXoa.ThemProductAttribute(conn, transaction, productId, attributeId);
                        }

                        transaction.Commit();

                        Console.WriteLine($"Đã thêm sản phẩm thành công. ProductID = {productId}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Đã xảy ra lỗi khi thêm sản phẩm: " + ex.Message);
                    }
                }
            }
        }

        public bool KiemTraTonTaiGroupAttribute(SqlConnection conn, SqlTransaction transaction, int groupId)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GroupAttribute WHERE ID = @GroupID", conn, transaction);
            cmd.Parameters.AddWithValue("@GroupID", groupId);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

    }
}
