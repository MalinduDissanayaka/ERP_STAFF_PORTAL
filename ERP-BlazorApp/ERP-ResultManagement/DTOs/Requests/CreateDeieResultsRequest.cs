using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ERP_ResultManagement.DTOs.Requests
{
    public class CreateDeieResultsRequest
    {
        public int DEIEid { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string? EE0001 { get; set; }
        public string? EE0002 { get; set; }
        public string? EE0003 { get; set; }
        public string? EE0004 { get; set; }
        public string? EE0005 { get; set; }
        public string? EE0006 { get; set; }
        public string? EE0007 { get; set; }
        public string? EE0008 { get; set; }
        public string? EE0009 { get; set; }
        public string? EE0010 { get; set; }
        public string? EE0011 { get; set; }
        public string? EE0012 { get; set; }
    }
}