
namespace EstacionamientoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class EstacionamientoMapaDOM
    {
        [DataMember]
        public int IdEstacionamiento { get; set; }
        [DataMember]
        public string v { get; set; }
        [DataMember]
        public string v1 { get; set; }
         
    }
}