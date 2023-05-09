namespace Aseguradora.Repositorio;
using Aseguradora.Aplicacion;
public class RepositorioTitularTXT : IRepositorioTitular{
    private static string _nombreArch {get;}
    static RepositorioTitularTXT()
    {
        string separador = Path.DirectorySeparatorChar.ToString();
        if (separador == @"\" ) {
            _nombreArch = @"..\Aseguradora.Repositorio\ArchivosTXT\Titulares.txt";
            RutaArchivoID = @"..\Aseguradora.Repositorio\ArchivosTXT\IDTitulares.txt";
        }
        else 
        {
            _nombreArch = "../Aseguradora.Repositorio/ArchivosTXT/Titulares.txt";
            RutaArchivoID = "../Aseguradora.Repositorio/ArchivosTXT/IDTitulares.txt";
        }
        
        if (!File.Exists(RutaArchivoID)) CrearArchivoIDTitular();
        if (!File.Exists(_nombreArch)) CrearArchivoTitularTXT();
    }
    public RepositorioTitularTXT()
    {
     CrearArchivoIDTitular();   
    }
    public void AgregarTitular(Titular titular){ 

        // setear ID con los metodos mas abajo
        if(YaExiste(titular))
            throw new Exception("Titular ya existente, no se puede volver a agregar");
        else{ 
            titular.ID = getNuevoID;
            EscribirTitular(titular);
        }
    }
    public bool YaExiste(Titular titular){
        using var leer= new StreamReader(_nombreArch);
        var titularAux = new Titular();
        while(!leer.EndOfStream)
        {
            titularAux = LeerTitular(leer);
            if(titularAux.DNI == titular.DNI)
                return true;
        }
        return false;
    }
    private void EscribirTitular(Titular titular)
    {
        using var sw = new StreamWriter(_nombreArch,true);
        sw.WriteLine(titular.ID);
        sw.WriteLine(titular.DNI);
        sw.WriteLine(titular.Nombre);
        sw.WriteLine(titular.Direccion);
        sw.WriteLine(titular.Telefono);
        sw.WriteLine(titular.Email);
    } 
    public void ModificarTitular(Titular titularModificado){
        using var sr = new StreamReader(_nombreArch);
        var listaTitulares = new List<Titular>();
        var titularAux = new Titular();
        bool existe = false;
        while(!sr.EndOfStream){
            titularAux = LeerTitular(sr);
            if(titularAux.DNI == titularModificado.DNI){
                listaTitulares.Add(titularModificado);
                existe = true;
            }
            else
                listaTitulares.Add(titularAux);
        }
        File.Delete(_nombreArch);
        foreach(var titular in listaTitulares){
           EscribirTitular(titular);
        }
        if(!existe) throw new Exception("No existe un titular con este DNI, no se puede modificar");
    }
    private Titular LeerTitular(StreamReader sr){ 
        var titular = new Titular();
        titular.ID = int.Parse(sr.ReadLine() ?? "");
        titular.DNI = int.Parse(sr.ReadLine() ?? "");
        titular.Nombre = sr.ReadLine() ?? "";
        titular.Direccion = sr.ReadLine() ?? "";
        titular.Telefono = sr.ReadLine() ?? "";
        titular.Email = sr.ReadLine() ?? "";
        return titular;
    }
    public void EliminarTitular(int id){
        using var sr = new StreamReader(_nombreArch);
        List<Titular> listaTitulares = new List<Titular>();
        var titularAux = new Titular();
        bool existe = false;
        while(!sr.EndOfStream){
            titularAux = LeerTitular(sr);
            if(titularAux.ID != id)
                listaTitulares.Add(titularAux);
            else{
                existe = true;
            }
        }
        File.Delete(_nombreArch);
        foreach(var titular in listaTitulares){
            EscribirTitular(titular);
        }
        if(!existe) throw new Exception("No existe un titular con este ID, no se puede eliminar");       
    }
    public List<Titular> ListarTitulares(){
        using var sr = new StreamReader(_nombreArch);
        List<Titular> listaTitulares = new List<Titular>();
        Titular titularAux = new Titular();
        while(!sr.EndOfStream){
            listaTitulares.Add(LeerTitular(sr));
        }
        return listaTitulares;
    }

/////////////////////////////////////////////  ASIGNAR ID A LA HORA DE INSTANCIAR  //////////////////////////////////////////////////////    
    private static string RutaArchivoID {get;}
    private static int getNuevoID => RetornarIDTitular();
    private static void CrearArchivoTitularTXT() 
    {
        using var archivo = new StreamWriter(_nombreArch);
    }
    private static void CrearArchivoIDTitular() //se ejecuta cuando creamos el txt por primera vez
    {
        using StreamWriter archivo = new StreamWriter(RutaArchivoID);
        archivo.WriteLine(1);//inicializa el id con 1;
    }
    private static int RetornarIDTitular()
    {
        int IDtitular;
        using (var leer = new StreamReader(RutaArchivoID))
        {
            IDtitular= int.Parse(leer.ReadLine() ?? ""); // obtengo id actual
        }
        using (var archivo = new StreamWriter(RutaArchivoID,false))
        {
            IDtitular++;
            archivo.WriteLine((IDtitular)); // sobreescribo el id con id+1 en el archivo
        }
        return IDtitular-1;
    }
}