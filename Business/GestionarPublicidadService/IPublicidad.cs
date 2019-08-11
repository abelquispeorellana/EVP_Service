using System.ServiceModel;

namespace GestionarPublicidadService
{
    [ServiceContract]
    public interface IPublicidad
    {
        [OperationContract]
        void Registrar();

        [OperationContract]
        void Consultar();
    }
}

