using System.ServiceModel;


namespace GestionarPublicidadService
{
    [ServiceContract]
    public interface IPagina
    {
        [OperationContract]
        void Registrar();

        [OperationContract]
        void Consultar();

        [OperationContract]
        void Editar();

        [OperationContract]
        void Eliminar();
    }
}

