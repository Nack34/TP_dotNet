namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioPolizaTXT : IRepositorioPoliza  
{
    readonly string _nombreArch = "polizas.txt";
    public void AgregarPoliza(Poliza poliza)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(poliza.ID);
        sw.WriteLine(poliza.VehiculoId);
        sw.WriteLine(poliza.ValorAsegurado);
        sw.WriteLine(poliza.Franquicia);
        sw.WriteLine(poliza.TipDeCobertura);
        sw.WriteLine(poliza.FechaDeInicioDeVigencia);
        sw.WriteLine(poliza.FechaDeFinDeVigencia);
    }
    public List<Poliza> ListarPolizas()
    {
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            polizas.Add(poliza);
        }
        return polizas;
    }

    public void EliminarPoliza(int ID){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            if (poliza.ID == ID) polizas.Add(poliza);
            else seEncontro=true;
        }
        File.Delete(_nombreArch); // borrar archivo
        foreach (var poliza in polizas){
            AgregarPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro el archivo");
    }
    
    public void ModificarPoliza(Poliza polizaModificada){
        bool seEncontro = false;
        var polizas = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Poliza poliza = LeerPoliza(in sr); // ------------------------------------------------------------ FUNCIONA???
            if (poliza.ID == polizaModificada.ID) polizas.Add(poliza);
            else {
                seEncontro=true;
                polizas.Add(polizaModificada);
            }
        }        
        File.Delete(_nombreArch); // borrar archivo
        foreach (var poliza in polizas){
            AgregarPoliza(poliza);
        }

        if (!seEncontro) throw new Exception("No se encontro el archivo");
    }

    public Poliza LeerPoliza(in StreamReader sr){ // ---------------------------------------- Como desacoplarlo? Seria mejor desacoplado?
        var poliza = new Poliza();
        poliza.ID = int.Parse(sr.ReadLine() ?? "");
        poliza.VehiculoId = int.Parse(sr.ReadLine() ?? "");
        poliza.ValorAsegurado = double.Parse(sr.ReadLine() ?? "");
        poliza.Franquicia = sr.ReadLine() ?? "";
        poliza.TipDeCobertura = sr.ReadLine() ?? "";
        poliza.FechaDeInicioDeVigencia = DateTime.Parse(sr.ReadLine() ?? "");
        poliza.FechaDeFinDeVigencia = DateTime.Parse(sr.ReadLine() ?? "");
        return poliza;
    }
}