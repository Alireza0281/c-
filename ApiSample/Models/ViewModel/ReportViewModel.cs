using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApiSample.Models.ViewModel
{
    public class ReportViewModel
    {
        [DisplayName("شناسه API")]
        public string ApiKey { get; set; }

        [DisplayName("شناسه یکتا پیامک")]
        public string MessageIds { get; set; }

        [DisplayName("شناسه پیامک کاربر")]
        public string CheckingIds { get; set; }
    }
}