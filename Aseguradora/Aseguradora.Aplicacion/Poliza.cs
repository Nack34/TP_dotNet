namespace Aseguradora.Aplicacion;
public class Poliza
{
    // todo propiedades
    public int ID {get; set;} = -1; // ------------------------------------------------------------ solo get? (solo de lectura?) Como modificarlo? (Listar modifica el ID)
    public int VehiculoId {get;set;}
    public double ValorAsegurado {get;set;}
    public String? Franquicia {get;set;}
    public String? TipDeCobertura {get;set;}
    public DateTime FechaDeInicioDeVigencia {get;set;}
    public DateTime FechaDeFinDeVigencia {get;set;}

    public Poliza(){}
    public Poliza(int vehiculoId, double valorAsegurado, String franquicia,String tipDeCobertura, 
                    DateTime fechaDeInicioDeVigencia, DateTime fechaDeFinDeVigencia){
        VehiculoId=vehiculoId;
        ValorAsegurado=valorAsegurado;
        Franquicia=franquicia;
        TipDeCobertura=tipDeCobertura;
        FechaDeInicioDeVigencia=fechaDeInicioDeVigencia;
        FechaDeFinDeVigencia=fechaDeFinDeVigencia;
    }

    public override String ToString(){
        return $"ID: {ID}, VehiculoId: {VehiculoId}, valorAsegurado: {ValorAsegurado}, "+ 
        $"franquicia: {Franquicia}, tipDeCobertura: {TipDeCobertura}, fechaDeInicioDeVigencia: {FechaDeInicioDeVigencia}, "+
        $"fechaDeFinDeVigencia: {FechaDeFinDeVigencia}";
    }
}
