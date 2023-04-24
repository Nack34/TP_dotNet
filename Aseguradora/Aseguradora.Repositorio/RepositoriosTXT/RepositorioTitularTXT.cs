namespace Aseguradora.Repositorio;
using Aseguradora.Aplicacion;

public class RepositorioTitularTXT : IRepositorioTitular{
    private readonly string _nombreArch = "titulares.txt";

    public void AgregarTitular(Titular titular){
        using var sw = new StreamWriter(_nombreArch,true);
        sw.WriteLine(titular.ID);
        sw.WriteLine(titular.DNI);
        sw.WriteLine(titular.Nombre);
        sw.WriteLine(titular.Direccion);
        sw.WriteLine(titular.Telefono);
        sw.WriteLine(titular.Email);
    }

    public void ModificarTitular(Titular titularModificado){
        //Probar forma sin StreamReader, es decir usando los metodos de File
        using var sr = new StreamReader(_nombreArch);
        List<Titular> listaTitulares = new List<Titular>();
        var titularAux = new Titular();
        bool existe = false;
        while(!sr.EndOfStream){
            titularAux = LeerTitular(sr);
            if(titularAux.DNI == titularModificado.DNI){
                listaTitulares.Add(titularModificado);
                existe = true;
            }
            else
                listaTitulares.Add(titularAux);
        }
        File.Delete(_nombreArch);
        foreach(var titular in listaTitulares){
            AgregarTitular(titular);
        }
        if(!existe) throw new Exception("No existe un titular con este DNI");
    }

    Titular LeerTitular(StreamReader sr){
        var titular = new Titular();
        titular.ID = int.Parse(sr.ReadLine() ?? "");
        titular.DNI = int.Parse(sr.ReadLine() ?? "");
        titular.Nombre = sr.ReadLine() ?? "";
        titular.Direccion = sr.ReadLine() ?? "";
        titular.Telefono = sr.ReadLine() ?? "";
        titular.Email = sr.ReadLine() ?? "";
        return titular;
    }

    public void EliminarTitular(int id){
        //Probar forma sin StreamReader, es decir usando los metodos de File
        using var sr = new StreamReader(_nombreArch);
        List<Titular> listaTitulares = new List<Titular>();
        var titularAux = new Titular();
        bool existe = false;
        while(!sr.EndOfStream){
            titularAux = LeerTitular(sr);
            if(titularAux.ID != id)
                listaTitulares.Add(titularAux);
            else{
                existe = true;
            }
        }
        File.Delete(_nombreArch);
        foreach(var titular in listaTitulares){
            AgregarTitular(titular);
        }
        if(!existe) throw new Exception("No existe un titular con este ID");       
    }

    public List<Titular> ListarTitulares(){
        using var sr = new StreamReader(_nombreArch);
        List<Titular> listaTitulares = new List<Titular>();
        Titular titularAux = new Titular();
        while(!sr.EndOfStream){
            listaTitulares.Add(LeerTitular(sr));
        }
        return listaTitulares;
    }
}