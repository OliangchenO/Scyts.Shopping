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
    /// 关键字
    /// </summary>
    [Table("tb_C_Keyword")]
   public class Keyword:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Keyword_Id { get; set; }

        /// <summary>
        /// 关键词显示
        /// </summary>
        [MaxLength(255)]
        public string Key { get; set; }

        /// <summary>
        /// 关键词值
        /// </summary>
        [MaxLength(255)]
        public string Value { get; set; }

        /// <summary>
        /// 搜索数
        /// </summary>
        public int? SearchCount { get; set; }
    }
}
