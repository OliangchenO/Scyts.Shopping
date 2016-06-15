using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Model
{
    /// <summary>
    /// 分类属性（关联表）
    /// </summary>
    [Table("tb_G_Category_Attribute")]
   public class Category_Attribute
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 商品分类Id
        /// </summary>
        public int? Category_Id { get; set; }

        /// <summary>
        /// 商品品牌Id
        /// </summary>
        public int? Attribute_Id { get; set; }
    }
}
