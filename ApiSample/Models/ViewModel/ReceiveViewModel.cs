using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApiSample.Models.ViewModel
{
    public class ReceiveViewModel
    {
        [DisplayName("شناسه API")]
        public string ApiKey { get; set; }

        [DisplayName("شماره خط")]
        public string LineNumber { get; set; }

        [DisplayName("نوع پیام")]
        public int IsRead { get; set; }
    }
}