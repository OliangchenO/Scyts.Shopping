using EntityFrameWork.Extend;
using Scyts.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll.Impl
{
    class Good_Attribute : Common<Model.Good_Attribute>, IGood_Attribute
    {
        public Result<int> GroupDelete(List<int> ids)
        {
            return ExecuteDelegate.Exe<int>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    StringBuilder sb = new StringBuilder("delete from tb_G_Good_Attribute where Id in (");
                    List<Param> paramList = new List<Param>();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        sb.Append("@id" + i);
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

        public Result<int> AddCategoryAttribute(int id) {
            return ExecuteDelegate.Exe<int>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    //获取要添加的
                    var good = DaoProvider.CreateDao<Model.Good>().QuerySingle(id, db);
                    if (good != null)
                    {
                        var attributeList = (from a in db.Set<Model.Category_Attribute>()
                                            join b in db.Set<Model.Attribute>() on a.Attribute_Id equals b.Attribute_Id

                                            where a.Category_Id == good.Category_Id
                                            select b.Name).ToList();

                        foreach (var attribute in attributeList)
                        {
                            DaoProvider.CreateDao<Model.Good_Attribute>().Add(new Model.Good_Attribute() { Name = attribute, CreateDate = DateTime.Now, Good_Id = id ,Sort=0,Status="0"}, db);
                            db.SaveChanges();
                        }

                        return 0;
                    }
                    else {
                        return 1;
                    }
                }
            });
        }

    }
}
