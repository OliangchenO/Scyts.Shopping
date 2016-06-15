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
    [Table("tb_Ch_Channel_Category")]
    public class Channel_Category:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 频道Id
        /// </summary>
        public int? Channel_Id { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        public int? Category_Id { get; set; }
    }
}
