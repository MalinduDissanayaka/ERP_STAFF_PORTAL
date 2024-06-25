using System;
using ERP.ResultManagement.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ERP.ResultManagement.Core.DTOs.Request
{
    public class CreateComResultsRequest
    {
        public int ComId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string? CE0001 { get; set; }
        public string? CE0002 { get; set; }
        public string? CE0003 { get; set; }
        public string? CE0004 { get; set; }
        public string? CE0005 { get; set; }
        public string? CE0006 { get; set; }
        public string? CE0007 { get; set; }
        public string? CE0008 { get; set; }
        public string? CE0009 { get; set; }
        public string? CE0010 { get; set; }
        public string? CE0011 { get; set; }
        public string? CE0012 { get; set; }
    }
}