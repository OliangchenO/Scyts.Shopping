using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameWork.Extend;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class GoodController : Controller
    {
        // GET: Good
        // GET: Good
        public PartialViewResult Manage()
        {
            //输出
            var country = Bll.BsProvider.CreateBusiness<Bll.ICountry>().Query().Obj;
            var category= Bll.BsProvider.CreateBusiness<Bll.ICategory>().Query().Obj;
            var treeData = TreeSet(category.Select(o => new Bll.ViewModel.Tree() { id = o.Category_Id, text = o.Name, parent = o.Parent_Id }).ToList(),0);
          
          
          var brand= Bll.BsProvider.CreateBusiness<Bll.IBrand>().Query().Obj;
         ViewData["data"]=  ("var json_country="+ Newtonsoft.Json.JsonConvert.SerializeObject(country )+
                                    ";var json_category=" + Newtonsoft.Json.JsonConvert.SerializeObject(treeData) +
                                     ";var json_brand=" + Newtonsoft.Json.JsonConvert.SerializeObject(brand) + ";");


            return PartialView();
        }
        private List<Bll.ViewModel.Tree> TreeSet(List<Bll.ViewModel.Tree> dataList, int? parentId)
        {
            List<Bll.ViewModel.Tree> nowTreeList = new List<Bll.ViewModel.Tree>();
            var children = dataList.Where(o => o.parent == parentId).ToList();
            if (children.Count >= 0)
            {

                foreach (var child in children)
                {
                    child.children.AddRange(TreeSet(dataList, child.id));
                }

                nowTreeList.AddRange(children);

            }
            return nowTreeList;
        }



        [HttpPost]
        public string Query(int page, int rows, string sort, string order)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood>();
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
        public string Save(Model.Good model)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood>();
            var returnObj = "";
            //新增
            if (model.Good_Id == 0)
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

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }



    }
}