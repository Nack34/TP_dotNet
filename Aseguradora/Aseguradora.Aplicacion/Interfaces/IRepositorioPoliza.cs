namespace Aseguradora.Aplicacion;

public interface IRepositorioPoliza
{
    virtual static string NombreArch {get;}="";
    void AgregarPoliza(Poliza poliza);
    void ModificarPoliza(Poliza poliza);
    void EliminarPoliza(int ID);
    List<Poliza> ListarPolizas();

    //todo con respecto al ID
    virtual static string RutaArchivoID {get;}="";
    static void CrearArchivoIDPoliza(){}
    static int getNuevoID{get;}
}
/*
MMMMMMMMMMMMWXOdl:,...........',:ldOXWMMMMMMMMMMMM
MMMMMMMMMW0dc'............... ......':d0WMMMMMMMMM
MMMMMMWXx:......  ..  ............... ..:xXMMMMMMM
MMMMMXd,.... .............................,dXMMMMM
MMMWk;......,'.......   .............,'.....;kWMMM
MMXo....  ,kXKOxc,..',;;:::;,'..'cdOKXO;......oXMM
MXl.......cXMMMMWX0KXNNWWWWWNXKKXWMMMMNl.......lXM
Xl..... ..:KMMMMMMMMMMMMMMMMMMMMMMMMMMXc...... .lX
x.........lXMMMMMMMMMMMMMMMMMMMMMMMMMMNo.........x
;........oNMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd........;
........:KMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMXc........
.. .....lNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWo........
........cXMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNl........
.... ...,0MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMK;. ......
'........lXMMMMMMMMMMMMMMMMMMMMMMMMMMMMNo........'
l.........cKWMMMMMMMMMMMMMMMMMMMMMMMMWKl.........l
0;. .......'lOXWMMMMMMMMMMMMMMMMMMWXOo,... .. ..;0
Wk'...;xko'...,:ldkKWMMMMMMMMMXkdoc,.... ......,kW
MWk,...,dXKc......;0WMMMMMMMMMK:...... .......,kWM
MMW0c....lXNOoc:co0WMMMMMMMMMMWx.............c0WMM
MMMMNx,...:OXWWWWWWMMMMMMMMMMMMk'..........,xNMMMM
MMMMMMXd;...,:cccl0MMMMMMMMMMMMk'........;dXMMMMMM
MMMMMMMMNOl,......xMMMMMMMMMMMMk'.....,lkNMMMMMMMM
MMMMMMMMMMWXOdc,.,OMMMMMMMMMMMMO;.,:dOXWMMMMMMMMMM
MMMMMMMMMMMMMMWXO0NMMMMMMMMMMMMN0OKWMMMMMMMMMMMMMM
*/