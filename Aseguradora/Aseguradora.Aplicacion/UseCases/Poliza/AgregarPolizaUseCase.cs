namespace Aseguradora.Aplicacion;

public class AgregarPolizaUseCase   
{
    private readonly IRepositorioPoliza _repo;
    public AgregarPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Poliza poliza)
    {
        _repo.AgregarPoliza(poliza);
    }
}
