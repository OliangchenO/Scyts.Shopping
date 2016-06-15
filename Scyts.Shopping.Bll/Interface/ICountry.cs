using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
    public interface ICountry
    {
        Result<Model.Country> Add(Model.Country model);
        Result<Model.Country> Delete(Model.Country model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Country> Update(Model.Country model);
        Result<Model.Country> QuerySinge(object ID);

        Result<IEnumerable<Model.Country>> Query();

        Result<IEnumerable<Model.Country>> Query(Expression<Func<Model.Country, bool>> where);

        Result<IEnumerable<Model.Country>> Query<TKey>(Expression<Func<Model.Country, bool>> where, Expression<Func<Model.Country, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Country>> Query(int pageIndex, int pageSize, Expression<Func<Model.Country, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Country>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Country, bool>> where, Expression<Func<Model.Country, TKey>> order, bool isDesc, out int totalCount);
    }
}
