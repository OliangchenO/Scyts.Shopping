using EntityFrameWork.Extend;
using Scyts.Shopping.Bll.ViewModel;
using Scyts.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scyts.Shopping.Bll.Impl
{
     class Good_File : Common<Model.Good_File>, IGood_File
    {


        public Result<ViewModel.ViewModel_Good_File> Add(ViewModel_Good_File model, Model.File a_model)
        {
            return ExecuteDelegate.ExeTran<ViewModel_Good_File>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {



                    DaoProvider.CreateDao<Model.File>().Add(a_model, db);
                    db.SaveChanges();
                    var ga = new Model.Good_File() { Good_Id = model.Good_Id, File_Id = a_model.File_Id };
                    DaoProvider.CreateDao<Model.Good_File>().Add(ga, db);
                    db.SaveChanges();
                    model.Id = ga.Id;
                    model.Good_Id = ga.Good_Id;
                    model.File_Id = a_model.File_Id;
                    return model;
                }

            });
        }




        public Result<int> GroupDelete(List<int> ids, List<int> a_ids)
        {
            return ExecuteDelegate.ExeTran<int>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {

                    StringBuilder sb = new StringBuilder("");
                    List<Param> paramList = new List<Param>();
                    if (ids.Count > 0)
                    {
                        sb.Append("delete from tb_G_Good_File where Id in (");

                        for (int i = 0; i < ids.Count; i++)
                        {
                            sb.Append("@id" + i);
                            paramList.Add(new Param() { Name = "@id" + i, Value = ids[i], ParamType = 20 });
                            sb.Append(",");
                        }
                        sb.Length--;
                        sb.Append(")");
                    }
                    if (a_ids.Count > 0)
                    {
                        sb.Append("delete from tb_c_File where File_Id in (");

                        for (int i = 0; i < a_ids.Count; i++)
                        {
                            sb.Append("@a_id" + i);
                            paramList.Add(new Param() { Name = "@a_id" + i, Value = a_ids[i], ParamType = 20 });
                            sb.Append(",");
                        }
                        sb.Length--;
                        sb.Append(")");
                    }
                    var result = SqlProvider.ExecuteSql(sb.ToString(), paramList, db);
                    return result;
                }
            });
        }


        public Result<IEnumerable<object>> QueryByGoodId(int pageIndex, int pageSize, int good_Id, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount)
        {
            var count = 0;
            var result = ExecuteDelegate.ExeTran<IEnumerable<object>>(delegate ()
            {
                using (MyDbContext db = new S_DbContext())
                {
                    var data = from ga in db.Set<Model.Good_File>()
                               join a in db.Set<Model.File>() on ga.File_Id equals a.File_Id
                               where ga.Good_Id == good_Id
                               select new ViewModel.ViewModel_Good_File
                               {
                                   File_Id = a.File_Id,
                                   Id = ga.Id,
                                  FileName=a.FileName,
                                  FilePath=a.FilePath,
                                  Name=a.Name,
                                   CreateDate = a.CreateDate,
                                   Creater = a.Creater,
                                   
                                   Sort = a.Sort,
                                   Status = a.Status,
                               
                                   UpdateDate = a.UpdateDate,
                                   Updater = a.Updater,
                                   Good_Id = ga.Good_Id
                               };
                    var query = QueryProvider.OrderBy(data, orderParamList);

                    return query.ToList();
                }

            });
            totalCount = count;

            return result;
        }

    }
}
