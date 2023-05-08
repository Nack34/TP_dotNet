namespace Aseguradora.Aplicacion;

public interface IRepositorioTitular{

    void AgregarTitular(Titular titular);

    void ModificarTitular(Titular titular);
    void EliminarTitular(int id);
    List<Titular> ListarTitulares();

    //todo con respecto al ID
    static string RutaArchivoID {get;}="";
    static void CrearArchivoIDTitular(){}
    static int getNuevoID{get;}
    
}