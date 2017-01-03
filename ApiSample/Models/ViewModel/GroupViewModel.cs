using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApiSample.Models.ViewModel
{
    public class GroupbViewModel
    {
        [DisplayName("شناسه API")]
        public string ApiKey { get; set; }

        [DisplayName(" شناسه گروه پدر")]
        public int ParentId { get; set; }

        [DisplayName("نام گروه")]
        public string GroupName { get; set; }

        [DisplayName("شناسه گروه")]
        public int GroupId { get; set; }

        [DisplayName("شماره تلفن مخاطب")]
        public int PhoneNumber { get; set; }

        [DisplayName("نام مخاطب")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی مخاطب")]
        public string LastName { get; set; }

        [DisplayName("ایمیل مخاطب")]
        public string Email { get; set; }

        [DisplayName(" جنسیت مخاطب")]
        public string Gender { get; set; }

        [DisplayName("تاریخ تولد مخاطب")]
        public string Birthday { get; set; }
    }
}