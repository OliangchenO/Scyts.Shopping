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
    /// 商品属性(关联)
    /// </summary>
    [Table("tb_G_Good_Attribute")]
   public class Good_Attribute:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int? Good_Id { get; set; }

   

        /// <summary>
        /// 属性值
        /// </summary>
        [MaxLength(255)]
        public string Value { get; set; }


        /// <summary>
        /// 属性名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
