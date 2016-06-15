using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll.ViewModel
{
   public  class Tree
    {

        public Tree() {
            this.children = new List<Tree>();
        }
        public int id { get; set; }

        public string text { get; set; }

        public int? parent { get; set; }

        public   List<Tree> children { get; set; }
    }
}
