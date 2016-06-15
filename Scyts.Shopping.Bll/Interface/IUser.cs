using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
   public interface IUser
    {
        Result<Model.User> Add(Model.User model);
        Result<Model.User> Delete(Model.User model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.User> Update(Model.User model);
        Result<Model.User> QuerySinge(object ID);

        Result<IEnumerable<Model.User>> Query();

        Result<IEnumerable<Model.User>> Query(Expression<Func<Model.User, bool>> where);

        Result<IEnumerable<Model.User>> Query<TKey>(Expression<Func<Model.User, bool>> where, Expression<Func<Model.User, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.User>> Query(int pageIndex, int pageSize, Expression<Func<Model.User, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.User>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.User, bool>> where, Expression<Func<Model.User, TKey>> order, bool isDesc, out int totalCount);
    }
}
