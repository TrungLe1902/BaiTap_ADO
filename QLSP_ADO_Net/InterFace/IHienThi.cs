using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLSP_ADO_Net.Model.ProductModel;

namespace QLSP_ADO_Net.InterFace
{
    public interface IHienThi
    {
        void DisplayProductsCauHinh();
        void DisplayProductsThuocTinh();
    }

}
