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
    /// 商品属性表
    /// </summary>
    [Table("tb_G_Attribute")]
    public  class Attribute:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Attribute_Id { get; set; }

     


        /// <summary>
        /// 属性名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }


        /// <summary>
        /// 属性类型  0:普通属性（与类型绑定）  10:特殊商品属性（与商品绑定）
        /// </summary>
        public int? Type { get; set; }


    }
}
