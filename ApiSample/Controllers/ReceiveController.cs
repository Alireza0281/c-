using ApiSample.Models;
using ApiSample.Models.Enums;
using ApiSample.Models.ViewModel;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.Controllers
{
    public class ReceiveController : Controller
    {
        // GET: Receive
        public ActionResult ReceiveSms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReceiveSms(ReceiveViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/sms/recive", Method.POST);
                request.AddParameter("linenumber", model.LineNumber);
                request.AddParameter("isread", model.IsRead);
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "list", (string)res.list);
                    else
                        TempData["Massage"] = Utility.MessageBox(MassageType.Error);
                }
                else
                    TempData["Massage"] = Utility.MessageBox(MassageType.Error);
            }
            catch (Exception ex)
            {
                TempData["Massage"] = Utility.MessageBox(MassageType.exception, ex.Message);
            }
            return View("ReceiveSms");
        }

    }
}