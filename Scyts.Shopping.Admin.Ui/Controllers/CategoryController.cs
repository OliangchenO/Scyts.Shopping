using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Country
        public PartialViewResult Manage()
        {
            return PartialView();
        }

        [HttpPost]
        public string Query(string order,string sort)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.ICategory>();
            int totalCount = 0;
          
           List<Param> paramList = new List<Param>() { new Param() { IsDesc = order == "desc" ? true : false, Name= sort } };
            var data = bs.Query(0, int.MaxValue, o => 1 == 1, paramList, out totalCount);
           
            var returnObj = "";
            if (data.Status == 0)
            {
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(new { total = totalCount, rows = data.Obj.
                    Select(o=> new {id=o.Category_Id,Name=o.Name,Description = o.Description,
                        CreateDate=o.CreateDate,
                        UpdateDate=o.UpdateDate,
                        Keyword= o.Keyword,
                        Sort=o.Sort,
                        Status=o.Status,
                        _parentId =o.Parent_Id ,state= data.Obj.Where(c => c.Parent_Id == o.Category_Id).Count() > 0 ? "closed" : "" })
                });
            }
            return returnObj;
        }

        [HttpPost]
        public string QueryTree()
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.ICategory>();



            var data = bs.Query();

            var returnObj = "";

            var treeData = data.Obj.Select(o => new Bll.ViewModel.Tree() {id=o.Category_Id,text=o.Name, parent=o.Parent_Id}).ToList();
            if (data.Status == 0)
            {

                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(TreeSet(treeData,0));
            }
            return returnObj;
        }

        private  List<Bll.ViewModel.Tree> TreeSet(List<Bll.ViewModel.Tree> dataList,int? parentId) {
            List<Bll.ViewModel.Tree> nowTreeList = new List<Bll.ViewModel.Tree>();
             var children = dataList.Where(o => o.parent == parentId).ToList();
            if (children.Count>= 0) {
                
                foreach (var child in children) {
                    child.children.AddRange(TreeSet(dataList, child.id));
                }

                nowTreeList.AddRange(children);

            }
            return nowTreeList;
        }




        [HttpPost]
        public string Save(Model.Category model)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.ICategory>();
            var returnObj = "";
            //新增
            if (model.id <= 0)
            {
                
                model.CreateDate = DateTime.Now;
                model.Parent_Id = model._parentId;
                var result = bs.Add(model);
                result.Obj.id = result.Obj.Category_Id;
                result.Obj._parentId = result.Obj.Parent_Id;
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            }
            //编辑
            else {
                model.UpdateDate = DateTime.Now;
                model.Category_Id = model.id.Value;
                model.Parent_Id = model._parentId;
                var result = bs.Update(model);
                result.Obj.id = result.Obj.Category_Id;
                result.Obj._parentId = result.Obj.Parent_Id;
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            }
         
            return returnObj;

        }


        [HttpPost]
        public string Delete(List<int> ids)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.ICategory>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }
    }


}