using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
    public  interface ICommon<T> where T : class
    {

        Result<T> Add(T model);


        Result<T> Delete(T model);


        Result<T> Update(T model);

        Result<T> QuerySinge(object ID);


        Result<IEnumerable<T>> Query();




        Result<IEnumerable<T>> Query(Expression<Func<T, bool>> where);

        Result<IEnumerable<T>> Query<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool isDesc);

        Result<IEnumerable<T>> Query(int pageIndex, int pageSize, Expression<Func<T, bool>> where,List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<T>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool isDesc, out int totalCount);
    }
}
