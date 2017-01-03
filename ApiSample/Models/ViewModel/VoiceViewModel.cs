using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApiSample.Models.ViewModel
{
    public class VoiceViewModel
    {
        [DisplayName("شناسه API")]
        public string ApiKey { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("فایل")]
        public string File { get; set; }

        [DisplayName("شناسه فایل")]
        public int FileId { get; set; }

        [DisplayName("تاریخ ارسال فایل")]
        public string SendDate { get; set; }

        [DisplayName("ساعت ارسال فایل")]
        public string SendHourse { get; set; }

        [DisplayName(" شماره گیرنده")]
        public string NumberReceptor { get; set; }


    }
}