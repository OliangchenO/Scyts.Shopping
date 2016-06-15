using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
  public  interface IAttribute
    {
        Result<Model.Attribute> Add(Model.Attribute model);
        Result<Model.Attribute> Delete(Model.Attribute model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Attribute> Update(Model.Attribute model);
        Result<Model.Attribute> QuerySinge(object ID);

        Result<IEnumerable<Model.Attribute>> Query();

        Result<IEnumerable<Model.Attribute>> Query(Expression<Func<Model.Attribute, bool>> where);

        Result<IEnumerable<Model.Attribute>> Query<TKey>(Expression<Func<Model.Attribute, bool>> where, Expression<Func<Model.Attribute, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Attribute>> Query(int pageIndex, int pageSize, Expression<Func<Model.Attribute, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Attribute>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Attribute, bool>> where, Expression<Func<Model.Attribute, TKey>> order, bool isDesc, out int totalCount);


    }
}
