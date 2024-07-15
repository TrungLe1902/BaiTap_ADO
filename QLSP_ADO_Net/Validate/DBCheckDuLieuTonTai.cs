using System.Data;
using System.Data.SqlClient;

namespace QLSP_ADO_Net.Validate
{
    public class DBCheckDuLieuTonTai
    {
        public bool KiemTraSanPhamTonTai(SqlConnection conn, SqlTransaction transaction, int productId)
        {
            SqlCommand cmd = new SqlCommand("KiemTraSanPhamTonTai", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit);
            existsParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(existsParam);

            cmd.ExecuteNonQuery();

            return (bool)existsParam.Value;
        }

        public bool KiemTraThuocTinhTonTai(SqlConnection conn, SqlTransaction transaction, int attributeId)
        {
            SqlCommand cmd = new SqlCommand("KiemTraThuocTinhTonTai", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AttributeID", attributeId);
            SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit);
            existsParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(existsParam);

            cmd.ExecuteNonQuery();

            return (bool)existsParam.Value;
        }

        public bool KiemTraProductAttributeTonTai(SqlConnection conn, SqlTransaction transaction, int productId, int attributeId)
        {
            SqlCommand cmd = new SqlCommand("KiemTraProductAttributeTonTai", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@AttributeID", attributeId);
            SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit);
            existsParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(existsParam);

            cmd.ExecuteNonQuery();

            return (bool)existsParam.Value;
        }

        public bool KiemTraGroupAttributeTonTai(SqlConnection conn, SqlTransaction transaction, int groupId)
        {
            SqlCommand cmd = new SqlCommand("KiemTraGroupAttributeTonTai", conn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupID", groupId);
            SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit);
            existsParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(existsParam);

            cmd.ExecuteNonQuery();

            return (bool)existsParam.Value;
        }
    }
}
