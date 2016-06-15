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
    /// 文章表
    /// </summary>
    [Table("tb_C_Article")]
    public  class Article:Basic
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Article_Id { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        [MaxLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 文章类别
        /// 0:产品文章 
        /// 10:Banner
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        [MaxLength(255)]
        public string Keyword { get; set; }


        /// <summary>
        /// 图片图
        /// </summary>
        [MaxLength(255)]
        public string ImgUri { get; set; }


        /// <summary>
        /// 图片链接
        /// </summary>
        [MaxLength(255)]
        public string LinkUri { get; set; }

     

    }
}
