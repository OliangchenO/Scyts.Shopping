using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWork.Extend;
using Scyts.Shopping.Bll.ViewModel;
using Scyts.Shopping.Model;

namespace Scyts.Shopping.Bll.Impl
{
    class Good : Common<Model.Good>, IGood
    {
        public Result<int> GroupDelete(List<int> ids)
        {
            return ExecuteDelegate.Exe<int>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    StringBuilder sb = new StringBuilder("delete from tb_c_Good where Good_Id in (");
                    List<Param> paramList = new List<Param>();
                    for(int i=0;i<ids.Count;i++) {                
                        sb.Append("@id"+i);
                        paramList.Add(new Param() { Name = "@id" + i, Value = ids[i], ParamType = 20 });
                        sb.Append(",");
                    }
                    sb.Length--;
                    sb.Append(")");
                    var result = SqlProvider.ExecuteSql(sb.ToString(), paramList, db);
                    return result;
                }
            });
        }

    
    }
}
