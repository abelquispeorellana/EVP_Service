using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace EVP.Libreria
{
    public class RestClient<T>
    {
        public async System.Threading.Tasks.Task<T> POST(object parameter, string UriString)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(parameter);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UriString);
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = await reader.ReadToEndAsync();
            return js.Deserialize<T>(tramaJson);
        }
        public async System.Threading.Tasks.Task<T> PUT(object parameter, string UriString)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(parameter);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UriString);
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = await reader.ReadToEndAsync();
            return js.Deserialize<T>(tramaJson);
        }
        public async System.Threading.Tasks.Task<T> GET(string UriString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UriString);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = await reader.ReadToEndAsync();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<T>(tramaJson);
        }
        public async System.Threading.Tasks.Task<T> DELETE(string UriString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UriString);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = await reader.ReadToEndAsync();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<T>(tramaJson);
        }
    }
}
