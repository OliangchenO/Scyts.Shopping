using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scyts.Shopping.Model
{
    [Table("tb_G_Good_File")]
    public  class Good_File:Basic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Good_Id { get; set; }

        public int? File_Id { get; set; }
    }
}
