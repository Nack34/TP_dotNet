namespace Aseguradora.Aplicacion;

public class ModificarPolizaUseCase   
{
    private readonly IRepositorioPoliza _repo;
    public ModificarPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Poliza poliza)
    {
        _repo.ModificarPoliza(poliza);
    }
}
