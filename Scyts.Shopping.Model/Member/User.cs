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
    /// 用户
    /// </summary>
    [Table("tb_M_User")]
    public class User:Basic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(255)]
        public string MobilePhone { get; set; }



        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(255)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(255)]
        public string PassWord { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
