namespace Aseguradora.Aplicacion;

public class ListarTitularesConSusVehiculosUseCase{
    private readonly IRepositorioTitular _repo;
    private readonly IRepositorioVehiculo _repoVehiculos;
    
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo, IRepositorioVehiculo repoVehiculo)
    {
        this._repo = repo;
        this._repoVehiculos = repoVehiculo;
    }

    public List<Titular> Ejecutar(int DNI)
    {
        List<Titular> listaTitulares = _repo.ListarTitulares();
        List<Vehiculo> listaVehiculos = _repoVehiculos.ListarVehiculos();
        foreach(Titular titular in listaTitulares){
            foreach(Vehiculo v in listaVehiculos){
                if(v.IDTitular == titular.ID)
                    titular.listaVehiculos.Add(v);
            }
        }
        return listaTitulares;
    }
}