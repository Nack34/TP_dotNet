namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioVehiculoTxt : IRepositorioVehiculo  
{
    readonly string _nombreArch = "Vehiculos.txt";

    
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
         // setear ID con los metodos mas abajo

        vehiculo.ID=getNuevoID; //ale:lee la base de datos (txt), y asigna id

        //ale: falta recorrer el txt para ver si no existe otro vehiculo con el mismo dominio (patente)
        if (YaExiste(vehiculo)) throw new Exception("Vehiculo ya existente, no se puede volver a agregar");

        using var sw = new StreamWriter(_nombreArch, true);
        
        sw.WriteLine($"{vehiculo.ID}#{vehiculo.Dominio}#{vehiculo.Marca}#{vehiculo.AnioFabricacion}#{vehiculo.IDTitular}");
    }

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        bool encontre = false;
        string[] lineas = File.ReadAllLines(_nombreArch);
        int lineaAModificar = 0;
        using (var sr = new StreamReader(_nombreArch,true))
        {
            while(!sr.EndOfStream && !encontre)
            {
                lineaAModificar++;
                var vehiculoLeido = LeerVehiculo(sr);
                if (vehiculo.ID == vehiculoLeido.ID) encontre = true;
            }
        }

        if(!encontre) throw new Exception("no esta ese vehiculo");

        string lineaNueva = $"{vehiculo.ID}#{vehiculo.Dominio}#{vehiculo.Marca}#{vehiculo.AnioFabricacion}#{vehiculo.IDTitular}";
        lineas[lineaAModificar -1] =  lineaNueva;
        File.WriteAllLines(_nombreArch,lineas);
    }

    public void EliminarVehiculo(int id)
    {
        bool encontre = false;
        string[] lineas = File.ReadAllLines(_nombreArch);
        int lineaABorrar = 0;
        using (var sr = new StreamReader(_nombreArch,true))
        {
            while(!sr.EndOfStream && !encontre)
            {
                var vehiculoLeido = LeerVehiculo(sr);
                lineaABorrar++;
                if (id == vehiculoLeido.ID) encontre = true; 
            }
        }

        if(!encontre) throw new Exception("no esta ese vehiculo");

        lineas = ActualizarArray(lineas, lineaABorrar);

        File.WriteAllLines(_nombreArch,lineas);
    }

    private String [] ActualizarArray(String [] lineas, int lineaABorrar) {
        
        lineas[lineaABorrar -1] = "";
        string[] nuevaLinea = new String[lineas.Length -1];
        int j = 0;
        for (int i = 0; i < lineas.Length; i++)
        {
            if (lineas[i] != "") 
            {
                nuevaLinea[j] = lineas[i];
                j++;
            }
        }
        return nuevaLinea;
    }

    public List<Vehiculo> ListarVehiculos()
    {
        var resultado = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var Vehiculo = LeerVehiculo(sr);
            resultado.Add(Vehiculo);
        }
        return resultado;
    }

    private Vehiculo LeerVehiculo(StreamReader sr) 
    {
        var vehiculo = new Vehiculo();
        string todosLosCampos = sr.ReadLine() ?? ""; // me viene la linea con toda la info separadas por # 
        
        if (todosLosCampos == "") throw new Exception("literalmente hay una linea vacia (sin datos) en tu archivo de vehiculo");
                 
        string[] campos = todosLosCampos.Split('#');
        vehiculo.ID = int.Parse(campos[0]);
        vehiculo.Dominio = campos[1];
        vehiculo.Marca = campos[2];
        vehiculo.AnioFabricacion = int.Parse(campos[3]);
        vehiculo.IDTitular = int.Parse(campos[4]);
        return vehiculo;
    }

    private bool YaExiste(Vehiculo vehiculo){
        bool encontre = false;
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream && !encontre)
        {
            Vehiculo p = LeerVehiculo(sr);
            if (p.Dominio == vehiculo.Dominio) encontre = true;
        }
        return encontre;
    }




////////////////////////////ASIGNAR ID A LA HORA DE INSTANCIAR/////////////////////////////////////////////////////////    
    private static string RutaArchivoID {get;set;} = "Aseguradora.Repositorio/ArchivosTXT/IDVehiculo";
    
    
    private static int getNuevoID //este te devuelve el id del Vehiculo siguiente
    {
        get
        {
            return RetornarIDVehiculo();
            
        }
    }
    private static void CrearArchivoIDVehiculo() //se ejecuta cuando creamos el txt por primera vez
    {
        StreamWriter archivo = new StreamWriter(RutaArchivoID);
        archivo.WriteLine(1);//inicializa el id con 1;
        archivo.Close();
    }
    
    private static int RetornarIDVehiculo()
    {
        using var leer = new StreamReader(RutaArchivoID);
        int IDVehiculo= int.Parse(leer.ReadLine() ?? "");; //tengo id actual
        using var archivo = new StreamWriter(RutaArchivoID,false); 
        IDVehiculo++;
        archivo.WriteLine((IDVehiculo));//sobreescribo el id con id+1 en el archivo
        return IDVehiculo-1;
    }

}