using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.RequestModel
{
    public class RegisterPublisher
    {
        public string AgencyName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public int OfferId { get; set; }
        public int AdminId { get; set; }
    }
}
