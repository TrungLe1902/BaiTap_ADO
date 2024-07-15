using QLSP_ADO_Net.DBConnect;
using QLSP_ADO_Net.Validate;
using System;
using System.Data.SqlClient;

namespace QLSP_ADO_Net.Controller
{
    public class QLSuaDuLieu
    {
        public void UpdateData()
        {
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
               
                    SqlTransaction transaction = conn.BeginTransaction();

                    DBThemSuaXoa dbHandler = new DBThemSuaXoa();
                    DBCheckDuLieuTonTai dbChecker = new DBCheckDuLieuTonTai();

                    // Update Product
                    Console.WriteLine("Sửa Bảng Product");
                    int productId;
                    do
                    {
                        productId = KiemTraValidate.GetIntegerInput("Nhập productId sản phẩm cần sửa: ");
                        if (!dbChecker.KiemTraSanPhamTonTai(conn, transaction, productId))
                        {
                            Console.WriteLine("ProductID không tồn tại. Vui lòng nhập lại.");
                        }
                    } while (!dbChecker.KiemTraSanPhamTonTai(conn, transaction, productId));
                    string newProductName = KiemTraValidate.GetStringInput("Nhập tên mới cho sản phẩm: ");
                    dbHandler.SuaSanPham(conn, transaction, productId, newProductName);

                    // Update Attribute
                    if (KiemTraValidate.GetYesNoInput("Bạn có muốn sửa bảng Attribute không?"))
                    {
                        Console.WriteLine("Sửa Bảng Attribute");
                        int attributeId;
                        do
                        {
                            attributeId = KiemTraValidate.GetIntegerInput("Nhập attributeId thuộc tính cần sửa: ");
                            if (!dbChecker.KiemTraThuocTinhTonTai(conn, transaction, attributeId))
                            {
                                Console.WriteLine("AttributeID không tồn tại. Vui lòng nhập lại.");
                            }
                        } while (!dbChecker.KiemTraThuocTinhTonTai(conn, transaction, attributeId));
                        string newAttrName = KiemTraValidate.GetStringInput("Nhập newAttrName mới cho thuộc tính: ");
                        string newAttrValue = KiemTraValidate.GetStringInput("Nhập newAttrValue trị mới cho thuộc tính: ");
                        int newPrice = KiemTraValidate.GetIntegerInput("Nhập newPrice mới cho thuộc tính: ");
                        dbHandler.SuaThuocTinh(conn, transaction, productId, attributeId, newAttrName, newAttrValue, newPrice);
                    }

                    // Update ProductAttribute
                    if (KiemTraValidate.GetYesNoInput("Bạn có muốn sửa bảng ProductAttribute không?"))
                    {
                        Console.WriteLine("Sửa Bảng ProductAttribute");
                        int attributeId;
                        do
                        {
                            attributeId = KiemTraValidate.GetIntegerInput("Nhập ID thuộc tính cần sửa: ");
                            if (!dbChecker.KiemTraProductAttributeTonTai(conn, transaction, productId, attributeId))
                            {
                                Console.WriteLine("ProductAttribute không tồn tại. Vui lòng nhập lại.");
                            }
                        } while (!dbChecker.KiemTraProductAttributeTonTai(conn, transaction, productId, attributeId));
                        int newProductId = KiemTraValidate.GetIntegerInput("Nhập newProductId mới cho ProductAttribute: ");
                        int newAttributeId = KiemTraValidate.GetIntegerInput("Nhập newAttributeId mới cho Attribute: ");
                        dbHandler.SuaProductAttribute(conn, transaction, productId, attributeId, newProductId, newAttributeId);
                    }

                    // Update GroupAttribute
                    if (KiemTraValidate.GetYesNoInput("Bạn có muốn sửa bảng GroupAttribute không?"))
                    {
                        Console.WriteLine("Sửa Bảng GroupAttribute");
                        int groupId;
                        do
                        {
                            groupId = KiemTraValidate.GetIntegerInput("Nhập groupId nhóm thuộc tính cần sửa: ");
                            if (!dbChecker.KiemTraGroupAttributeTonTai(conn, transaction, groupId))
                            {
                                Console.WriteLine("GroupAttribute không tồn tại. Vui lòng nhập lại.");
                            }
                        } while (!dbChecker.KiemTraGroupAttributeTonTai(conn, transaction, groupId));
                        string newGroupName = KiemTraValidate.GetStringInput("Nhập newGroupName mới cho nhóm thuộc tính: ");
                        int newGroupPrice = KiemTraValidate.GetIntegerInput("Nhập newGroupPrice mới cho nhóm thuộc tính: ");
                        dbHandler.SuaGroupAttribute(conn, transaction, groupId, newGroupName, newGroupPrice);
                    }

                    transaction.Commit();
                    Console.WriteLine("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
