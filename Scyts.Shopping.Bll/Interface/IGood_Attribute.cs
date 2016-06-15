using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
   public interface IGood_Attribute
    {
        Result<Model.Good_Attribute> Add(Model.Good_Attribute model);
        Result<Model.Good_Attribute> Delete(Model.Good_Attribute model);

        Result<int> GroupDelete(List<int> ids);
        Result<Model.Good_Attribute> Update(Model.Good_Attribute model);
        Result<Model.Good_Attribute> QuerySinge(object ID);

        Result<IEnumerable<Model.Good_Attribute>> Query();

        Result<IEnumerable<Model.Good_Attribute>> Query(Expression<Func<Model.Good_Attribute, bool>> where);

        Result<IEnumerable<Model.Good_Attribute>> Query<TKey>(Expression<Func<Model.Good_Attribute, bool>> where, Expression<Func<Model.Good_Attribute, TKey>> order, bool isDesc);



        Result<IEnumerable<Model.Good_Attribute>> Query(int pageIndex, int pageSize, Expression<Func<Model.Good_Attribute, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);
        Result<IEnumerable<Model.Good_Attribute>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Model.Good_Attribute, bool>> where, Expression<Func<Model.Good_Attribute, TKey>> order, bool isDesc, out int totalCount);

        Result<int> AddCategoryAttribute(int id);
    }
}
