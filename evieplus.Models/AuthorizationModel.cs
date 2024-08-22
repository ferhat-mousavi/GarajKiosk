using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.Models
{
    public class AuthorizationModel
    {
        public AuthorizationModel()
        {
            bProcessStatus = false;
            bAuthorizationResultStatus = false;
        }

        public bool bProcessStatus { get; set; }
        public bool bAuthorizationResultStatus { get; set; }
    }
}
