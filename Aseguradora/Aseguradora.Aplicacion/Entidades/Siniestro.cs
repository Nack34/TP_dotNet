namespace Aseguradora.Aplicacion;

public class Siniestro { 
    public int ID {get; set;} = -1; 
    public int PolizaId {get;set;}
    public string Direccion {get; set;} = "No tiene direccion";
    public string Email {get; set;} = "No tiene email";
    public string DireccionDelHecho {get; set;} = "No tiene direccion";
    public string DescripciónDelAccidente {get; set;} = "No tiene descripcion";
    public DateTime FechaDeingreso {get;set;}
    public DateTime FechaDeOcurrencia {get;set;}

   public Siniestro(){}
    public Siniestro(int polizaId, String direccion, String email,String direccionDelHecho, String descripciónDelAccidente, 
                    DateTime fechaDeingreso, DateTime fechaDeOcurrencia){
        PolizaId=polizaId;
        Direccion=direccion;
        Email=email;
        DireccionDelHecho=direccionDelHecho;
        DescripciónDelAccidente = descripciónDelAccidente;
        FechaDeingreso=DateTime.Now;
        FechaDeOcurrencia=fechaDeOcurrencia;
    }

    public override String ToString(){
        return $"ID: {ID}, PolizaId: {PolizaId}, Direccion: {Direccion}, "+ 
        $"Email: {Email}, DireccionDelHecho: {DireccionDelHecho}, DescripciónDelAccidente: {DescripciónDelAccidente}, "+
        $"FechaDeingreso: {FechaDeingreso}, FechaDeOcurrencia: {FechaDeOcurrencia}";
    }

}