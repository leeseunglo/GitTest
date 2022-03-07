using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Core.Protocol.Http
{
    public interface IHttpClient
    {
        Task<RES> PostAsJsonAsync<REQ, RES>(string strURL, REQ req);
    }

    public class HttpClient : IHttpClient
    {
        private readonly string contentType = string.Empty;
        private readonly Encoding encodingType = Encoding.UTF8;

        private Dictionary<string, string> m_dicHeader = new Dictionary<string, string>();
        public string this[string header]
        {
            get { return m_dicHeader.ContainsKey(header) ? m_dicHeader[header] : string.Empty; }
            set { m_dicHeader[header] = value; }
        }

        public HttpClient(string strContentType = "application/json", Encoding encodingType = null)
        {
            if (null != encodingType)
				this.encodingType = encodingType;

			this.contentType = strContentType;
        }

        public async Task<RES> PostAsJsonAsync<REQ, RES>(string strURL, REQ req)
        {
            StringContent content = createContent(req);
            return await postAsJsonAsync<RES>(strURL, content);
        }

        private StringContent createContent<REQ>(REQ req)
        {
            var json = JsonConvert.SerializeObject(req);
            var content = new StringContent(json, encodingType, contentType);
            foreach(var header in m_dicHeader)
                content.Headers.Add(header.Key, header.Value);

            return content;
        }

        private async Task<RES> postAsJsonAsync<RES>(string strURL, StringContent content, string strToken = null)
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", strToken);

                var responseMsg = await httpClient.PostAsync(strURL, content).ConfigureAwait(false);
                if (System.Net.HttpStatusCode.OK != responseMsg.StatusCode)
                    System.Diagnostics.Trace.TraceWarning($"RequestURL:{strURL}, StatusCode:{responseMsg.StatusCode}");

                return responseMsg.Content.ReadAsAsync<RES>().Result;
            }
        }
    }
}
