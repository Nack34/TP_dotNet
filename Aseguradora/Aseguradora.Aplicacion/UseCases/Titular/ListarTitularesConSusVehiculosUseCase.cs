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
        List<Titular> listaTitulares = _repo.ListarTitulares(); //Obtengo todos los titulares
        List<Vehiculo> listaVehiculos = _repoVehiculos.ListarVehiculos(); //Obtengo todos los vehiculos
        foreach(Titular titular in listaTitulares){
            foreach(Vehiculo v in listaVehiculos){
                if(v.IDTitular == titular.ID) //Si encuentro un vehiculo que corresponde al titular actual
                    titular.listaVehiculos.Add(v); //Agrego el vehiculo que coincide a la lista de vehiculos
            }                                      //del titular
        }
        return listaTitulares;
    }
}