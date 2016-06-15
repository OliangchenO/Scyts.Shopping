using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWork.Extend;
using Scyts.Shopping.Model;

namespace Scyts.Shopping.Bll.Impl
{
    class Article : Common<Model.Article>, IArticle
    {
        public Result<int> GroupDelete(List<int> ids)
        {
            return ExecuteDelegate.ExeTran<int>(delegate ()
            {
                using (MyDbContext db = new S_DbContext())
                {

                    StringBuilder sb = new StringBuilder("delete from tb_g_attribute where article_id in ");
                    StringBuilder delIds = new StringBuilder("(");
                    List<Param> paramList = new List<Param>();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        delIds.Append("@id" + i);
                        paramList.Add(new Param() { Name = "@id" + i, Value = ids[i], ParamType = 20 });
                        delIds.Append(",");
                    }
                    delIds.Length--;
                    delIds.Append(")");
                    sb.Append(delIds);
                    sb.Append(";");

                    var result = SqlProvider.ExecuteSql(sb.ToString(), paramList, db);
                    return result;
                }
            });

        }

        
    }
}
