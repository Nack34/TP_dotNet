namespace Aseguradora.Aplicacion;

public class ListarTitularesUseCase{
    private readonly IRepositorioTitular _repo;
    
    public ListarTitularesUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }

    public List<Titular> Ejecutar()
    {
        return _repo.ListarTitulares();
    }
}