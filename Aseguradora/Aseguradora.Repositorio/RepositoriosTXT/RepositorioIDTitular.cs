namespace Aseguradora.Repositorio;

using System.IO;
public class RepositorioIDTitular:IRepositorioIDTitular
{
    private static int _idTitulares;
    private static string _rutaArchivo="";
    public static string RutaArchivo //antes de usar el txt, hay que especificar la ruta
    {
        get=>_rutaArchivo; //por si queremos saber la ruta de mi txt
        set
        {
            _rutaArchivo=value;
        }
    }
    
    public static int IDtitulares //este te devuelve el id del titular siguiente
    {
        get
        {
            RepositorioIDTitular.IncrementarIDTitular();
            return _idTitulares-1;
            
        }
    }
    private static void CrearRepositorioIDTitular() //se ejecuta cuando creamos el txt por primera vez
    {
        StreamWriter archivo = new StreamWriter(RutaArchivo);
        archivo.WriteLine(1);//inicializa el id con 1;
        archivo.Close();
    }
    public static void CargarRepositorioIDTitular() //leer el txt y lo actualiza al id
    {
        if(File.Exists(RutaArchivo)) //si existe el txt, uso el contenido del txt
        {
            StreamReader archivo = new StreamReader(RutaArchivo);
            _idTitulares=archivo.Read();
        }
        else //sino, lo creo
        {
            CrearRepositorioIDTitular();
        }
    }
    
    private static void IncrementarIDTitular()
    {
        // _idTitulares = leer del archivo
        StreamWriter archivo = new StreamWriter("IncrementoIDTitular.txt"); 
        archivo.WriteLine((_idTitulares+1));//escribo el id +1 en el archivo nuevo
        archivo.Close();
        File.Move("IncrementoIDTitular.txt",RutaArchivo,true); //cambio el nombre del nuevo archivo al nombre del txt original y piso el archivo viejo
        RepositorioIDTitular.CargarRepositorioIDTitular();
    }

}