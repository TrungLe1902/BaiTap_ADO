using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_Net.Model
{
    public class ProductModel
    {
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
        }

        public class ProductAttribute
        {
            public int ID { get; set; }
            public int ProductID { get; set; }
            public int AttributeID { get; set; }
        }

        public class Attribute
        {
            public int ID { get; set; }
            public string AttrName { get; set; }
            public string AttrValue { get; set; }
            public int GroupID { get; set; }
            public int Price { get; set; }
        }

        public class GroupAttribute
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }


    }
}
