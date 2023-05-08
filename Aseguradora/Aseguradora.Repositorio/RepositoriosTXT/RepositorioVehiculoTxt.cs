namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioVehiculoTXT : IRepositorioVehiculo  
{
    private static string NombreArch {get;}

    //cuando llamo al repositorio me entero si el Sistema operativo usa / o \ para moverse entre directorios y poder crear los archivos.
    static RepositorioVehiculoTXT()
    {
        string separador = Path.DirectorySeparatorChar.ToString();
        if (separador == @"\" ) {
            NombreArch = @"..\Aseguradora.Repositorio\Vehiculos.txt";
            RutaArchivoID = @"..\Aseguradora.Repositorio\IDVehiculos.txt";
        }
        else 
        {
            NombreArch = "../Aseguradora.Repositorio/Vehiculos.txt";
            RutaArchivoID = "../Aseguradora.Repositorio/IDVehiculos.txt";
        }
        
        //el mismo problema de antes, pregunto siempre pero solo va a suceder la primera vez que se ejecute el algoritmo
        if (!File.Exists(RutaArchivoID)) CrearArchivoIDVehiculo();
        
        //el mismo problema de antes, pregunto siempre pero solo va a suceder la primera vez que se ejecute el algoritmo
        if (!File.Exists(NombreArch)) CrearArchivoVehiculoTXT();
    }

    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        if (YaExiste(vehiculo)) throw new Exception("Excepcion: Vehiculo ya existente, no se puede volver a agregar");
        
        using var sw = new StreamWriter(NombreArch, true);
        
         // setear ID con los metodos mas abajo
        vehiculo.ID=getNuevoID;
        
        //en toda una linea separada por  "#" se escriben los datos de un vehiculo
        sw.WriteLine($"{vehiculo.ID}#{vehiculo.Dominio}#{vehiculo.Marca}#{vehiculo.AnioFabricacion}#{vehiculo.IDTitular}");
    }

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        bool encontre = false;
        var vehiculoLeido = new Vehiculo();
        string[] vehiculos = File.ReadAllLines(NombreArch); //cada linea tiene un vehiculo
        int lineaAModificar = 0; // == vehiculoAModificar
        using (var sr = new StreamReader(NombreArch))
        {
            while(!sr.EndOfStream && !encontre)
            {
                lineaAModificar++;
                vehiculoLeido = LeerVehiculo(sr);
                if (vehiculo.Dominio == vehiculoLeido.Dominio) encontre = true;
            }
        }

        if(!encontre) throw new Exception("Excepcion: no se puede modificar pues el vehiculo no existe");

        //el id tiene que ser el q esta leido del archivo (el del id del vehiculo que me viene como parametro puede ser que instancie uno nuevo entonces queda -1 el id pero sus otros valores son validos) 
        string vehiculoNuevo = $"{vehiculoLeido.ID}#{vehiculo.Dominio}#{vehiculo.Marca}#{vehiculo.AnioFabricacion}#{vehiculo.IDTitular}";
        vehiculos[lineaAModificar -1] =  vehiculoNuevo;
        File.WriteAllLines(NombreArch,vehiculos);
    }

    public void EliminarVehiculo(int id)
    {
        bool encontre = false;
        var vehiculoLeido = new Vehiculo();
        string[] vehiculos = File.ReadAllLines(NombreArch);
        int lineaABorrar = 0;
        using (var sr = new StreamReader(NombreArch))
        {
            while(!sr.EndOfStream && !encontre)
            {
                lineaABorrar++;
                vehiculoLeido = LeerVehiculo(sr);
                if (id == vehiculoLeido.ID) encontre = true; 
            }
        }

        if(!encontre) throw new Exception("Excepcion: no se puede eliminar pues el vehiculo no existe");

        //actualizarArray elimina del arreglo la posicion a eliminar
        ActualizarArray(ref vehiculos, lineaABorrar);

        File.WriteAllLines(NombreArch,vehiculos);
    }



    public List<Vehiculo> ListarVehiculos()
    {
        var resultado = new List<Vehiculo>();
        using var sr = new StreamReader(NombreArch);
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

        // me viene la linea con toda la info separadas por # 
        string todosLosCampos = sr.ReadLine() ?? ""; 

        //cada campo es un dato del vehiculo
        string[] campos = todosLosCampos.Split('#');

        //empiezo a darle valor a las propiedades del vehiculo
        vehiculo.ID = int.Parse(campos[0]);
        vehiculo.Dominio = campos[1];
        vehiculo.Marca = campos[2];
        vehiculo.AnioFabricacion = int.Parse(campos[3]);
        vehiculo.IDTitular = int.Parse(campos[4]);
        return vehiculo;
    }

    private bool YaExiste(Vehiculo vehiculo){
        bool encontre = false;

        //esto en caso de que no exista el archivo lo crea, lo malo lo pregunto siempre, asi q habria que ver si conviene ya tener el ".txt" creado antes (sin valores).
        // if (!File.Exists(NombreArch)) 
        // {
        //     var fs = File.Create(NombreArch); //el File.Create crea un archivo (el del parametro) y retorna un objeto
        //     fs.Close(); //hay q cerrarlo
        // }

        using (var sr = new StreamReader(NombreArch))
        {
            while (!sr.EndOfStream && !encontre)
            {
                Vehiculo p = LeerVehiculo(sr);
                if (p.Dominio == vehiculo.Dominio) encontre = true;
            }
        };
        return encontre;
    }

    private void ActualizarArray(ref String [] vehiculos, int vehiculoAborrar) {
        for (int i = vehiculoAborrar-1; i < vehiculos.Length-1;i++)
        {
            vehiculos[i] = vehiculos[i+1];
        }
        Array.Resize(ref vehiculos, vehiculos.Length - 1);
    }



/////////////////////////////////////////////  ASIGNAR ID A LA HORA DE INSTANCIAR  //////////////////////////////////////////////////////  

    private static string RutaArchivoID {get;}
    
    //devuelve el id siguiente al que ya existe, ej: ultimo id creado es 4, en el archivo habra un 5.
    //1era ejecucion: crea el archivo con el id "1", lo lee para asignarlo al vehiculo y despues aumenta en 1 el id en el archivo (sobreescribe)
    private static int getNuevoID => RetornarIDVehiculo(); 


    //se ejecuta cuando creamos el txt por primera vez
    private static void CrearArchivoIDVehiculo() 
    {
        using (var archivo = new StreamWriter(RutaArchivoID))
        {
            archivo.WriteLine(1);//inicializa el id con 1;
        }
    }
    
    //se ejecuta cuando creamos el txt por primera vez
    private static void CrearArchivoVehiculoTXT() 
    {
        using var archivo = new StreamWriter(NombreArch);
    }
    private static int RetornarIDVehiculo()
    {
        //esto lo hago siempre
        int IDVehiculo;
        using (var sr = new StreamReader(RutaArchivoID))
        {
            IDVehiculo= int.Parse(sr.ReadLine() ?? "");
             //tengo id actual
        }
        using (var sw = new StreamWriter(RutaArchivoID,false))
        {
            sw.WriteLine((++IDVehiculo));//sobreescribo el id con id+1 en el archivo
        } 
        return IDVehiculo-1;
    }

}
/*
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWWWWWWWWWWWWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNXXK00OOOOOOOOOO00KXXNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWNK0OkxxxxxxxxxxxxxxxxxxxxkO0KNWWMMMMWMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNX0OkxdxxxxxxxxxxxxxxxxxxxxxxxxxxxO0XNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMWWNKkxxxxxxxxxxxxxxxxxxxxxxxxxxxxdxxxxxxxkKNWMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMWX0kxdxxxxxxxxxxxdxxddxxxxxxxxxxxxxxxxxxdxxxk0XWMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMNKkxxxxxxxxxxxxxxdddxxxxxxxxxxxxxxxxxxxxxxxxxxxk0NWMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMWXOxdxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxOXWWMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMWKkxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkKWMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMWWXOdooollollllllllllloooooddddxxxxxxxxxxxxxxxxxxxxxxxxxxxKWMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMWMMMWKd;;:::::::::::;..;::;::::::::ccc:;:oxxxxxxxxxxxxxxxxxxxxxxkKWMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMW0kkko::lodddolclcccc::cccccccclclllllc::loolloddxxdxxxxxxxxxxxxxkXWMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMNx:clllccdOOOd::llllccllccccc;co::loooollloooo:,;cclddxxxxxxxxxxxxx0NMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMOcdkxxdccxOOk:;ldkkkxxxkxxxxxllOo;okkOOkxdddollc:::;:cldxdxxxxxxxxxkXMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMNdlxkkxlokOOOo;;codxkkxxxxxxxxockk:cxkkkkkxxkkkxdllc:::;cloxxxxxxxxxxKWMMMMMMMMMMMMMMMMMM
MMMMMMMMMMM0ccooodxOOkOkodkxddddooooodddxdcdOl;oxkkkkkxxxkkxxxdlc:::;:codxxxxxxxKWMMMMMMMMMMMMMMMMMM
MMMMMMMMMWOc;ldkkOOOOOOdokkxdxkOOkxdddddddoodlcloooooooooooooolcoc,cll:,:lllooooxKKXNWWMMMMMMMMMMMMM
MMMMMMMMMXl;:;:dOOOOOOOxokkolldkOOOOO000000OddOkxxxxkkkkxxxxxxo:ol,lxxxdooooollllloodxkkOOKNMMMMMMMM
MMMMMMMMMKc,;;;oOOO00000xdkkOOOOOOOOOOOOOOOOxoxdccclxOkOOOOOOOkdlcokxoxOOOkkkkkkkkxxxxxdooldXMMMMMMM
MMMMMMMMW0lokxkOOO0OkkkkkxdxxdkOOOOOOOOOOOOOxokkxxxkkOOOOOOOOOOOkkkOxoxOOOO0000000000OOOkllokWMMMMMM
MMMMMMMMXdd0000Okdc;,'''',;coxddkOOOOOOOOOOOxokOOOOOOOOOOOOOOOOOOOOOxoxOOOkxolllllldkOOOkoddl0MMMMMM
MMMMMMMM0clddddd:............:xxodxxxkkxxxxkdlxkkkxkkkkkkkkkkkkkOOOOdokOkl,.........,:dOOOOOxoKMMMMM
MMMMMMMM0:,;;;;...........''..,xdcooooooooool:ldooooooooooodddddddxxookd,.............'lOOOOxo0MMMMM
MMMMMMMMWk;',,'..''..;;;:..''..cdcclllllllllc:clllllllllllllllllllolcok;..'..':;:,..''.'coodol0MMMMM
MMMMMMMMMWXxc,,,''..;c::l;..,..;llccccccccccccccccccccccllllllllllllloo'.''.':c;cc,.''..',,,,oXMMMMM
MMMMMMMMMMMMWKKO;''.'::::'.'',lxxxxxxxxxxxxxxdddddddddddddddoooooooooolo:''..,:;:;..'';c:::cxXMMMMMM
MMMMMMMMMMMMMMMNx,'',;'';,'',dNMMMMMMMMMMMMMMMMWWWWWWWWWWWWNNNNNNNNNXXNWKl''',;',;,'':OWNXNWMMMMMMMM
MMMMMMMMMWWXXXKK0x:'.',,'.';d0KKKKKKKKKKXKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKOo;.',,''.'ckKKKKXNWMMMMMMM
MMMMMMMMMWX0OkkxxxxdoooooodkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxdooooooxkkkxkkOKWMMMMMMM
*/