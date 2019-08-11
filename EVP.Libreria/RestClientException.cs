
namespace EVP.Libreria
{
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Web.Script.Serialization;

    public class RestClientException
    { 
        public string Codigo { get; set; } 

        public string Descripcion { get; set; } 
    }
    public static class RestClientExceptionReader
    {
        public static RestClientException Serializer(this WebException e)
        {
            try
            {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpStatusCode codigo = ((HttpWebResponse)e.Response).StatusCode;
            StreamReader reader = new StreamReader(e.Response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            return  js.Deserialize<RestClientException>(tramaJson) ?? new RestClientException() { Descripcion = "Not Found" }; 
            }
            catch (System.Exception)
            {
                return new RestClientException() { Descripcion = "Error de solicitud" };
            }
        }
    }

}