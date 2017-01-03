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
    public class ManageGroupController : Controller
    {
        // GET: ManageGroup
        public ActionResult AddGroup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGroup(GroupbViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/contact/group/add", Method.POST);
                request.AddParameter("parentid", model.ParentId);
                request.AddParameter("groupname", model.GroupName);
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "groupid", (string)res.groupid);
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
            return View("AddGroup");
        }

        public ActionResult AddNumber()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNumber(GroupbViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/contact/group/number/add", Method.POST);
                request.AddParameter("groupid", model.GroupId);
                request.AddParameter("firstname", model.FirstName);
                request.AddParameter("lastname", model.LastName);
                request.AddParameter("number", model.PhoneNumber);
                request.AddParameter("email", model.Email);
                request.AddParameter("gender", model.Gender);
                request.AddParameter("birthday", Convert.ToString(Utility.ConvertDatetimeToUnixTimeStamp(Utility.ConvertToDatetime(model.Birthday))));
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success);
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
            return View("AddNumber");
        }

        public ActionResult GroupList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GroupList(GroupbViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v2/contact/group/list", Method.POST);
                request.AddParameter("parentid", model.ParentId);
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "list", (string)string.Join(",", res.list));
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
            return View("GroupList");
        }

    }
}