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
    /// 国别
    /// </summary>
    [Table("tb_C_Country")]
    public class Country:Basic
    {
        /// <summary>
        /// 国别Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Country_Id { get; set; }

        /// <summary>
        /// 国别名称
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 国别图片
        /// </summary>
        [MaxLength(255)]
        public string ImgUri { get; set; }

    }
}
