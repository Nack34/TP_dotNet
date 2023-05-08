namespace Aseguradora.Aplicacion;
public class Poliza
{
    // todo propiedades
    public int ID {get; set;} = -1; // ------------------------------------------------------------ solo get? (solo de lectura?) Como modificarlo? (Listar modifica el ID)
    public int VehiculoId {get;set;}
    public double ValorAsegurado {get;set;}
    public string Franquicia {get;set;} = "No tiene franquicia";
    public string TipoDeCobertura {get;set;}="No tiene tipo de cobertura";
    public DateTime FechaDeInicioDeVigencia {get;set;}
    public DateTime FechaDeFinDeVigencia {get;set;}

    public Poliza(){}
    public Poliza(int vehiculoId, double valorAsegurado, String franquicia,String tipoDeCobertura, 
                    DateTime fechaDeInicioDeVigencia, DateTime fechaDeFinDeVigencia){
        VehiculoId=vehiculoId;
        ValorAsegurado=valorAsegurado;
        Franquicia=franquicia;
        TipoDeCobertura=tipoDeCobertura;
        FechaDeInicioDeVigencia=fechaDeInicioDeVigencia;
        FechaDeFinDeVigencia=fechaDeFinDeVigencia;
    }

    public override String ToString(){
        return $"ID: {ID}, VehiculoId: {VehiculoId}, valorAsegurado: {ValorAsegurado}, "+ 
        $"franquicia: {Franquicia}, tipoDeCobertura: {TipoDeCobertura}, fechaDeInicioDeVigencia: {FechaDeInicioDeVigencia}, "+
        $"fechaDeFinDeVigencia: {FechaDeFinDeVigencia}";
    }
}
/*
MMMMMWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMKl:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:oXMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MWd   ............................................................  .xMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MWo  'k0000000000000000000000000000000000000000000000000000000000x. .xMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXXkl:::::::::::::::::::::::::::::::::::::::::::::::::::::,.  ,ccccclkNMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXK:   ............................................................  .OMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXK:  ;O0000000000000000000000000000000000000000000000000000000000d. .OMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXK:  :XWNNNNNNNWNKxod0XNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNNWNNNNWk. .OMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXK:  cXWNNNWNX0d:.   .,oOXNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNWNNWk. .OMMMMMMMMMMMMMMMMMMMMMM
MWo  ,OXXK:  cXWNNXkl,.  .,:;.  .'cxKNWNWNNNWNNNNNNNNNNNNNNNNNNNNNWWNNNNWk. .OMMMMMNKXWMMMMMMMMMMMMM
MWo  ,OXXK:  cXNNXl.  .;lxkOOko:'.  ;0WNNNWNNWWWWWWWWWWWWWWWWWWWNNNNNNNNNk. .OMMMMNo..xWMMMMMMMMMMMM
MWo  ,OXXK:  cXWNK:  'xOOOOOOOOOk:  'OWXklcccccccccccccccccccccccxXWNWNNWk. .OMWOo:.  'clox0NMMMMMMM
MWo  ,OXXK:  cXWNNd. .oOOOOOOOOOx,  :XWKl........................:0WNNWWWk. .OMX;          .,dXMMMMM
MWo  ,OXXK:  cXWNW0;  ,xOOOOOOOkc. .kNNNXK00000000000000000000000XNWNNWNWk. .OMK,  ;do'  ,l'  ;KMMMM
MWo  ,OXXK:  cXWWNNk'  ;xOOOOOk:. .dNWNNOooloollollllllllllllllookXWNNWNNk. .OMK,  .:;.  cNK;  cNMMM
MWo  ,OXXK:  cXWNNNNk'  'lkOko'  .xXWWWKc.                       ;0NNNNWWk. .OMK,        cNWd. ;KMMM
MWo  ,OXXK:  cXWNNNWN0c. .':,. .c0NWWNNNKOkkkkkkkkkkkkkkkkkkkkkkkKNNNNNWWk. .OMK,  .;;.  cNMd. ,KMMM
MWo  ,OXXK:  cXWNNWNNWNOc.   .:kXWNNNNNNNNNNWNNWNNNNNNNNNNNNNNNNNNNNNNWNNk. .OMK,  ,lc.  cNMd. ,KMMM
MWo  ,OXXK:  cXWNNNNNWNNN0dld0NNNNWNNNNNNNWNNNNNNNNNNNNNNNNNNNNNNNNNNWNNWk. .OMK,  ,lc.  cNWd. ,KMMM
MWo  ,OXXK:  cXWNNNNNNNWWNNWNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNNNNNWNWk. .OMK,  ,lc.  cNMd. ,KMMM
MWo  ,OXXK:  cXWN0kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOKNWk. .OMK,  ,lc.  cNMd. ,KMMM
MWo  ,OXXK:  cXNk'                                                   .lXWk. .OMK,  ,lc.  cNWd. ,KMMM
MWo  ,OXXK:  cXWKxolloolooooolooooooooooooooooooooooooooooooooooolloooONWk. .OMK,  ,lc.  cNMd. ,KMMM
MWo  ,OXXK:  cXWNK0000000000000000000000000000000000000000000000000000XNWk. .OMK,  ,lc.  cNMO. .dNMM
MWo  ,OXXK:  cXNk,....................................................lXWk. .OMK,  ,lc.  cNMWx. .kMM
MWo  ,OXXK:  cXNKdccccccccccccccccccccccccccccccccccccccccccccccccccclkNWk. .OMK,  ,lc.  cNMMWOodXMM
MWo  ,OXXK:  cXWNXXKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKXNWWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXNO;...................................................'oXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXN0l:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:xXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXN0c,'''''''''''''''''''''''''''''''''''''''''''''''''',dXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXN0c,'''''''''''''''''''''''''''''''''''''''''''''''''',dXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXN0l:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:xXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXNO;...................................................'oXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWNXXKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKXNNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWKdccccccccccccccccccccccccccccccccccccccccccccccccccclkNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXNk,....................................................lXWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWNK00000000000000000000000000000000O000000000000000000KXNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXNNNNWNNNNNNNNNNNNNNNNNNNNNNNNWNNNWNNXkokXNNNNNNNNNNNNNNNNWk. .OMK,  ,lc.  cNMMMMMMMMM
MWo  ,OXXK:  cXWNNNNNNNNNNNNNNNNNNNNNNNWNNNXklcd0kl;. .oXNNNNNNNNWWNNNNNWk. .OMK,  'cc.  cNMMMMMMMMM
MWo  ,OXXK:  :XWNNNNNNNNNNNNNNNNNNNNKOOOOxc'    ..     .dOOOOOOOOOOOO0XNWk. .OMK;   ..   cNMMMMMMMMM
MWd  ,OXXK:  cXNNNNNNNNNNNNNNNNWNNNd.....  .,:.  .'cx:   .............lXWk. .OMNl   ..  .dWMMMMMMMMM
MWd  .;cc:.  :XWNNNNNNNNNNNNNNNNNNN0occccldOXNOooOXNNKdcccccccccccccclONWk. .OMM0' .;,  :XMMMMMMMMMM
MMk'......   cXWNNNNNNNNNNNNNNNNNNNNWWWWWWWNNNNWWNNNNNNWWWWWWWWWWWWWWWWNNk. .OMMWo     .kMMMMMMMMMMM
MMWXK0000O;  cXWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWk. .OMMMK,    cNMMMMMMMMMMM
MMMMMMMMMNc  'loooooooooooooooooooooooooooooooooooooooooooooooooooooooooo:. .OMMMWx.  'OMMMMMMMMMMMM
MMMMMMMMMWd.                                                                ;0MMMMXc..dNMMMMMMMMMMMM
MMMMMMMMMMN0OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOXWMMMMMN0KWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
*/