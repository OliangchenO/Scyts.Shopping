using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scyts.Shopping.Model;
using System.Linq.Expressions;

namespace Scyts.Shopping.Bll.Impl
{
    class Common<T> : ICommon<T> where T : class
    {
        public Result<T> Add(T model)
        {
            return ExecuteDelegate.Exe<T>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    DaoProvider.CreateDao<T>().Add(model, db);
                    db.SaveChanges();
                    return model;
                }
            });

        }

        public Result<T> Delete(T model)
        {
            return ExecuteDelegate.Exe<T>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    DaoProvider.CreateDao<T>().Delete(model, db);
                    db.SaveChanges();
                    return model;
                }
            });
        }


        public Result<T> QuerySinge(object ID)
        {
            return ExecuteDelegate.Exe<T>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    return DaoProvider.CreateDao<T>().QuerySingle(ID, db);

                }
            });
        }

        public Result<T> Update(T model)
        {
            return ExecuteDelegate.Exe<T>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    DaoProvider.CreateDao<T>().Update(model, db);
                    db.SaveChanges();
                    return model;
                }
            });
        }

        public Result<IEnumerable<T>> Query()
        {
            return ExecuteDelegate.Exe<IEnumerable<T>>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    return DaoProvider.CreateDao<T>().Query(db).ToList();
                }
            });


        }





        public Result<IEnumerable<T>> Query(Expression<Func<T, bool>> where)
        {
            return ExecuteDelegate.Exe<IEnumerable<T>>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    return DaoProvider.CreateDao<T>().Query(db, where).ToList();
                }
            });


        }

        public Result<IEnumerable<T>> Query<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool isDesc)
        {
            return ExecuteDelegate.Exe<IEnumerable<T>>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    var query = DaoProvider.CreateDao<T>().Query<TKey>(db, where, order, isDesc);

                    return query.ToList();
                }
            });
        }



      public  Result<IEnumerable<T>> Query(int pageIndex, int pageSize, Expression<Func<T, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount)
        {
            var count = 0;
            var result = ExecuteDelegate.Exe<IEnumerable<T>>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    var query = DaoProvider.CreateDao<T>().Query(db, where, orderParamList);
                    count = query.Count();
                    return query.Skip(Math.Max(0, pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            });
            totalCount = count;
            return result;

        }


        public Result<IEnumerable<T>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool isDesc, out int totalCount)
        {
            var count = 0;
            var result = ExecuteDelegate.Exe<IEnumerable<T>>(delegate () {
                using (MyDbContext db = new S_DbContext())
                {
                    var query = DaoProvider.CreateDao<T>().Query<TKey>(db, where, order, isDesc);
                    count = query.Count();
                    return query.Skip(Math.Max(0, pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            });
            totalCount = count;
            return result;

        }


    }
}
