using System.ServiceModel;


namespace GestionarPublicidadService
{
    [ServiceContract]
    public interface IConexion
    {
        [OperationContract]
        void GestionarConexion();
    }
}

