namespace Aseguradora.Aplicacion;

public class ListarPolizasUseCase   
{
    private readonly IRepositorioPoliza _repo;
    public ListarPolizasUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public void Ejecutar()
    {
        _repo.ListarPolizas();
    }
}
