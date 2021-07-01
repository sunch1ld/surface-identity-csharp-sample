
using ClientSI.Error;
using ClientSI.Requests;
using ClientSI.Responses;
using ClientSI_Config;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientSI.Library
{
    public class IdentificationClient : IIdentification
    {
        /// <summary>
        /// Http client used for requests
        /// </summary>
        private readonly HttpClient indentificationHttpClient = new HttpClient();

        /// <summary>
        /// Name of the server that allow recognition
        /// </summary>
        private const string SURFACE_IDENTITY_API_SCOPE = "surface_identity_api";

        /// <summary>
        /// Server for autentication https://surfaceidentity.it:4000
        /// </summary>
        public readonly IdentificationSettings identificationsettings;

        /// <summary>
        /// This class allows client recognition with client credentials
        /// refers to https://www.oauth.com/oauth2-servers/access-tokens/client-credentials/
        /// method described here

        public IdentificationClient(IdentificationSettings identificationsettings)
        {
            this.identificationsettings = identificationsettings;
        }

        /// <summary>
        /// Initialize client provide credentials and get the token
        /// Call indentification for a single project
        /// </summary>
        /// <param name="IdentificationRequest">object </param>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<string, IdentificationResponse>> IdentifyAsync(IdentificationRequest request)
        {
            indentificationHttpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            var tokenResponse = await indentificationHttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = identificationsettings.TokenRequestURL,
                ClientId = identificationsettings.AppId,
                ClientSecret = identificationsettings.Secret,
                Scope = SURFACE_IDENTITY_API_SCOPE
            });
            if (string.IsNullOrEmpty(tokenResponse.AccessToken) || (tokenResponse.ExpiresIn == 0) || (tokenResponse.HttpStatusCode != HttpStatusCode.OK))
            {
                throw new Exception(tokenResponse.Error);
            }
            else
            {
                indentificationHttpClient.SetBearerToken(tokenResponse.AccessToken);
            }

            /// Serialize object into json
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var responseTest = await indentificationHttpClient.PostAsync(identificationsettings.IdentificationEndpointURL, content);

            ConcurrentDictionary<string, IdentificationResponse> identificationResponse;
            ///Verifty call is successfull
            if (!responseTest.IsSuccessStatusCode)
            {
                string identificationResponseString = await responseTest.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ErrorResponse>(identificationResponseString);
                throw new Exception($"ERROR: {response.Error.Message}");

            }
            else
            {
                string identificationResponseString = await responseTest.Content.ReadAsStringAsync();
                identificationResponse = JsonConvert.DeserializeObject<ConcurrentDictionary<string, IdentificationResponse>>(identificationResponseString);
            }
            return identificationResponse;
        }

    }
}
