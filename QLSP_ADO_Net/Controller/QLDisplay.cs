using QLSP_ADO_Net.DBConnect;
using QLSP_ADO_Net.InterFace;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLSP_ADO_Net.DAL
{
    public class QLDisplay : IHienThi
    {
        public void DisplayProductsCauHinh()
        {
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllProductsInfo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-10}",
                                "ProductID", "ProductName", "AttributeID", "AttrName", "AttrValue", "AttributePrice", "GroupName", "GroupPrice");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-10}",
                                    reader["ProductID"], reader["ProductName"], reader["AttributeID"],
                                    reader["AttrName"], reader["AttrValue"], reader["AttributePrice"], reader["GroupName"], reader["GroupPrice"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    
        public void DisplayProductsThuocTinh()
        {
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
            

                    SqlCommand cmd = new SqlCommand("GetProductAttributes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu dưới dạng bảng
                    Console.WriteLine("Danh sách sản phẩm và thuộc tính:");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-20} {4,-20} {5,-10} {6,-10}",
                        "ProductID", "ProductName", "AttributeID", "AttrName", "AttrValue", "GROUPID", "AttributePrice");
                    Console.WriteLine("-----------------------------------------------------------");

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-20} {4,-20} {5,-10} {6,-10}",
                            row["ProductID"], row["ProductName"], row["AttributeID"], row["AttrName"],
                            row["AttrValue"], row["GROUPID"], row["AttributePrice"]);
                    }

                    Console.WriteLine("-----------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
