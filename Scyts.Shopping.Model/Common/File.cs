using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Model
{
    [Table("tb_C_File")]
    public class File:Basic
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int File_Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FileName { get; set; }

        [MaxLength(255)]
        public string FilePath { get; set; }




    }
}
