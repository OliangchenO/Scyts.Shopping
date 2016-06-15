using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
    public interface IGood
    {
        Result<Model.Good> Add(Model.Good model);
        Result<Model.Good> Delete(Model.Good model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Good> Update(Model.Good model);
        Result<Model.Good> QuerySinge(object ID);

        Result<IEnumerable<Model.Good>> Query();

        Result<IEnumerable<Model.Good>> Query(Expression<Func<Model.Good, bool>> where);

        Result<IEnumerable<Model.Good>> Query<TKey>(Expression<Func<Model.Good, bool>> where, Expression<Func<Model.Good, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Good>> Query(int pageIndex, int pageSize, Expression<Func<Model.Good, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Good>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Good, bool>> where, Expression<Func<Model.Good, TKey>> order, bool isDesc, out int totalCount);

       


    }
}
