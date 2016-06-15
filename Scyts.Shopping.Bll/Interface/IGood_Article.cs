using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Scyts.Shopping.Bll
{
  public   interface IGood_Article
    {
        Result<Model.Good_Article> Add(Model.Good_Article model);

        Result<ViewModel.ViewModel_Good_Article> Add(ViewModel.ViewModel_Good_Article model,Model.Article a_model);
        Result<Model.Good_Article> Delete(Model.Good_Article model);

        Result<int> GroupDelete(List<int> ids,List<int> a_ids);
        Result<Model.Good_Article> Update(Model.Good_Article model);


        Result<Model.Good_Article> QuerySinge(object ID);

        Result<IEnumerable<Model.Good_Article>> Query();

        Result<IEnumerable<Model.Good_Article>> Query(Expression<Func<Model.Good_Article, bool>> where);

        Result<IEnumerable<Model.Good_Article>> Query<TKey>(Expression<Func<Model.Good_Article, bool>> where, Expression<Func<Model.Good_Article, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Good_Article>> Query(int pageIndex, int pageSize, Expression<Func<Model.Good_Article, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Good_Article>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Good_Article, bool>> where, Expression<Func<Model.Good_Article, TKey>> order, bool isDesc, out int totalCount);
        Result<IEnumerable<object>> QueryByGoodId(int pageIndex, int pageSize, int good_Id, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
    }
}
