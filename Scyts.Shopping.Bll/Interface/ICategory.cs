using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
  public  interface ICategory
    {
        Result<Model.Category> Add(Model.Category model);
        Result<Model.Category> Delete(Model.Category model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Category> Update(Model.Category model);
        Result<Model.Category> QuerySinge(object ID);

        Result<IEnumerable<Model.Category>> Query();

        Result<IEnumerable<Model.Category>> Query(Expression<Func<Model.Category, bool>> where);

        Result<IEnumerable<Model.Category>> Query<TKey>(Expression<Func<Model.Category, bool>> where, Expression<Func<Model.Category, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Category>> Query(int pageIndex, int pageSize, Expression<Func<Model.Category, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Category>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Category, bool>> where, Expression<Func<Model.Category, TKey>> order, bool isDesc, out int totalCount);
    }
}
