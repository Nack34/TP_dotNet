namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioVehiculoTxt : IRepositorioVehiculo  
{
    readonly string _nombreArch = "Vehiculos.txt";

    private static int ID = 1000;
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        vehiculo.ID = ID;
        sw.WriteLine($"{ID++}#{vehiculo.Dominio}#{vehiculo.Marca}#{vehiculo.AnioFabricacion}#{vehiculo.IDTitular}");
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
        
        if (todosLosCampos == "") throw new Exception("no habia nada");
                 
        string[] campos = todosLosCampos.Split('#');
        vehiculo.ID = int.Parse(campos[0]);
        vehiculo.Dominio = campos[1];
        vehiculo.Marca = campos[2];
        vehiculo.AnioFabricacion = int.Parse(campos[3]);
        vehiculo.IDTitular = int.Parse(campos[4]);
        return vehiculo;
    }

}
