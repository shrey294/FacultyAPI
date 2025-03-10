using System;
using System.Collections.Generic;

namespace FacultyAPI.Models
{
    public partial class Faculty
    {
        public int FcId { get; set; }
        public string? FcName { get; set; }
        public string? FcDesignation { get; set; }
        public string? FcHighestEducation { get; set; }
        public int? FcExYear { get; set; }
        public string? WorkingSince { get; set; }
        public string? FcMobile { get; set; }
        public string? FcEmail { get; set; }
        public string? FcSeating { get; set; }
        public string? FcProfile { get; set; }
        public string? FcAreaspecialization { get; set; }
        public string? FcSubjecttaught { get; set; }
        public string? FcImage { get; set; }
        public int? FcDepartmentId { get; set; }
        public string? FcSequence { get; set; }
    }
}
