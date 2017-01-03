using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApiSample.Models.ViewModel
{
    public class SmsViewModel
    {
        [DisplayName("شناسه API")]
        public string ApiKey { get; set; }
    
        [DisplayName(" تاریخ ارسال ")]
        public string  SendData { get; set; }

        [DisplayName(" ساعت ارسال ")]
        public string SendHourse { get; set; }

        [DisplayName("نوع پیام")]
        public bool StatusMassagage { get; set; }
        [DisplayName(" شماره فرستنده")]
        public string NumberSender { get; set; }

        [DisplayName(" شماره گیرنده")]
        public string NumberReceptor { get; set; }
        
        [DisplayName("متن پیامک")]
        public string BodyMassage { get; set; }

        [DisplayName("شناسه یکتا پیامک")]
        public string CheckMessageIds { get; set; }

        [DisplayName("شناسه گروه")]
        public int GroupId { get; set; }

        [DisplayName("نوع عملیات")]
        public int ActionType { get; set; }

    }
}