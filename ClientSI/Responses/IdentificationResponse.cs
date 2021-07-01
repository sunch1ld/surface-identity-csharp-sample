using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSI.Responses
{
    public class IdentificationResponse
    {
        public bool Found { get; set; }
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string SurfaceId { get; set; }
        public string SurfaceName { get; set; }
     
    }
}
