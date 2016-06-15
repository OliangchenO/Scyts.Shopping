using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class Good_AttributeController : Controller
    {
        // GET: Good_Attribute
        public PartialViewResult Manage(int id)
        {
           ViewData["data"]="var good_id="+id+";";
            return PartialView();
        }




        [HttpPost]
        public string Query(int page, int rows, string sort, string order,int id)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Attribute>();
            int totalCount = 0;
            List<Param> paramList = new List<Param>() { new Param() { IsDesc = order == "desc" ? true : false, Name = sort } };
            var data = bs.Query(page, rows, o => o.Good_Id==id, paramList, out totalCount);
            var returnObj = "";
            if (data.Status == 0)
            {
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(new { total = totalCount, rows = data.Obj });
            }
            return returnObj;
        }

        [HttpPost]
        public string Save(Model.Good_Attribute model)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Attribute>();
            var returnObj = "";
            //新增
            if (model.Id == 0)
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

            var bs = Bll.BsProvider.CreateBusiness<Bll.IGood_Attribute>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }

        [HttpPost]
        public string AddCategoryAttribute(int good_id) {
            var returnObj = "";
            //新增
            var gbs = Bll.BsProvider.CreateBusiness<Bll.IGood_Attribute>();
            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(gbs.AddCategoryAttribute(good_id));
            return returnObj;
        }


    }
}