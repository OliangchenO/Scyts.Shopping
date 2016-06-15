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
    /// 品牌表
    /// </summary>
    [Table("tb_G_Brand")]
    public class Brand:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Brand_Id { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 品牌LOGO图片Uri
        /// </summary>
        [MaxLength(255)]
        public string LogoImgUri { get; set; }


        /// <summary>
        /// 品牌描述
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 品牌链接
        /// </summary>
        [MaxLength(255)]
        public  string SiteUri { get; set; }

    }
}
