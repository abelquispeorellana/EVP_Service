using AdministradorService.Dominio;
using AdministradorService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdministradorService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAdministrador" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAdministrador
    {
        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        AdministradorDOM Autenticar(string NroDocumento, string Contrasenia);

        [FaultContract(typeof(RepetidoException))]

        [OperationContract]
        AdministradorDOM Crear(AdministradorDOM Parametro);

        [OperationContract]
        AdministradorDOM Obtener(string NroDocumento);

        [OperationContract]
        AdministradorDOM Modificar(AdministradorDOM Parametro);

        [OperationContract]
        string Eliminar(string IdAdministradorDOM);

        [OperationContract]
        List<AdministradorDOM> Listar();
    }
}
