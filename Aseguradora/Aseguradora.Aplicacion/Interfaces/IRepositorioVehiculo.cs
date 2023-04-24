namespace Aseguradora.Aplicacion;

public interface IRepositorioVehiculo
{
    void AgregarVehiculo(Vehiculo vehiculo);

    void ModificarVehiculo(Vehiculo vehiculo);

    void EliminarVehiculo(int id);

    List<Vehiculo> ListarVehiculos();
}