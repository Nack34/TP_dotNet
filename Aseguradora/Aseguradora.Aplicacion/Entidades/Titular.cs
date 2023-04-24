namespace Aseguradora.Aplicacion;

public class Titular : Persona{ 
    public string Direccion {get; set;} = "";
    public string Email {get; set;} = "";

    public Titular(){}
    public Titular(int dni, string apellido, string nombre) : base(dni,apellido,nombre){}

    //Invalidar ToString
    public override string ToString(){
        return $"{base.ToString} {Direccion} {Telefono} {Email}";
    }

}