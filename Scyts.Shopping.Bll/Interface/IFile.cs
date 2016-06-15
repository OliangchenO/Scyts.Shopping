using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Scyts.Shopping.Bll
{
   public interface IFile
    {
        Result<Model.File> Add(Model.File model);
        Result<Model.File> Delete(Model.File model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.File> Update(Model.File model);
        Result<Model.File> QuerySinge(object ID);

        Result<IEnumerable<Model.File>> Query();

        Result<IEnumerable<Model.File>> Query(Expression<Func<Model.File, bool>> where);

        Result<IEnumerable<Model.File>> Query<TKey>(Expression<Func<Model.File, bool>> where, Expression<Func<Model.File, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.File>> Query(int pageIndex, int pageSize, Expression<Func<Model.File, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.File>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.File, bool>> where, Expression<Func<Model.File, TKey>> order, bool isDesc, out int totalCount);
    }
}
