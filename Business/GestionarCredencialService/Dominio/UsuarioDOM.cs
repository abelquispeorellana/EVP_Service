
namespace GestionarCredencialService.Dominio
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class UsuarioDOM
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string Tipo { get; set; }
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