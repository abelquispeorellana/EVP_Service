
namespace AdministradorService.Dominio
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class AdministradorDOM
    {
        [DataMember]
        public int   IdAdministrador { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellidos { get; set; }

        [DataMember]
        public string NumDocumento { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Contrasenia { get; set; } 

    }
}