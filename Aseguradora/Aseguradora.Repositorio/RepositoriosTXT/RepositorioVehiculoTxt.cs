namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioVehiculoTxt : IRepositorioVehiculo  
{
    readonly string _nombreArch = "Vehiculos.txt";

    private static int ID = 1000;
    public void AgregarVehiculo(Vehiculo Vehiculo)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        Vehiculo.ID = ID;
        sw.WriteLine($"{ID++}#{Vehiculo.Dominio}#{Vehiculo.Marca}#{Vehiculo.AnioFabricacion}#{Vehiculo.IDTitular}");
    }


    public void ModificarVehiculo(Vehiculo Vehiculo)
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
                if (Vehiculo.ID == vehiculoLeido.ID) encontre = true;
            }
        }

        if(!encontre) throw new Exception("no esta ese vehiculo");

        string campo;
        string lineaNueva = $"{Vehiculo.ID}#";
        Console.WriteLine("escribi el dominio del nuevo vehiculo");
        campo = Console.ReadLine() ?? "";
        lineaNueva+=$"{campo}#";
        Console.WriteLine("escribi la marca del nuevo vehiculo");
        campo = Console.ReadLine() ?? "";
        lineaNueva+=$"{campo}#";
        Console.WriteLine("escribi el año de fabricacion del nuevo vehiculo");
        campo = Console.ReadLine() ?? "";
        lineaNueva+=$"{campo}#";
        Console.WriteLine("escribi el ID del titular del nuevo vehiculo");
        campo = Console.ReadLine() ?? "";
        lineaNueva+=$"{campo}";
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

        File.WriteAllLines(_nombreArch,nuevaLinea);
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
        if (todosLosCampos != "")
        {
            string[] campos = todosLosCampos.Split('#');
            vehiculo.ID = int.Parse(campos[0]);
            vehiculo.Dominio = campos[1];
            vehiculo.Marca = campos[2];
            vehiculo.AnioFabricacion = int.Parse(campos[3]);
            vehiculo.IDTitular = int.Parse(campos[4]);
            return vehiculo;
        }
        else throw new Exception("no habia nada");
    }

}
