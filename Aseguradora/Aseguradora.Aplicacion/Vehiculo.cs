namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    // private int _Id, _AnioFabricacion, _IdTitular;
    // private string _Dominio, _Marca;

    public int ID {get;set;} = -1;
    public string Dominio {get;set;}
    public string Marca {get;set;}
    public int AnioFabricacion {get;set;}
    public int IDTitular {get;set;}


    public Vehiculo(string dominio, string marca, int anio, int idTitular)
    {
        Dominio = dominio;
        Marca = marca;
        AnioFabricacion = anio;
        IDTitular = idTitular;
    }
    public Vehiculo(){}

    public override string ToString()
    {
        return $"ID del vehiculo {ID}, Año Fabricacion {AnioFabricacion}, Marca {Marca}, Dominio {Dominio}, ID del titular {IDTitular} ";
    }

}