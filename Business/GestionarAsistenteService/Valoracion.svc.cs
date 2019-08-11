using EVP.Libreria;
using GestionarAsistenteService.Dominio;
using GestionarAsistenteService.Errores;
using MessageBird;
using MessageBird.Objects;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;

namespace GestionarAsistenteService
{
    public class Valoracion : IValoracion
    {
        public ValoracionDOM Crear(ValoracionDOM Parametro)
        {
            try
            {
                return (new RestClient<ValoracionDOM>().POST(Parametro, "http://sharedcss.com/evp/application/ValoracionService/Valoracion.svc/Valoracion").GetAwaiter().GetResult());

            }
            catch (WebException ex)
            {

                var RestClientException = ex.Serializer();

                //CONTINGENCIA
                var errorIronMQMessageBird = "";
                try
                {
                    //IronMQ
                    errorIronMQMessageBird += "[IronMQ: ";
                    var iromMq = IronSharp.IronMQ.Client.New(new IronSharp.Core.IronClientConfig
                    {
                        ProjectId = "5d1ec07e967e0f0009110652",
                        Token = "IbPVHZWeivK980I3TlB5",
                        Host = "mq-aws-eu-west-1-1.iron.io",
                        Scheme = Uri.UriSchemeHttp,
                        Port = 80,
                    });
                    IronSharp.IronMQ.QueueClient queue = iromMq.Queue("ValoracionCrear");
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    queue.Post(js.Serialize(Parametro));
                    errorIronMQMessageBird += "Guardado]";



                    //MessageBird: Para la prueba de SMS debemos enviar como comentario SMS
                    if (Parametro.Comentario == "SMS")
                    {
                        errorIronMQMessageBird += "[MessageBird: ";
                        var celular = "936059777";
                        string YourAccessKey = "sa2mNTcSqTNEpcZDJC5TNwqa0";
                        Client sclient = Client.CreateDefault(YourAccessKey);
                        long Msisdn = long.Parse("+51" + celular);
                        Message message = sclient.SendMessage("SDS", "Hola, existe problema en el servicio GestionarAsistenteService/Valoración", new[] { Msisdn });

                        errorIronMQMessageBird += "Enviado]";
                    }
                }
                catch (System.Exception esx)
                {
                    errorIronMQMessageBird += esx.Message + "]";
                }

                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "400",
                            Descripcion = RestClientException.Descripcion + "\n IronMQMessageBird: " + errorIronMQMessageBird
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
        }

        public string Eliminar(string IdValoracion)
        {
            try
            {
                return (new RestClient<string>().DELETE( "http://sharedcss.com/evp/application/ValoracionService/Valoracion.svc/Valoracion/" + IdValoracion).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<ValoracionDOM> Listar()
        {
            try
            {
                return (new RestClient<List<ValoracionDOM>>().GET("http://sharedcss.com/evp/application/ValoracionService/Valoracion.svc/Valoracion" ).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ValoracionDOM Modificar(ValoracionDOM Parametro)
        {
            try
            {
                return (new RestClient<ValoracionDOM>().PUT(Parametro, "http://sharedcss.com/evp/application/ValoracionService/Valoracion.svc/Valoracion").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
