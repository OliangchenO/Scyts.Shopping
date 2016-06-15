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
    /// 商品
    /// </summary>
    [Table("tb_G_Good")]
    public class Good:Basic
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Good_Id { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        public int? Category_Id { get; set; }
        
        /// <summary>
        /// 商品编号
        /// </summary>
        [MaxLength(255)]
        public string Sn { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 点击数
        /// </summary>
        public int? ClickCount { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 品牌Id
        /// </summary>
        public int? Brand_Id { get; set; }

        /// <summary>
        /// 产地Id
        /// </summary>
        public int? Country_Id { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        [MaxLength(255)]
        public string KeyWord { get; set; }


        
    }
}
