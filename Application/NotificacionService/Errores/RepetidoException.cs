
namespace NotificacionService.Errores
{
    using System.Runtime.Serialization;

    [DataContract]
    public class RepetidoException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]

        public string Descripcion { get; set; } 
    }
}