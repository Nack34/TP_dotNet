namespace Aseguradora.Repositorio;
using Aseguradora.Aplicacion;
public class RepositorioTitularTXT : IRepositorioTitular{
    private static string _nombreArch {get;}

    static RepositorioTitularTXT()
    {
        string separador = Path.DirectorySeparatorChar.ToString();
        if (separador == @"\" ) {
            _nombreArch = @"..\Aseguradora.Repositorio\Titulares.txt";
            RutaArchivoID = @"..\Aseguradora.Repositorio\IDTitulares.txt";
        }
        else 
        {
            _nombreArch = "../Aseguradora.Repositorio/Titulares.txt";
            RutaArchivoID = "../Aseguradora.Repositorio/IDTitulares.txt";
        }
        
        //el mismo problema de antes, pregunto siempre pero solo va a suceder la primera vez que se ejecute el algoritmo
        if (!File.Exists(RutaArchivoID)) CrearArchivoIDTitular();
        
        //el mismo problema de antes, pregunto siempre pero solo va a suceder la primera vez que se ejecute el algoritmo
        if (!File.Exists(_nombreArch)) CrearArchivoTitularTXT();
    }

    public RepositorioTitularTXT()
    {
     CrearArchivoIDTitular();   
    }
    public void AgregarTitular(Titular titular){ //agregarTitular es PersistirTitular

        // setear ID con los metodos mas abajo
         //ale:lee la base de datos (txt), y asigna id
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
        //Probar forma sin StreamReader, es decir usando los metodos de File
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
        if(!existe) throw new Exception("No existe un titular con este DNI");
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
        //Probar forma sin StreamReader, es decir usando los metodos de File
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
        if(!existe) throw new Exception("No existe un titular con este ID");       
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


////////////////////////////ASIGNAR ID A LA HORA DE INSTANCIAR/////////////////////////////////////////////////////////    
    private static string RutaArchivoID {get;}
    
    
    private static int getNuevoID => RetornarIDTitular();//este te devuelve el id del titular siguiente

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
            IDtitular= int.Parse(leer.ReadLine() ?? ""); //tengo id actual
        }
        using (var archivo = new StreamWriter(RutaArchivoID,false))
        {
            IDtitular++;
            archivo.WriteLine((IDtitular));//sobreescribo el id con id+1 en el archivo
        }
        return IDtitular-1;
    }






}