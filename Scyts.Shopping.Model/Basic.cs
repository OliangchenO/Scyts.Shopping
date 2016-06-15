using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Model
{
    /// <summary>
    /// 通用基础属性
    /// </summary>
   public class Basic
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?  CreateDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime?  UpdateDate { get; set; }



        /// <summary>
        /// 创建人
        /// </summary>
        [MaxLength(255)]
        public string Creater { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [MaxLength(255)]
        public string Updater { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [MaxLength(255)]
        public string Status { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
