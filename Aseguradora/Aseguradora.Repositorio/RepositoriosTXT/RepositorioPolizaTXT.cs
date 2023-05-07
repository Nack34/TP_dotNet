namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioPolizaTXT : IRepositorioPoliza  
{
    readonly string _nombreArch = "polizas.txt";
    public void AgregarPoliza(Poliza poliza)
    {
        // setea ID con los metodos mas abajo
        poliza.ID=getNuevoID; //ale:lee la base de datos (txt), y asigna id

        if (YaExiste(poliza)) throw new Exception("Poliza ya existente, no se puede volver a agregar");

        EscribirPoliza(poliza);
    }
    public bool YaExiste(Poliza poliza){
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza p = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            if (p.ID == poliza.ID) return true;
        }
        return false;
    }
    public List<Poliza> ListarPolizas()
    {
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            polizas.Add(poliza);
        }
        return polizas;
    }

    public void EliminarPoliza(int ID){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            if (poliza.ID != ID) polizas.Add(poliza);
            else seEncontro=true;
        }
        File.Delete(_nombreArch); // borrar archivo
        foreach (var poliza in polizas){
            EscribirPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro la poliza");
    }
    
    public void ModificarPoliza(Poliza polizaModificada){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            if (poliza.ID != polizaModificada.ID) polizas.Add(poliza);
            else {
                seEncontro=true;
                polizas.Add(polizaModificada);
            }
        }        
        File.Delete(_nombreArch); // borrar archivo
        foreach (var poliza in polizas){
            EscribirPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro la poliza");
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
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(poliza.ID);
        sw.WriteLine(poliza.VehiculoId);
        sw.WriteLine(poliza.ValorAsegurado);
        sw.WriteLine(poliza.Franquicia);
        sw.WriteLine(poliza.TipoDeCobertura);
        sw.WriteLine(poliza.FechaDeInicioDeVigencia);
        sw.WriteLine(poliza.FechaDeFinDeVigencia);
    }


////////////////////////////ASIGNAR ID A LA HORA DE INSTANCIAR/////////////////////////////////////////////////////////    
    private static string RutaArchivoID {get;set;} = "Aseguradora.Repositorio/ArchivosTXT/IDPoliza";
    
    private static int getNuevoID //este te devuelve el id del Poliza siguiente
    {
        get
        {
            return RetornarIDPoliza();
            
        }
    }
    private static void CrearArchivoIDPoliza() //se ejecuta cuando creamos el txt por primera vez
    {
        StreamWriter archivo = new StreamWriter(RutaArchivoID);
        archivo.WriteLine(1);//inicializa el id con 1;
        archivo.Close();
    }
    
    private static int RetornarIDPoliza()
    {
        using var leer = new StreamReader(RutaArchivoID);
        int IDPoliza= int.Parse(leer.ReadLine() ?? "");; //tengo id actual
        using var archivo = new StreamWriter(RutaArchivoID,false); 
        IDPoliza++;
        archivo.WriteLine((IDPoliza));//sobreescribo el id con id+1 en el archivo
        return IDPoliza-1;
    }
}