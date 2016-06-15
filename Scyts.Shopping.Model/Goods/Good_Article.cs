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
    /// 商品文章（关联）
    /// </summary>
    [Table("tb_G_Good_Article")]
    public class Good_Article:Basic
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
        /// 文章Id
        /// </summary>
        public int? Article_Id { get; set; }

        /// <summary>
        /// 商品文章图片Uri
        /// </summary>
        [MaxLength(255)]
        public string ImgUri { get; set; }


    }
}
