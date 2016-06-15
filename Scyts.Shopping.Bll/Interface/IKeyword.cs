using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
  public  interface IKeyword
    {
        Result<Model.Keyword> Add(Model.Keyword model);
        Result<Model.Keyword> Delete(Model.Keyword model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Keyword> Update(Model.Keyword model);
        Result<Model.Keyword> QuerySinge(object ID);

        Result<IEnumerable<Model.Keyword>> Query();

        Result<IEnumerable<Model.Keyword>> Query(Expression<Func<Model.Keyword, bool>> where);

        Result<IEnumerable<Model.Keyword>> Query<TKey>(Expression<Func<Model.Keyword, bool>> where, Expression<Func<Model.Keyword, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Keyword>> Query(int pageIndex, int pageSize, Expression<Func<Model.Keyword, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Keyword>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Keyword, bool>> where, Expression<Func<Model.Keyword, TKey>> order, bool isDesc, out int totalCount);
    }
}
