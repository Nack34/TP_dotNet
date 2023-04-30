namespace Aseguradora.Aplicacion;

public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza poliza);
    void ModificarPoliza(Poliza poliza);
    void EliminarPoliza(int ID);
    List<Poliza> ListarPolizas();

    //todo con respecto al ID
    static string RutaArchivoID {get;set;}="";
    static void CrearArchivoIDPoliza(){}
    static int getNuevoID{get;}
}