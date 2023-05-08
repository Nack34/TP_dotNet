namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioPolizaTXT : IRepositorioPoliza  
{
    private static string NombreArch {get;}
    static RepositorioPolizaTXT()
    {  //cuando llamo al repositorio me entero si el Sistema operativo usa / o \ para moverse entre directorios y 
        //poder crear los archivos.
        string separador = Path.DirectorySeparatorChar.ToString();
        if (separador == @"\" ) { 
            NombreArch = @"..\Aseguradora.Repositorio\ArchivosTXT\Polizas.txt";
            RutaArchivoID = @"..\Aseguradora.Repositorio\ArchivosTXT\IDPolizas.txt";
        }
        else 
        {
            NombreArch = "../Aseguradora.Repositorio/ArchivosTXT/Polizas.txt";
            RutaArchivoID = "../Aseguradora.Repositorio/ArchivosTXT/IDPolizas.txt";
        }
        
        if (!File.Exists(NombreArch)) CrearArchivoPolizaTXT();
        if (!File.Exists(RutaArchivoID)) CrearArchivoIDPoliza();
    }
    public void AgregarPoliza(Poliza poliza)
    {
        if (YaExiste(poliza)) throw new Exception("Poliza ya existente, no se puede volver a agregar");

        // setea ID con los metodos mas abajo
        poliza.ID=GetNuevoID;

        EscribirPoliza(poliza);
    }
    public bool YaExiste(Poliza poliza){
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            Poliza p = LeerPoliza(in sr);
            if (p.ValorAsegurado == poliza.ValorAsegurado &&
                p.Franquicia == poliza.Franquicia &&
                p.TipoDeCobertura == poliza.TipoDeCobertura &&
                p.FechaDeInicioDeVigencia == poliza.FechaDeInicioDeVigencia &&
                p.FechaDeFinDeVigencia == poliza.FechaDeFinDeVigencia)
                     return true;
        }
        return false;
    }
    public List<Poliza> ListarPolizas()
    {
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr);
            polizas.Add(poliza);
        }
        return polizas;
    }
    public void EliminarPoliza(int ID){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr);
            if (poliza.ID != ID) polizas.Add(poliza);
            else seEncontro=true;
        }
        File.Delete(NombreArch); 
        foreach (var poliza in polizas){
            EscribirPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro la poliza, no se puede eliminar");
    }
    public void ModificarPoliza(Poliza polizaModificada){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr);
            if (poliza.ID != polizaModificada.ID) polizas.Add(poliza);
            else {
                seEncontro=true;
                polizas.Add(polizaModificada);
            }
        }        
        File.Delete(NombreArch); 
        foreach (var poliza in polizas){
            EscribirPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro la poliza, no se puede modificar");
    }
    private Poliza LeerPoliza(in StreamReader sr){
        var poliza = new Poliza();
        poliza.ID = int.Parse(sr.ReadLine() ?? "");
        poliza.VehiculoId = int.Parse(sr.ReadLine() ?? "");
        poliza.ValorAsegurado = double.Parse(sr.ReadLine() ?? "");
        poliza.Franquicia = sr.ReadLine() ?? "";
        poliza.TipoDeCobertura = sr.ReadLine() ?? "";
        poliza.FechaDeInicioDeVigencia = DateTime.Parse(sr.ReadLine() ?? "");
        poliza.FechaDeFinDeVigencia = DateTime.Parse(sr.ReadLine() ?? "");
        return poliza;
    }
    private void EscribirPoliza(Poliza poliza){
        using var sw = new StreamWriter(NombreArch, true);
        sw.WriteLine(poliza.ID);
        sw.WriteLine(poliza.VehiculoId);
        sw.WriteLine(poliza.ValorAsegurado);
        sw.WriteLine(poliza.Franquicia);
        sw.WriteLine(poliza.TipoDeCobertura);
        sw.WriteLine(poliza.FechaDeInicioDeVigencia);
        sw.WriteLine(poliza.FechaDeFinDeVigencia);
    }

    //se ejecuta cuando creamos el repositorio por primera vez
    private static void CrearArchivoPolizaTXT() 
    {
        using var archivo = new StreamWriter(NombreArch);
    }

/////////////////////////////////////////  ASIGNAR ID A LA HORA DE INSTANCIAR  ///////////////////////////////////////////////////////    
    private static string RutaArchivoID {get;}
    
    //devuelve el id siguiente al que ya existe, ej: ultimo id creado es 4, en el archivo habra un 5.
    //1era ejecucion: crea el archivo con el id "1", lo lee para asignarlo al poliza y despues aumenta en 1 el id en el archivo (sobreescribe)
    private static int GetNuevoID => RetornarIDPoliza(); 

    //se ejecuta cuando creamos el txt por primera vez
    private static void CrearArchivoIDPoliza() 
    {
        using (var archivo = new StreamWriter(RutaArchivoID))
        {
            archivo.WriteLine(1); //inicializa el id con 1;
        }
    }
    private static int RetornarIDPoliza()
    {
        int IDPoliza;
        using (var sr = new StreamReader(RutaArchivoID))
        {
            IDPoliza= int.Parse(sr.ReadLine() ?? ""); // obtengo id actual
        }
        using (var sw = new StreamWriter(RutaArchivoID,false))
        {
            sw.WriteLine((++IDPoliza)); // sobreescribo el id con id+1 en el archivo
        } 
        return IDPoliza-1;
    }

}
/*
────────────█───────────────█
────────────██─────────────██
─────────────███████████████
────────────█████████████████
───────────███████████████████
──────────████──█████████──████
─────────███████████████████████
────────█████████████████████████
────────█████████████████████████
───███──▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒──███
──█████─█████████████████████████─█████
──█████─████████████████──███████─█████
──█████─██████────────█──█────███─█████
──█████─█████─▓▓▓▓▓▓▓█──█▓▓─▓─███─█████
──█████─███─█─▓▓▓▓▓▓█──█▓▓─▓▓─███─█████
──█████─██──█─▓▓▓▓▓█──█▓▓─▓▓▓─███─█████
──█████─███─█─▓▓▓▓█──█▓▓─▓▓▓▓─███─█████
──█████─█████────█──█─────────███─█████
──█████─█████████──██████████████─█████
───███──████████──███████████████──███
────────█████████████████████████
─────────███████████████████████
──────────█████████████████████
─────────────██████───██████
─────────────██████───██████
─────────────██████───██████
─────────────██████───██████
──────────────████─────████
*/