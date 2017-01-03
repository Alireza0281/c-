using ApiSample.Models;
using ApiSample.Models.Enums;
using ApiSample.Models.ViewModel;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.Controllers
{
    public class SendController : Controller
    {
        // GET: Send
        public ActionResult SmsSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SmsSend(SmsViewModel model)
        {
            string Receptor = "", sender = "", BodyMassage = "", url = "";
            switch (model.ActionType)
            {
                //ارسال تکی پیام
                case 1:
                    url = "v2/sms/send/simple";
                    Receptor = model.NumberReceptor;
                    sender = model.NumberSender;
                    BodyMassage = model.BodyMassage;
                    break;

                //ارسال گروهی 1 
                case 2:
                    url = "v2/sms/send/bulk";
                    Receptor = model.NumberReceptor.Replace("\r\n", ",");
                    sender = model.NumberSender.Replace("\r\n", ",");
                    BodyMassage = model.BodyMassage.Replace("\r\n", ",");
                    break;

                //ارسال گروهی 2 
                case 3:
                    url = "v2/sms/send/bulk2";
                    Receptor = model.NumberReceptor.Replace("\r\n", ",");
                    sender = model.NumberSender;
                    BodyMassage = model.BodyMassage;
                    break;

                default:
                    Receptor = model.NumberReceptor;
                    sender = model.NumberSender;
                    BodyMassage = model.BodyMassage;
                    break;
            }
            try
            {
                var client = new RestClient(Utility.GeneralUrl());
                var request = new RestRequest(url, Method.POST);
                if ((model.ActionType==2 || model.ActionType==3 )&& model.GroupId !=0)
                {
                    request.AddParameter("groupids", model.GroupId);
                }
                request.AddParameter("message", BodyMassage);
                request.AddParameter("senddate", Convert.ToString(Utility.ConvertDatetimeToUnixTimeStamp(Utility.ConvertToDatetime(model.SendData))));
                request.AddParameter("sender", sender);
                request.AddParameter("receptor", Receptor);
                request.AddParameter("checkmessageids", model.CheckMessageIds);
                request.AddHeader("apikey", model.ApiKey);
                var response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    var res = deserial.Deserialize<ResponseModel>(response);
                    TempData["Massage"] = Utility.MessageBox(MassageType.Success, "messageids", (string)res.messageids);
                }
                else
                    TempData["Massage"] = Utility.MessageBox(MassageType.Error);
            }
            catch (Exception ex)
            {
                TempData["Massage"] = Utility.MessageBox(MassageType.exception, ex.Message);
            }
            return View("SmsSend");
        }
    }
}
