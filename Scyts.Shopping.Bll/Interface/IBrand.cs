using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
  public  interface IBrand
    {
        Result<Model.Brand> Add(Model.Brand model);
        Result<Model.Brand> Delete(Model.Brand model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Brand> Update(Model.Brand model);
        Result<Model.Brand> QuerySinge(object ID);

        Result<IEnumerable<Model.Brand>> Query();

        Result<IEnumerable<Model.Brand>> Query(Expression<Func<Model.Brand, bool>> where);

        Result<IEnumerable<Model.Brand>> Query<TKey>(Expression<Func<Model.Brand, bool>> where, Expression<Func<Model.Brand, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Brand>> Query(int pageIndex, int pageSize, Expression<Func<Model.Brand, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Brand>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Brand, bool>> where, Expression<Func<Model.Brand, TKey>> order, bool isDesc, out int totalCount);

      
    }
}
