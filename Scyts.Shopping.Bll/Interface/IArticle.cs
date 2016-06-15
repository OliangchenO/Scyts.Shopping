using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
   public interface IArticle
    {
        Result<Model.Article> Add(Model.Article model);
        Result<Model.Article> Delete(Model.Article model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Article> Update(Model.Article model);
        Result<Model.Article> QuerySinge(object ID);

        Result<IEnumerable<Model.Article>> Query();

        Result<IEnumerable<Model.Article>> Query(Expression<Func<Model.Article, bool>> where);

        Result<IEnumerable<Model.Article>> Query<TKey>(Expression<Func<Model.Article, bool>> where, Expression<Func<Model.Article, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Article>> Query(int pageIndex, int pageSize, Expression<Func<Model.Article, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Article>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Article, bool>> where, Expression<Func<Model.Article, TKey>> order, bool isDesc, out int totalCount);

      
    }
}
