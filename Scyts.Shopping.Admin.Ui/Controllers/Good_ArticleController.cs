using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class Good_ArticleController : Controller
    {
        // GET: Good_Article
        public PartialViewResult Manage(int id)
        {
            ViewData["data"] = "var good_id=" + id + ";";
            return PartialView();
        }



        [HttpPost]
        public string Query(int page, int rows, string sort, string order, int id)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Article>();
            int totalCount = 0;
            List<Param> paramList = new List<Param>() { new Param() { IsDesc = order == "desc" ? true : false, Name = sort } };
            var data = bs.QueryByGoodId(page, rows, id, paramList, out totalCount);
            var returnObj = "";
            if (data.Status == 0)
            {
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(new { total = totalCount, rows = data.Obj });
            }
            return returnObj;
        }



        [HttpPost]
        public string Delete(List<int> ids, List<int> a_ids)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Article>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids, a_ids));

            return returnObj;

        }



        [ValidateInput(false)]
        [HttpPost]
        public string Save(Bll.ViewModel.ViewModel_Good_Article model,Model.Article a_model)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Article>();
            var returnObj = "";
            //新增
            if (model.Id == 0)
            {
                a_model.CreateDate = DateTime.Now;
                model.CreateDate = DateTime.Now;
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Add(model,a_model));
            }
            //编辑
            else {
                a_model.UpdateDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                var abs=  Bll.BsProvider.CreateBusiness<Bll.IArticle>();
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(abs.Update(a_model));
            }

            return returnObj;

        }
    }
}