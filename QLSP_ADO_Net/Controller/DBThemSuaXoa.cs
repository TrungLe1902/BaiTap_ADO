using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLSP_ADO_Net.Model;
using QLSP_ADO_Net.DBConnect;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data;

namespace QLSP_ADO_Net.Controller
{
    public class DBThemSuaXoa
    {
        //============Thêm Sản Phẩm==========================
        public int ThemProducts(SqlConnection conn, SqlTransaction transaction, string productName)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemProducts", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", productName);
            return (int)cmd.ExecuteScalar();
        }

        public int ThemAtribute(SqlConnection conn, SqlTransaction transaction, ProductModel.Attribute attribute, int groupId, int price)
        {
            SqlCommand cmdAttr = new SqlCommand("sp_ThemAtribute", conn, transaction);
            cmdAttr.CommandType = CommandType.StoredProcedure;
            cmdAttr.Parameters.AddWithValue("@AttrName", attribute.AttrName);
            cmdAttr.Parameters.AddWithValue("@AttrValue", attribute.AttrValue);
            cmdAttr.Parameters.AddWithValue("@GroupID", groupId);
            cmdAttr.Parameters.AddWithValue("@Price", price);
            return (int)cmdAttr.ExecuteScalar();
        }

        public void ThemProductAttribute(SqlConnection conn, SqlTransaction transaction, int productId, int attributeId)
        {
            SqlCommand cmdProdAttr = new SqlCommand("sp_ThemProductAttribute", conn, transaction);
            cmdProdAttr.CommandType = CommandType.StoredProcedure;
            cmdProdAttr.Parameters.AddWithValue("@ProductID", productId);
            cmdProdAttr.Parameters.AddWithValue("@AttributeID", attributeId);
            cmdProdAttr.ExecuteNonQuery();
        }
        public void ThemGroupAttribute(SqlConnection conn, SqlTransaction transaction, string groupName, int Price)
        {
            SqlCommand cmdGroupAtt = new SqlCommand("sp_ThemGroupAttribute", conn, transaction);
            cmdGroupAtt.CommandType = CommandType.StoredProcedure;
            cmdGroupAtt.Parameters.AddWithValue("@Name", groupName);
            cmdGroupAtt.Parameters.AddWithValue("@Price", Price);
            cmdGroupAtt.ExecuteNonQuery();
        }

        public int LayIDGroupAttribute(SqlConnection conn, SqlTransaction transaction, string groupName, int price)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM GroupAttribute WHERE Name = @GroupName AND Price = @Price", conn, transaction);
            cmd.Parameters.AddWithValue("@GroupName", groupName);
            cmd.Parameters.AddWithValue("@Price", price);
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1; // Trả về -1 nếu không tìm thấy
        }

        public int LayGiaGroup(SqlConnection conn, SqlTransaction transaction, int groupId)
        {
            SqlCommand cmdGroup = new SqlCommand("sp_LayGiaGroup", conn, transaction);
            cmdGroup.CommandType = CommandType.StoredProcedure;
            cmdGroup.Parameters.AddWithValue("@GroupID", groupId);
            return (int)cmdGroup.ExecuteScalar();
        }


        //============Sửa Sản Phẩm==========================
        public void SuaSanPham(SqlConnection conn, SqlTransaction transaction, int productId, string newProductName)
        {
            SqlCommand cmd = new SqlCommand("UpdateProduct", conn, transaction);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@NewName", newProductName);
            cmd.ExecuteNonQuery();
        }

        public void SuaThuocTinh(SqlConnection conn, SqlTransaction transaction, int productId, int attributeId, string newAttrName, string newAttrValue, int newPrice)
        {
            SqlCommand cmd = new SqlCommand("UpdateAtribute", conn, transaction);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@AttributeID", attributeId);
            cmd.Parameters.AddWithValue("@NewAttrName", newAttrName);
            cmd.Parameters.AddWithValue("@NewAttrValue", newAttrValue);
            cmd.Parameters.AddWithValue("@NewPrice", newPrice);
            cmd.ExecuteNonQuery();
        }

        public void SuaProductAttribute(SqlConnection conn, SqlTransaction transaction, int productId, int attributeId, int newProductId, int newAttributeId)
        {
            SqlCommand cmd = new SqlCommand("UpdateProductAttribute", conn, transaction);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@AttributeID", attributeId);
            cmd.Parameters.AddWithValue("@NewProductID", newProductId);
            cmd.Parameters.AddWithValue("@NewAttributeID", newAttributeId);
            cmd.ExecuteNonQuery();
        }

        public void SuaGroupAttribute(SqlConnection conn, SqlTransaction transaction, int groupId, string newGroupName, int newPrice)
        {
            SqlCommand cmd = new SqlCommand("UpdateGroupAttribute", conn, transaction);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupID", groupId);
            cmd.Parameters.AddWithValue("@NewName", newGroupName);
            cmd.Parameters.AddWithValue("@NewPrice", newPrice);
            cmd.ExecuteNonQuery();
        }
        //============Xóa Sản Phẩm==========================
        public void XoaSanPham(SqlConnection conn, SqlTransaction transaction, int productId)
        {
            SqlCommand cmd = new SqlCommand("DeleteProduct", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.ExecuteNonQuery();
        }

        public void XoaProductAttribute(SqlConnection conn, SqlTransaction transaction, int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteProductAttribute", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }

        public void XoaThuocTinh(SqlConnection conn, SqlTransaction transaction, int attributeId)
        {
            SqlCommand cmd = new SqlCommand("DeleteAtribute", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", attributeId);
            cmd.ExecuteNonQuery();
        }



        public void XoaGroupAttribute(SqlConnection conn, SqlTransaction transaction, int groupId)
        {
            SqlCommand cmd = new SqlCommand("DeleteGroupAttribute", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupID", groupId);
            cmd.ExecuteNonQuery();
        }

    }
}
