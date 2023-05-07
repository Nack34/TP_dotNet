namespace Aseguradora.Aplicacion;

public class Titular : Persona{ 
    public string Direccion {get; set;} = "No tiene direccion";
    public string Email {get; set;} = "No tiene email";

    public List<Vehiculo> listaVehiculos {get; set;} = new List<Vehiculo>();


    public Titular(){} 
    public Titular(int dni, string apellido, string nombre) : base(dni,apellido,nombre){}

    //Invalidar ToString
    public override string ToString(){
        return $"{base.ToString} {Direccion} {Email}";
    }

}