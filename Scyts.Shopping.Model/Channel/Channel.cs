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
   /// 频道
   /// </summary>
   [Table("tb_Ch_Channel")]
   public class Channel:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Channel_Id { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

     
    }
}
