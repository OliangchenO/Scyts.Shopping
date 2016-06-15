using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Scyts.Shopping.Bll
{
  public  interface IGood_File
    {

        Result<Model.Good_File> Add(Model.Good_File model);

        Result<ViewModel.ViewModel_Good_File> Add(ViewModel.ViewModel_Good_File model, Model.File a_model);
        Result<Model.Good_File> Delete(Model.Good_File model);

        Result<int> GroupDelete(List<int> ids, List<int> a_ids);
        Result<Model.Good_File> Update(Model.Good_File model);


        Result<Model.Good_File> QuerySinge(object ID);

        Result<IEnumerable<Model.Good_File>> Query();

        Result<IEnumerable<Model.Good_File>> Query(Expression<Func<Model.Good_File, bool>> where);

        Result<IEnumerable<Model.Good_File>> Query<TKey>(Expression<Func<Model.Good_File, bool>> where, Expression<Func<Model.Good_File, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Good_File>> Query(int pageIndex, int pageSize, Expression<Func<Model.Good_File, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Good_File>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Good_File, bool>> where, Expression<Func<Model.Good_File, TKey>> order, bool isDesc, out int totalCount);
        Result<IEnumerable<object>> QueryByGoodId(int pageIndex, int pageSize, int good_Id, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
    }
}
