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
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult StatusSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StatusSend(ReportViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/sms/status", Method.POST);
                request.AddParameter("messageids", model.MessageIds.Replace("\r\n", ","));
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "list" , (string) res.list);
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
            return View("StatusSend");
        }

        public ActionResult Checkmessageids()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkmessageids(ReportViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/sms/check", Method.POST);
                request.AddParameter("checkingids", model.CheckingIds.Replace("\r\n", ","));
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "list",(string) res.list);
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
            return View("StatusSend");
        }


        public ActionResult GetReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetReport(ReportViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/sms/requestinfo", Method.POST);
                request.AddParameter("messageids", model.MessageIds);
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "request", (string)res.request);
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
            return View("GetReport");
        }
    }
}