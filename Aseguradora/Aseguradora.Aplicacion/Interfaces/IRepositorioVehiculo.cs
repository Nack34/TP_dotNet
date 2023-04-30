namespace Aseguradora.Aplicacion;

public interface IRepositorioVehiculo
{
    void AgregarVehiculo(Vehiculo vehiculo);

    void ModificarVehiculo(Vehiculo vehiculo);

    void EliminarVehiculo(int id);

    List<Vehiculo> ListarVehiculos();

     //todo con respecto al ID
    static string RutaArchivoID {get;set;}="";
    static void CrearArchivoIDVehiculo(){}
    static int getNuevoID{get;}
}