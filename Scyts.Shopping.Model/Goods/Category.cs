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
    /// 商品分类表
    /// </summary>
    [Table("tb_G_Category")]
    public class Category:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_Id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 父级ID -Category_Id
        /// </summary>
        public int? Parent_Id { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        [MaxLength(255)]
        public string Keyword { get; set; }

        [NotMapped]
        public int? id { get; set; }
        [NotMapped]
        public int? _parentId { get; set; }
    }
}
