using ApiSample.Models;
using ApiSample.Models.Enums;
using ApiSample.Models.ViewModel;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ApiSample.Controllers
{
    public class VoiceController : Controller
    {
        // GET: Voice
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(VoiceViewModel model, HttpPostedFileBase Upload)
        {
            try
            {
                string filePath = "";
                if (Upload != null)
                {
                    if (Request.Files["upload"].ContentLength > 4999999)
                    {
                        TempData["Massage"] = Utility.MessageBox(MassageType.Error);
                        return RedirectToAction("UploadFile", "Voice");
                    }
                    string fileName = Path.GetFileName(Upload.FileName);
                    Upload.SaveAs(Path.Combine(Utility.TempFilePath(), fileName.Substring(0,5) + Path.GetExtension(Upload.FileName)));
                    filePath = Path.Combine(Utility.TempFilePath(), fileName.Substring(0, 5) + Path.GetExtension(Upload.FileName));
                }
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v1/voice/upload", Method.POST);
                request.AddHeader("description", model.Description);
                request.AddHeader("apikey", model.ApiKey);
                request.AddFile("file", @"" + filePath + "");
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    if (res.result == "success")
                        TempData["Massage"] = Utility.MessageBox(MassageType.Success, "fileid", (string)res.fileid);
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
            return View("UploadFile");
        }

        public ActionResult SendFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendFile(VoiceViewModel model)
        {
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest("v1/voice/send/file", Method.POST);
                request.AddParameter("fileid", model.FileId);
                request.AddHeader("apikey", model.ApiKey);
                request.AddParameter("receptor", model.NumberReceptor.Replace("\r\n", ","));
                request.AddParameter("senddate", Convert.ToString(Utility.ConvertDatetimeToUnixTimeStamp(Utility.ConvertToDatetime(model.SendDate))));
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    TempData["Massage"] = Utility.MessageBox(MassageType.Success, "result", (string)res.result);
                }
                else
                    TempData["Massage"] = Utility.MessageBox(MassageType.Error);
            }
            catch (Exception ex)
            {
                TempData["Massage"] = Utility.MessageBox(MassageType.exception, ex.Message);
            }
            return View("SendFile");
        }
    }
}