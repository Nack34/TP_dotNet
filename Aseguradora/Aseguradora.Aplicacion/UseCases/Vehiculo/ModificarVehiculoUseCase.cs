namespace Aseguradora.Aplicacion;

public class ModificarVehiculoUseCase 
{
    private readonly IRepositorioVehiculo _repo;

    public ModificarVehiculoUseCase(IRepositorioVehiculo repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Vehiculo vehiculo)
    {
        _repo.ModificarVehiculo(vehiculo);
    }
}