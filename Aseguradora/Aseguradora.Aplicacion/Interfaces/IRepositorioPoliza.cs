namespace Aseguradora.Aplicacion;

public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza poliza);
    void ModificarPoliza(Poliza poliza);
    void EliminarPoliza(int ID);
    List<Poliza> ListarPolizas();
}