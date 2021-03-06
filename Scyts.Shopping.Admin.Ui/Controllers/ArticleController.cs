﻿using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public PartialViewResult Manage()
        {
            return PartialView();
        }

        [HttpPost]
        public string Query(int page, int rows, string sort, string order)
        {
            var bs = Bll.BsProvider.CreateBusiness<Bll.IArticle>();
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



        [ValidateInput(false)]
        [HttpPost]
        public string Save(Model.Article model)
        {

            var bs = Bll.BsProvider.CreateBusiness<Bll.IArticle>();
            var returnObj = "";
            //新增
            if (model.Article_Id == 0)
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

            var bs = Bll.BsProvider.CreateBusiness<Bll.IArticle>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }

    }
}