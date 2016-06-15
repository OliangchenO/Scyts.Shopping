using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public PartialViewResult Manage()
        {
            return PartialView();
        }


        [HttpPost]
        public string Query(int page, int rows, string sort, string order)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IBrand>();
            int totalCount = 0;
            List<Param> paramList = new List<Param>() { new Param() { IsDesc = order == "desc" ? true : false, Name = sort } };
            var data = bs.Query(page, rows, o => 1 == 1, paramList, out totalCount);
            var returnObj = "";
            if (data.Status == 0)
            {
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(new { total = totalCount, rows = data.Obj });
            }
            return returnObj;
        }


        [HttpPost]
        public string QueryAll()
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IBrand>();
           
            var data = bs.Query();
          
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
         
        }


        [HttpPost]
        public string Save(Model.Brand model)
        {
          

            var bs = Bll.BsProvider.CreateBusiness<Bll.IBrand>();
            var returnObj = "";
            //新增
            if (model.Brand_Id == 0)
            {
                model.CreateDate = DateTime.Now;

                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Add(model));
            }
            //编辑
            else {
                model.UpdateDate = DateTime.Now;

                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Update(model));
            }

            return returnObj;

        }


        [HttpPost]
        public string Delete(List<int> ids)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IBrand>();
            var returnObj = "";
         
            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }

        [HttpPost]
        public string GetCategory(int id)
        {
            var bs = Bll.BsProvider.CreateCommon<Model.Category_Brand>();
            var returnObj = "";
            returnObj=Newtonsoft.Json.JsonConvert.SerializeObject(bs.Query(o=>o.Brand_Id== id));
            return returnObj;
        }


        [HttpPost]
        public string SaveCategory(int id,List<int> ids)
        {
            var returnObj = "";

            try
            {
                var bs = Bll.BsProvider.CreateCommon<Model.Category_Brand>();
                List<Model.Category_Brand> addList = new List<Model.Category_Brand>();
                List<Model.Category_Brand> deleteList = new List<Model.Category_Brand>();
                //获取所有
                var nowCategoryList = bs.Query(o => o.Brand_Id == id).Obj;

                //确定要添加的
                foreach (var idItem in ids)
                {
                    if (!nowCategoryList.Any(o => o.Category_Id == idItem))
                    {
                        addList.Add(new Model.Category_Brand() { Brand_Id = id, Category_Id = idItem });
                    }
                }
                //确定要删除的
                foreach (var categoryItem in nowCategoryList)
                {
                    if (!ids.Any(o => o == categoryItem.Category_Id))
                    {
                        deleteList.Add(categoryItem);
                    }
                }

                foreach (var addItem in addList)
                {

                  var result=  bs.Add(addItem);
                    if (result.Status != 0) {
                        throw new Exception();
                    }
                }

                foreach (var delItem in deleteList)
                {
                    var result = bs.Delete(delItem);
                    if (result.Status != 0)
                    {
                        throw new Exception();
                    }
                    }

                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(EntityFrameWork.Extend.ResultFactory.Success<int>(1));
            }
            catch (Exception ex)
            {

                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(EntityFrameWork.Extend.ResultFactory.Error<int>());
            }
          

          

       
            return returnObj;
        }
    }
}