using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }

        //"{\r\n  \"access_token\": \"eyJhbGciOiJSUzI1NiIsImtpZCI6IjNfc1l2Umt5WlkxaTZEWXhaY1BSQnciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1OTAyNDc3NDQsImV4cCI6MTU5MDI1MTM0NCwiaXNzIjoiaHR0cHM6Ly9pZC5rdXR1LnRlY2giLCJhdWQiOiJwcm9kdWN0LWFwaSIsImNsaWVudF9pZCI6ImF5Z2F6LTEiLCJjbGllbnRfTG9jYXRpb25Db2RlIjoiMTAxMTEiLCJjbGllbnRfUHJvamVjdENvZGUiOiJkZW1vIiwic2NvcGUiOlsicHJvZHVjdC1hcGkiXX0.ChJ8OkTo5fY5P5ddWnvu8fy7aFOvujIvEWgwQo44N_QJmi-83LRplJ7x8EHK6JDXAb92XuvJZJcME5Kqo6hMHdEla1vh1ZFDZlZ911RveO61pRcVv1VB-4ji64CeqF_Q_nnK_hfBFIpYMc2ArJOiTwdPd1GCEXitulrLw88JY4L0Vr5fDX8Oh-uiyvzLZiJq2WAbKj6Lw5RlNrBCRJ7Vgu2T1SEt94SUyAyH6-N0QO-Ah4ErXDps6SukPU235-4IW1F1u7mbowCh8R6Z9pcwUp1EVFWjMEeu56roynbd2VGXnMNbLsXyt0RBZ2xI-SHUgOOmfuVw83-Vi4qm7CWufg\",\r\n  \"expires_in\": 3600,\r\n  \"token_type\": \"Bearer\",\r\n  \"scope\": \"product-api\"\r\n}"
    }
}
