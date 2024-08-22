using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using IdentityModel.Client;

using evieplus.CommonLibrary;
using evieplus.Models;

namespace evieplus.WebApi
{
    public class GarajApi
    {
        private static GarajApi m_xGlobalsInstance = null;
        private static TokenModel m_xTokenModel = null;

        public GarajApi()
        {

        }

        public static GarajApi xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new GarajApi();

            return m_xGlobalsInstance;
        }

        private static async Task taskGetToken()
        {
            try
            {
                // discover endpoints from metadata
                var client = new HttpClient();

                var disco = await client.GetDiscoveryDocumentAsync(CommonProperty.prop_strGarajIdpUri); // IDP
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return;
                }

                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = CommonProperty.prop_strClientId,
                    ClientSecret = CommonProperty.prop_strClientSecret,
                    Scope = CommonProperty.prop_strScope
                });

                if (tokenResponse.IsError)
                {
                    Trace.vInsert(enumTraceLevel.Important, "Error get token. " + tokenResponse.ErrorDescription);
                    return;
                }

                string JsonData = tokenResponse.Json.ToString();
                m_xTokenModel = JsonConvert.DeserializeObject<TokenModel>(JsonData);

            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private static async Task<bool> taskConfirm(int prm_iOrderId, string prm_strTcIdentityNumber)
        {
            int iCounter = 5;
            while (iCounter > 0)
            {
                if (m_xTokenModel == null)
                    await taskGetToken();

                var apiClient = new HttpClient();
                apiClient.SetBearerToken(m_xTokenModel.access_token);
                apiClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await apiClient.PutAsync($"{CommonProperty.prop_strGarajApiUri}/api/otomat/pick-up/{prm_iOrderId}/confirm",
                    new StringContent(
                    JsonConvert.SerializeObject(new
                        OtomatFlowConfirmModel
                    {
                        TcIdentityNumber = prm_strTcIdentityNumber
                    }), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    m_xTokenModel = null;
                    iCounter--;
                    continue;
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }

            Trace.vInsert(enumTraceLevel.Important, "Token not found after 5 attempts");
            return false;
        }

        private static async Task<PickUpResultModel> taskPickUp(string prm_strCatalogItemCode)
        {
            int iCounter = 5;
            while (iCounter > 0)
            {
                if (m_xTokenModel == null)
                    await taskGetToken();

                var apiClient = new HttpClient();
                apiClient.SetBearerToken(m_xTokenModel.access_token);
                apiClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await apiClient.PostAsync($"{CommonProperty.prop_strGarajApiUri}/api/otomat/{prm_strCatalogItemCode}/pick-up", null);

                if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    m_xTokenModel = null;
                    iCounter--;
                    continue;
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var pickUpResult = JsonConvert.DeserializeObject<PickUpResultModel>(content);

                return pickUpResult;
            }

            Trace.vInsert(enumTraceLevel.Important, "Token not found after 5 attempts");
            return null;
        }

        private static async Task<IEnumerable<CatalogItemForFlowModel>> taskGetCatalogs()
        {
            if (m_xTokenModel == null)
                await taskGetToken();

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(m_xTokenModel.access_token);
            apiClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<CatalogItemForFlowModel> xCatalogItems = null;

            int iCounter = 0;

            do
            {
                var response = await apiClient.GetAsync($"{CommonProperty.prop_strGarajApiUri}/api/catalog");

                if (!response.IsSuccessStatusCode)
                {
                    await taskGetToken();

                    if (iCounter++ > 3)
                    {
                        Trace.vInsert(enumTraceLevel.Important, "Token not found");
                        return null;
                    }

                    continue;
                }

                var content = await response.Content.ReadAsStringAsync();
                xCatalogItems = JsonConvert.DeserializeObject<IEnumerable<CatalogItemForFlowModel>>(content);

                break;
            }
            while (true);

            return xCatalogItems;
        }

        private static async Task<bool> taskCancel(int orderId)
        {
            int iCounter = 5;
            while (iCounter > 0)
            {
                if (m_xTokenModel == null)
                    await taskGetToken();

                var apiClient = new HttpClient();
                apiClient.SetBearerToken(m_xTokenModel.access_token);
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await apiClient.PutAsync($"{CommonProperty.prop_strGarajApiUri}/api/otomat/pick-up/{orderId}/cancel", null);

                if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    m_xTokenModel = null;
                    iCounter--;
                    continue;
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }

            Trace.vInsert(enumTraceLevel.Important, "Token not found after 5 attempts");
            return false;
        }

        public IEnumerable<CatalogItemForFlowModel> xGetCatalogs()
        {
            Task<IEnumerable<CatalogItemForFlowModel>> xTask = Task.Run<IEnumerable<CatalogItemForFlowModel>>(async () => await taskGetCatalogs());

            IEnumerable<CatalogItemForFlowModel> xCatalogItems = xTask.Result;

            return xCatalogItems;
        }

        public PickUpResultModel xPickUp(string prm_strCatalogItemCode)
        {
            Task<PickUpResultModel> xTask = Task.Run<PickUpResultModel>(async () => await taskPickUp(prm_strCatalogItemCode));

            PickUpResultModel xPickUpResul = xTask.Result;

            return xPickUpResul;
        }

        public bool bConfirm(int prm_iOrderId, string prm_strTcIdentityNumber)
        {
            Task<bool> xTask = Task.Run(async () => await taskConfirm(prm_iOrderId, prm_strTcIdentityNumber));

            bool bConfirmValue = xTask.Result;

            return bConfirmValue;
        }

        public bool bCancel(int prm_iOrderId)
        {
            Task<bool> xTask = Task.Run(async () => await taskCancel(prm_iOrderId));

            bool bConfirmValue = xTask.Result;

            return bConfirmValue;
        }
    }
}
