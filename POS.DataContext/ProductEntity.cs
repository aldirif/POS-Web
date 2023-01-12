using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_product")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("product_name")]
        public string ProductName { get; set; }

        [Required]
        public SupplierEntity Supplier { get; set; }

        [Required]
        public CategoryEntity Category { get; set; }

        [Required]
        [Column("quantity_per_unit")]
        public long QuantityPerUnit { get; set; }

        [Required]
        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Required]
        [Column("unit_in_stock")]
        public long UnitInStock { get; set; }

        [Required]
        [Column("unit_on_order")]
        public long UnitOnOrder { get; set; }

        [Required]
        [Column("reorder_level")]
        public long ReorderLevel { get; set; }

        [Required]
        [Column("discontinued")]
        public string Discontinued { get; set; }

        public ICollection<OrderDetailsEntity> orderDetailsEntities { get; set; }

        public ProductEntity(POS.ViewModel.ProductModel model)
        {
            ProductName= model.ProductName;
            UnitPrice = model.UnitPrice;
            UnitInStock= model.UnitInStock;
            UnitOnOrder= model.UnitOnOrder;
            ReorderLevel= model.ReorderLevel;
            Discontinued= model.Discontinued;

        }

        public ProductEntity()
        {

        }
    }
}
