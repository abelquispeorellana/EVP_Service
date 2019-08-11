
namespace ValoracionService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ValoracionDOM
    {
        [DataMember]
        public int IdValoracion { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdEstacimionamiento { get; set; }
        [DataMember]
        public string Comentario { get; set; }

        [DataMember]
        public int Puntuacion { get; set; } 

    }
}