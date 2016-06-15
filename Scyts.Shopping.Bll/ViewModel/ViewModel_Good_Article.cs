using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll.ViewModel
{
   public  class ViewModel_Good_Article:Model.Article
    {

        public int Id { get; set; }

        public int? Good_Id { get; set; }

    }
}
