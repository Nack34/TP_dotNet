namespace Aseguradora.Aplicacion;

public class Siniestro { 
    public int ID {get; set;} = -1; 
    public int PolizaId {get;set;}
    public string DireccionDelHecho {get; set;} = "No tiene direccion";
    public string DescripciónDelAccidente {get; set;} = "No tiene descripcion";
    public DateTime FechaDeingreso {get;set;}
    public DateTime FechaDeOcurrencia {get;set;}

   public Siniestro(){}
    public Siniestro(int polizaId, String direccion, String email,String direccionDelHecho, String descripciónDelAccidente, 
                    DateTime fechaDeingreso, DateTime fechaDeOcurrencia){
        PolizaId=polizaId;
        DireccionDelHecho=direccionDelHecho;
        DescripciónDelAccidente = descripciónDelAccidente;
        FechaDeingreso=DateTime.Now;
        FechaDeOcurrencia=fechaDeOcurrencia;
    }

    public override String ToString(){
        return $"ID: {ID}, PolizaId: {PolizaId}, DireccionDelHecho: {DireccionDelHecho}, DescripciónDelAccidente: {DescripciónDelAccidente}, "+
        $"FechaDeingreso: {FechaDeingreso}, FechaDeOcurrencia: {FechaDeOcurrencia}";
    }

}
/* 
OOOkkkkkkxddoloooollloollllooollooooodddddddxxxxxxxxxkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOO00000000000KKK00KKKKKK000K00KKKKKKK0KK0O00O0OOOOOOOkkOOOOOOOOOOOOOOOOOOOOOOOkkxxkkkkOkOOOkkkkkkkkkkkkkOOOkdllc:,,,
OkkOOOOkxdddollllllloollllloollloooodddddddddxxxxxxxkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOO0000000000000000000000000000KK00KKKKKKK000OOOOOOOOOkkkkOOOOOOOOOOkOOOOOOOOkkkkkkkkkOkOOOOkkkkkkkkOOOOOOOOOOO0Oxc,,
kkkkkOOkxxdolccccccloollooooooooolloooodddddddxxxxxxxkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOOO00000OO000000000000000000000000000000OOOkOOOOOOOkkkkkkOOOOOOOOOOOOOOOOOOkkkkkkkOOkOOOOkkxkOOOOOOOOOOOkOOOOOOo:,
kkxddxxxxdolcccccccclooloooollllllllooooddddddddxxxxxxkkkkkkkkkkkkkkkkkOOOOOOOkOOOkOOOOOOOOOOOOOOOOOOO0000000OOOO000000000K0000OOOOOOOOkkkkkkkOOOOOOOOOOOOOOOOOOOOkkkkkkkkkkkkkkxxkO0OkOOOOOOkkkOkkkxdc,
xdoooddxddollcccccccclllooolllllllllooodddddddddxxxxxxxkkkxkkkkkkkkkkkkkkkkkkOkkkkkkkkOOOOOOOOOOOOOOOOOOOOOOO00000KK00K00000OOOOOOOOOOOkkkkkkkOOOOOOOOOOOOOOOOOOOkkkkkkkxkkkkkOOkxkOOOOOOOOOOkkkkxdxxdl,
oc::clodoooolllcccclllllloollllllllloooddooodddddxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOOOOkkkkOOOOOOOOOOO0000000000000000OOOOOOOOOkkkkkOkkkkkkkkkkkkkkkkkkOOOOOkkxxxxxxxxkkkOOkkxkkOOOOOOOkkkkdoloddo;
l:,';:loooollllllccllllllollllllllllooooooddddddddxdddxxxxkkkxkkkxxxxkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO00OOOOOOOOOOOOkOOkkkkkkkkkkkkkkkkkkkkkkkkkOOOkkkkkkxxxxxxkOkkxxxxkkkkO0Okkkxxdlcclol;
l;,'';coooollooolcclllllllllllllllllloooodddddddddxdddxxxxxxxkkkkkkkkkkkkkkkkkkxkkkkkkkkkkkkkkkkkOOOOkkOOOOkkOOOOOOOOOOOOOOOOOOOkkkkkkkkkkkkkkkkkkkkxxkkkkkkkkkkkkkkkxxxxxdddxkxddddkkkkkOOkxdddddlcloc,
c;,'';cloollooolllclllcllllllllllllllllooodddddddddddddddxxxxxxxxxxxxxxkkkkkkkkxxkxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOkkkOOOkOOOOOkkkkkkkkkkkkkkkkkkkkkxxxxkkkkkkkkkkxxxxxxxxdddddxkdddxkkkkkkkxdoooddolooc,
c;,,,;cllcllooolllccccccllllllllllcllllooooooddddddddddddddxxxxxxxxxxxxxxxkkkkxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOkkkkkkkkkkxxxxkkkkkkkkkkOOOOOkkkxxxxxxxxxxxxxdddxxxxxkOkkOOkdoloodxdddoc,
c:;,;:clccllooooolc:ccccccccllcllccclllloooooooooodddddddddxxxxxxxxxxxxxxxkxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkOOOkkOOOOOOOOOOkkOkkkkkkkkkkkkkkkxkkkkkkkkkkkkkkkOOOkkxxxxxxxxxxxxddddxkkxkOkxkkxdoooddxxxdl:'
c::;:clcccloooloolccccccccccccclcccllllooooooooodddddoooodddxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkOOOkOOOOOOOOkkkkkkkkkkkkkkkkkkkxxkkkkkkkkkkkkkOkkkkkOkkkkkxxxxxxxxdddxxdxxxkkxkOkkkxdooooodxxxdl;'
lc::cllccccllllolccccccccccccccccccllllooooooooooooooodoooddddddxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkOOOkkOOOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkxkkkkkkkkkkkkkkOkkkOOOOOkkxxxxxxxxxdxdddxxkkkkkkkkOxdlccclooddxdl,'
ccccllcc:::clooolcclccccccccccccccllllooooooooollllloooooooddddddxxxdddxxxxxxkxxxxkkkkkkkkkkkOkkOOOkkkOOOOOOOOkkkkkkkkkkkkkkkkkkkkkkxxxkkkkkkkkkkkkkkkkkkOOkkkxxkkxxdxxxxxxxddxkkxkOkkkxoc:;:ccllodxdl,'
cccllcc::::coddolccc:::ccccccccccllllllloooooooooooooooooooddddddddxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkOOOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxkkkkkkkkkkkkkkkkkkkxkxxxxxxxxxxxxdxkkkxkOOkxoc;;,;::clodxdc,'
ccclcc:;;;;:lddolccc::cccccccccccllllllooooooooooooodddddddddxddddddxxxxxxxxxxxxxxxxxkkkkkkkOOkkkkkkkkkOOOOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxxxxxxxxxxxkkkOOkxl::;;;:cclodxdc,'
ccclc:;;,,,,:clollllccclcccccccccllllllooddoddooooddddddddddddxxxxxxxddxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkOOOOOOOOOOOO00OOOOOOOOOOkOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxkkkkxxkkkkkkkkOOxolcc::cllodxxo:,'
ccccc:;,,''';clllolllccllcccccccccllllloodddddddooddddddddddddddxxxxxxxxxxxxxxxxxxxkkkxxkkkkkkkkkkkkkkkOOOOO00000000O00000OOOOOOOOkkkkkkkkkkkkkkkkkkkkkkkOOOkkkkkkxxkkkkkkkkkkkkkkkkOOxdollccloddxxxo:,,
cccc::;,,,,;:clclllllcllllllccccccllllooodddddddddddddxxxxxdxxxxxxxxxxkkkkkkkkxxxkkkkkkkxkkkkkkkkkkkkkkOOOOOOOOOOO000000000OOOOOOOOkkkkkkkkkkkkkkkkkOOOkOOOOOOOkkkxkkkkkkkkkkkkkkkkOOkxdoollloddxxxxo:,,
lccccc:;;,,;;::ccloocclllllcccllllllllooooodddddddddddxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkxkkkkkkkkkkkkkOOOOOOOOOOOOO000000OOOOOOOOOkkkOOkkkkkkkkkOOkkOOOOOOOOOkkkkkkkkkkkkkkkkkkOOkkkkxddoollodxxxxxdl:,,
llllllc::;,,;:clloolccllllllllcccllllloollooddxxxxxxxxxkkxxxxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOO00000OOOOOOOOOOOOOkkkkOOOOOOOOOOOOOOOOOOOOOkkkkkkkkkkkOkOOOkkkOkkxxddollodxxxxxxdl:;;
llllllllc:;;;;cllllllllllllllllclllllllooooodddxxxxxxxkkkkkkkxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOO0OOO00OOOOOOOOOkkkkOOOOOOOOOOOOOOOOOOkkkkkOOOOOOOkkkOOOOOOOkkkkkkkxdoloxkxxxxxxdl:;;
oollllolllc:;;ccccloollllllllllllllllllloloooddxxxxxxkkkkkkkkkkkkkkkkkxkkOOOkkkkkkkkkxxkkkxxkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOkkkkkkkOOOOOOOOkkOOOOOOOOOOkkkOkdooxkOkxdxxxdl:;;
ooollllcloolc:ccclllllllllllllllllllloooooooddxxxxxkkkkkkkkkkkkkkkkkkkkkkkOOkkkkOkkkxxxxxxxxxxxxxxxxxxkkkkkkkkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOkkkkkkkkkOOOOOkkOOOkkOOOOOOOOOkkkOOOkxxkOOkkxxxxoc::;
ooollcc:clodollclolcclllllllllloolooooooooooodddxxxxxxxkkkkkkkkkkkkkkkkkkkkOOkkkkkkkxxxkxxxxxxxxxxxxxxxxxxkkkkkkkkkkOOOOOOOOOOOOkOOOOOOOOOOOOOkkkkkxxxkkkOOOOOOOkkkOOOkOkkkOOOOOOkkkOOOkkkOOOOOkkkxoc:::
oooollllloddddoooolclllllllllllooooolooooooooooddxxxxxxkkkxkkkkkkkkkkkkkkkkkkkkkkxxxxxxxxxxxxxxxddxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkOkkOOOkOOkkkkkxxdxxxkkkOOOOkkkkkkOOOOOkkkOOOOOOOkkkkkkxkkO000OOkdlc:::
ooddoooodddxdoooolclllllllllllloooooloooooooollloodxxdxxxxxxxkkkkkkkkkkxxxxxkkkxxxxxxxxxxxxxxxdddddddddxxxxxxxxxxxxxxxxxkkkkkkkkkkkkxkkkkkkxxxxddoodddddddxxxddddxkOOOOOkOOOOOOOOOOOkxxxdxkOOO00Oxocc:::
oodddoodxxxdolloollllolllollllloolllllloolccccllclllloddxxddxxxxxxxxxxxxxxxxxxxxxxxxxxdddxxdddddddddddddddddddxxxxxxxxxxxxxxxxxkkkxxxxxxxddoollcccccccccclooollldddxkkOkkOOOOOOOOOOOkxxxxxkkOOOOkdlcc:::
oooddddddddolccllllllloollllllllllccccc:;;,;:::;;;:::cloodooddddxddddddddddddddddddddddddddddddddoooooddddddddddddddddddxxxxxxxxxxxxdddddolc:;,,;;;;,;:ccc:::cclooodxkkkkkkkOOOOOOOkkkkkkkkkkOOkxdcc::::
ooodddoodoollcccccllllooollllllolc::;,''.',''.....'',,;:ccclllloooooddddoooooooodoooooooddddddoooooooooooooooddddddddddddddddddddddoooll:::;,'''''',,;;;;,;;;:cccclodxkkkkOOOOOOOOkkkkkkkkxxkkkkxoccc:::
ooooddooooooooolcclllllllllollllc::;,,,'..........''....'',,;;:ccclllooooollollllllloooooooooooooooooloooollloooooooooooooooodooollc:;,,''...........'.'',,;:::::cloddxxkkkOOOOOOOkkxxxxxxxxxkxxdlccc:::
ooooddoolllllooolccllllllllllllc:;;,,,,,''.................''''',;;::ccclllllllllllllllllllllooooollllllllllclllllloooooollllllc:;,'.....................'',,;::cclddxxxkkkkOOOOOkkkxxxxxxxxkkxdlccccccc
looodddolllllllcccclolllllllllcc:;,,,,'''''.......................''',;:::::c:::cccccccccccllllllolllllllllccccccccccccccc::;;,'..........................',;;:cloddxxxkkkkOOOkkkkkxxxxxxxkkkxdocccccccc
loooddddolllllcc::clllcllllllcc::;;;,,,'''.............     ...........''',,;;;;::::::::::::cccllollllllccc::::::::::::;;,'............. ......'',...','.'',;:clodddxxxkkkOOkkkxkkxxkkkxxxxxxdoccccccccc
looooddddolllllcc:cllllllllllccc::;;;,,''......   ...         ...............''',,,;;;;;;;;;::cclllcccccc::;;;;;;;;;,,''......           ..,;::::::;:clcccccloooddxxxkkkkkOkkxxxxxxkkOkkxxxdollccccccccc
lloooddddddllccccccclllllllllllc:::;;;,,'.....  .......         ..''.....  .........'''''',,;;;::cccccccc:;,,,,''''......    ....   ....',:lloollcclloodxxxxddddxxxxxkkkkkkkkxddxxxkkkkxdoollccccccccccc
llooodddddxdolcccccccclllllllllllcc::;;,''''.........'.........',,,,'....    ............'',;;;::ccccccc::;,''......         ......'',;:ccloollccllcldxxkkkkxxxxxxkkkkkkkkkkxxxxxxxxxxdollllccccccccllll
lllooooddddxxdocccccccllllllllooollcc:::;;::;;,''''..'''','',,;;,,''......      ........',,,;;::ccclllllcc::;,..................',;;::cccccccccc:clodxxkkkkxxxxkkkkkkkkkkkOkxxxxxxxdollllllcccccccllllll
ccllloooddddddddolccccclllooollooooolccccccccc:;;;,''''...''''','''.....................,;;:cclloooddddddoolc;'.........''''''''',,;;;;;::;;;:cclodxxxxkkkkkxxkxkkkkkkkkkOOkkxxxkxdolllllllcccccccllllll
:::cclllooooddddddddolcclloooooooddooollcccclllcc:::;'....'''.''''''''''',,,''''......'',;:cloodxxxxxxxxxddool:,,,',,,,,,,;;;;;::::::ccccccclooooddxxxkkkxxxxxxkkkkkkkkkkOOOkkxkkxdollllccccccccccllllll
,;;;::cccllloodddddxdlcclloolooddoddddooollllllccc:c:::::::;;;;;::;;;;;;,,,,,,,,,,,'',',;:cloddxxxkkkkkkxxxxdolc::::cc:;;;;;;;:::ccclooooooooddddddxxxxxddxxkkkkkkkkkkkxxkOOOOkkkxdllllcccccccccccllllll
''',,;;;::cccllooodddocclllllooooooddxddoolccllllcc::ccccccccccccc:::;;;;;;;;;;:;;;;,,,,;:clodxxxkkkkkkkkkxxxdollllllolllcc::::::::cllloooooooodddddddxxkkkkOOOkOOkkkOkxxkOOOOkkkxdllllcccccccccccccclll
.....'',,;;;::cclloooolclllooooodddddxxdxxdoollcllllcc::::::::::::::::::::::ccc:::::;;,;:cloddxxkkkOOkkkkkkkxxdooooooooooooolcc:::::ccccllllllllooddxxkkOOkkkOOOkOOOOOkkxkkkOOOkkxollllcccccccccccccccll
.........''',;;::cclllccllllollooooooddddddxdoolc::::::::::::::::::ccccccccccccc::::;;;;:cloddxxkkOOOOOOkkkkkxdddooooooooodddooolllllcccccllooodxxkkkkkkOOOOOOOOOOOOOOOOOOOOOOOOkxdllllccccccccccccccccc
.............'',,;;::cccllllllllooooddddddxxxxxxdddolllcc:::::cccccllllllccllccc:::::;;:clloddxkOkkOOOOOOkkkkkxxxdooooodoooododddooooooodddxxkkkkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOkkkxollllcccc:::::::cccccc
.................'',;;;:looooooooddoddddxxxxkkkxxxxxxxddddoooooodooolllllcccccc::::::;::cllodxkkkkOOOOOOOOOkkkxxxxddodddooooooodddddddddxxxxxkkOOOOO0OOOOOOOOOOOOOkOOOOOOOOOOOkkkxollcccccc:::::::::cccc
.....................',;cooooooooooddddxxxxxkkkkxxxxxxxxxxxxxxddddddoolllllcccc::::::::cclloodxkkkOOOOOOOkkkkkkkxxxdddddddddddddddddddddxxxxkkkkOOO000OOOOOkkOOOOOOOOOOOOOOOOOkkkxolcccccc:::::::::::::c
.......................,coooooooooodddddxxxxxxxkxxxxxxxxkxxxxxxdddddddoooollllccc:::::ccccloodxkkkOOOOOkkkkkkkkkkkxxxdddxxxxxxxxxxdddddxxxxkkkkkOOOO00OOOOOkkOOOOOOOkOOOOOOOkkkkkxdllccccc::::::::::::::
.......................'clooooooooddddddxxxxxxxxxxxxkkxxxxxxxxxxxdxxxddddooolllccccc:cccclloddxkkkkOOOkkkkkkkkkkkkkxxxxxxxxxxxxxxkxxxxxxxxkkkkkkOOOOOOOOkkOOOkOOOO0OOOOOOOOOOkkkkxxxolccccc:::::::::::::
.......................':loooooooddddddxxxxxxxkkkkkkkkkxkkxxxxxxxxxxxxddddoollllcccccclllllodxxkkkOOOOOkkkkkkkkkOkkkkkkxxxxkkxxxkkkkxxxxkkkkkkOOOkOOOOkkkkkOkkkOOOOOO000OOOOkkkkxxO0kdlccccc::::::::::::
........................:loooooooddddddxxxxxxxxxxxxkkkkxxxxxxxxkkkkkxxdxxddoollcclllcllloooodxxxkkOOOOOOOOkkkkOOkkkkkxdddodddxxxxxxxxxkkkkkkkkkkOOkkkkkkkkkkkkxkkkOOOO000OOOkkkxxk0KKkolccccc:::::::::::
.......................'cloooooodddddddddddddddxxxxxxxkkkkkkkkkxxxkxxxddddoolc:::::clllooooddddxxkOOOOOOOkkkkkkkkkxxdollcccllloooddxxxxxxxkkkkkkkkkkkkkkkxxxkkxkkkkOOOOOOOOkkxxxxx0XXKkoccccc:::::::::::
.......................'cooooooodddddddddddddddxxxxxxxxxxxxxkkxxxxxxxxdoolcc:;,,,;;:clooddddddxxxkkOOOOOOOkkkkkkxxdooooolc::;;::cllooddddddxxxxxxxxxxxxxxxxxdxxxxxkkkOOkkkkkxxxxxxOXXXKkoccccc::::::::::
.......................'cllloooooooodddddddddddddddxxxxxxxxxxxxxxxdooolcc:,,'',;::;;:clodddddxxxkkOO00OOOkkkkkkkxxdodddddoc:;;;,;;:cclllooooddddddddddddddxddodddddxxxkkxxxxxxdddxOXNNX0xlcccc::::::::::
.......................'clllllooooooooddodddddoodddddddxxddddddoooollc:;,'''.';clccc::coddddxxkkkOOO00OOOkkkkkkkxxddxxxxxdoc::;;,,,,;::ccllooooooooooooodooddoooddddddxxxddddddddxOXNNNX0dlccc::::::::::
........................cllllllooooooooooooooooooooooodooooooollllc:;,''''''';loddoolccloddxxxkkOOOOOOOOOOOOOOOkkxxxkkkkkxdolccc:;,'',,;;:cclllloooollloooooodddoodddddddddddddddxOKXNNNXOoc:c::::::::::
........................:lllllllllllooololllloolllllloollllllcc:::;,,',,,;;,;lddxxxdollooddxxkkkOOOOOOOOOOOOOOOkkkkkkkOOOkkdolool:;,,''',,;:::ccccclllllllllooollllllooooooodddddxOXNNNNNKkl::::::::::::
........................,cloolllllllllllccllllcclccllllccccc::;;;,,,,;;:;;;;coddxxxxdoooooodxxxkOOOO0OOOOOOOOOOOOkkkkOOOkkxdoodollcc:;,'''',,;;;;:::::cccccccccccccccllllloooddddk0XNNNWNNKxc;;;::::::::
........................'cllllllcccccccc::cccccccccccc::ccc:;;,,,,;:::;;;;;;loddxxxxxdddddddxxxxkOOOOOOOOOOOOOOOOOkkOOOOkkxdoooololccc:;,'...''',,,;;;;;;::::::::::::::ccllloddddkKXNNNWWNX0d:,,;;::::;;
.........................:llllccc::::::::::::;::::::::::;;;;,,,,,;:::::;;;;;:loddxxxddddddddxxkkkkOOOOOOOOOOOOOOOOkkkkkkkkxoloooooolllc:;,'..........'''',,,;;;;;;;;;;::clllloddxOKXNNNWWNNX0d;'',;;;;;;
.........................,cllccc:::;;;;;;;;;;;;;;;;;;;;;,,'''',,;;;;;;::::;,,:lodddddddddddddxxkkkkOOOOOOOOOOOOOOOkkkkkkxdlloooooodoollcc::;,,''............'',,,;;::::cclllloddk0KXNNNWWNNNXOo,.'',;;;;
..........................;ccc:::;;;;;;,,,,,,,,,,,,,,,''''''',,,,;;;;;;;:;;;,,,:clddoooddxdxxxxxkkkkkkOOOOOOOkOOOOkkkkxdoclloooooodooollllllc:::;,,'..........',;;:cccclllllooddk0XNNNNWWWWNNKkc...'',;;
..........................':cc::;;;;;;,,,,,''''''''.....'',,,,;;:::::;;;;;;;;;,,;:cllllodddxxxxkkkkkOOOOOkkkkkkkkkkxddolcllooooddddooolodoollccc:,'..........',;::ccccccllllooodk0XNNNNNWWNWNXKd,...'',,
...................... ....;c::;;;,,;,,,''''''..........'',,,,;;::::::;;,;;;;;;;;,,;:ccllooddxxxxxkkkkkkkkkkkkkkxxdollclllooooodddddoolooolllc:;'...........',;::ccccccllllloolokKXNNNNNWWNNNNXOc.....''
....................      ..;::;;,,,;;,,,,'''..............',,;;;;::;;;;;;;:;;;;;;,'',;;:cllodddxxxxxxxkkxxxxxkxdolccloooddoooddooooollllcc::,'..',,'',,;;,,;;:ccccccccllcllllloOKNNNNNNWWNNNNX0d'......
....................       .':::;;,,;;,,,,;;;,'''............'',,;;;;;;::::::;::::;;,,'',;:clloooddddddxdddxxxdolcccloooooooldddoollllllc:;,'',;;;;;;;;::;:::cccccccccccccllllodOXNNNNNNWNNNNNXKx;......
.....................      ..,::;;;,;;,;;;;:::;;;,'''''''........',,;;;;;;:::::::::;;,,''',;::cclllllloooooddolcccclllooooooooooolllccc:,''';:c::::;;::::::ccccccccccccccccooodx0XNNNNNNWNNNNNNKk:......
..............................;:;;;;,,,,,;;::c:::;,'''''''''........',,,;;;;:::::::;;;,,,''',,;;::::::::ccclllc:ccloolooodooooolccc:;,'.',;cllccccc;;::::ccccccccccccccccclddddOKXNNNNNNWNNNNNNXOc......
..............................',;;;;,;;,,;;::cccc:;,,,,,,,,,,,'...  ...',,;;;;::::::;;;;;,''.'',,,'',,,,;;;:::ccloodddoodooollc::;'....,:coolllllcc::::cccccccc:::::::::cloxddx0XXNNNNNNNNNNNNNXOl......
...............................';;;,,,,,,;;;:cccc::;,,,,,;;,,,,,.....  ...'',,,;;;::;;::;;,,,'''....'',,;;::cclloodoolllcc::;,,,'....,;clooollllcccccc::cccc::;::::::::cloddddkKXNNNNNNNNNNNNNNX0o'.....
................................',,,,,,,,,;;;:cc::::;,,,,,;;,,,;;,'...........''''',,,,,,,,,,,,,',,,;;;:::cccccc:c:::;;,,,,,,,,,''',;:cloollllclllllcc:::::::;;::::::ccloddoox0XNNNNNNNNNNNNNNNX0o'.....
.................................,:;,,,,,,,,;;::::::;;;,,;;;;;;;;;;,''...........''.....'''''''''',,,,;;;;;;;;,,,,,',,,,,;,'',,',;:cllllllllllllllllcc:::::::::::::ccccldddlokKXNNNNNNNNNNNNNNNX0o'.....
.................................lxo:,,,'',,,;;;::c::;;;;;;;;;;,,,,,,,,'.......'.....'''........''',,,,,,,,,'''',,,;:cccccc:,,;:cloolcclllllllllllllccc:::::::;;;:::cclodolldOKXNNNNNNNNNNNNNNNX0o'.....
................................'oO0kl;,''',,,,;;:::::;;;;;;;;;;,,,,,,;;,''...'....'',,,,'''''''''''''..'',,,;::cc::cooc:ccccclloooolllloollllllclllccccc:::::;;::::clooolcokKXNNNNNNNNNNNNNNNNXOl......
................................;dOKKOo:,'''''',;;::::::;;;;;;;;;,,,,,,,,,,,,,''...'',;:;,,;;;;;,,;,,...,:ccllllll:,,;,;:lodooooooollllllolllllllllllllcccc:::;::cccloolcccdOKXNNNNNNNNNNNNNNNXKOc......
................................:k0KK0ko:,'''''',,;;:::::;;;;;;;;;;,,;,,,,,;;;;;;;,,'''''.',;;:::;::;'.',:cccc::ccc::cldxkxddddooolloooollllllllllllllccccc:::::ccclollc::okKXNNNNNNNNNNNNNNNNXKk;......
................................lO0KK0Odc,'''''''',;:::::;;;;;;;;;;,,,;;,,,,;;::ccc::;;;;;;,,,,;;;;;;,,,,,;:::clodxkkkOOOkkxdoooolllllllllllllloollllllllcc::::ccclllcc::lk0XXNNNNNNNNNNNNNNNNX0d,......
...............................,dOKKK0Oxl'...'''''',;;;;;;;;;;;;;;;,,,;;;,,,,;::cclllllllllllllllccccclllooooddxxxxxxxxxxxdoooolllollllllllllooooolllllllc:::::ccllccc;;cx0XXNNNNNNNNNNNNNNNNXKOl.......
...............................cx0KKK0Okl,. ...''''',,;::::;;;;;;;,,,,,,;;;;;;;;:cccccllllllooddddddddddxdddddddoodddxxddoollllllllllllllllooooooolllllcc:::::cccccc:;,cx0KXNNNNNNNNNNNNNNNNNXKx;.......
.......     ..................,oO0KKK00ko;.   ..''''',;;;;::;;;;;;;,,,,,,,;;;;;;;;::ccccllllooddddooddoodoooddddooooddolllllllllllccllloooddddddoollllcc:::::ccccc::,,:d0KXNNNXNNNNNNNNNNNNNXX0o'.......
.....       ..................:x0KKKK00kdc.     ..'''',,;;::::;;;;;;;;,,,,,,,;;;;;;::::::cccccllllllllclllllllllllcclllllcllllllccllllloddddddddooolcc::;;::ccccc:;,,:d0KXXNNNNNNNNNNNNNNNNNXKkc........
....       ..................,oO0KKKK00Okl,.     ...'''',,;;;:;;:::;;;;,,,,,,,,,,,;;::;;;;:::::::cclllccllcccccccccccclllccc:::clllooodddxxddooollllc::;:::::::::;,,cx0XXXNNNNNNNNNNNNNNNNNXX0d,........
..       ....................:x0KKKKKK00kd:.       ...'''',,;;;:::::;;;;;;;,''''',,,,;;;;;:::::ccccccccccccccc:::::::::;;;:::ccclloooddxdxxdddoolllc:;;;:::::::;;,,cx0KXNNNNNNNNNNNNNNNNNNNXKkc.........
         ...................'okKKKKKKK00Oxl,.        ....''',;;::::::;;;;;;;,,,'''''''',,,,;;;;;;;;;;;;;;;;;;,,,,,,,,,,;;::cllloooooddxxxxxddooollc:;;::::::::;,',cx0KXXNNNNNNNNNNNNNNNNXNXX0d,.........
        ....................:x0KXKKKKKK0Okd:.          ....'',;;;::cc::::::;;,,,,,''''''''''''''''''''''',,''''',,,;;;:::clloodddxxxxxxxxdddooollc:;:::::::::;,',cx0KXXNNNNNNNNNNNNNNNNXXXXKOl..........
      ........    .........'lk0KKKKKKKK00Oxc'.          .....',,;;::cc:cccc::::;;;;,,,,,,'''''''''''''',,,,,,;;::::::ccllloodxxxxxkxxxxddddoooll:;;;:::::::;;'',ck0XXXNNXNNNNNNNNNNNNNXXXXK0x;..........
     .......     ..........:x0KKKKKKKKKK0Oko;.         .......'',;;:::cccccccccccccc:::::;,;;;;;;;;;;;;::::::clllloooodxddxxxkkxxxxxxxxxddoollc:;,;;:::::;;,'',lkKKXXNNNNNNNNNNNNNNNXXXXXXKkl...........
     .....    ............'oOKKKXKKKKKKK00Odc'.         .......'',,;;::ccccclllllloollollllllllllllooooooooddddxxxxxxxxxxxkkkkxxxxxxxxdddoollc;,,;;:::::;;,'.,okKXXXNNXNNNNNNNNNNNNNXXXXXK0x:...........
   .....       ...........:x0KXXXXXKKKKKK00ko;.          .......''',;;::ccllllloooooooooooooooooooddddxddddxxxxxxxxxxxxxxxxxxxxxxxxddddooolc:;,;;;;::::;;,'';oOKXXXNNNNNNNNNNNNNNNNNXXXXXKOo'...........
  ....          .........'oOKKKXXXXXKKKKKK0Odc'.         ........''',;;::ccclllllloooooolloooooddddddddddddddxxxxxxxddxxxddxxxxxddddddoollc;,,;;:::;;;;,,'':dOKXXXNNNNNNNNNNNNNNNXNXXXXXX0kc..  ....',;:
   ...         ..........:x0KXXXXXXXKKKKKK0Oko;.        ..........'''',;;::ccccclllllllllllooooddddddddddddddddddddddddddddddddddddoolllc:;,;;;:::;;;,,'.':x0KXXNNNNNNNNNNNNNNNXXXNXXXXXKOd,....',:cllll
              ..........'oOKXXXXXXXXKKKKKKK0Oxl,.       ...........''.'',,;:::::ccccccccccclllllooooooooooodoooooollooooooooooooollllc::;,,;;;;;;;;,,'..,cx0KXXNNNNNNNNNNNNNNNNXXXNXXXXX0kl,,;:cllllllll
            .........  .:k0KXXXXXXXXKKKKKKKK0Oxc'.     ................''',,;;;;;::::::::::cccllllllllllllllllllclllllllllllllccccc::;,,,,,;;;;;;,,''..;lkKXXXNNNNNNNNXNNNNNXXXXXXNNXKOdlcclllllllllllll
            ....... . .,dOKKXXXXXXXXXKKKKKKKK0kd:.     ................'''''',,,,,;;;;;;;;;;:::cc:ccccc:::::cccccccccccclccc:::::;;,,,,,,,,;;;;;,,''.':dOKXXXNNNNNNNNNNNNNNXXXXXX0kdl:;,';clllllllllllll
               .      .ck0KXKXXXXXKKKKKKKKKKK0Okl,.   ..................'''''''',,,,,,,,,,,;;;;;;;;;;;;;,,;;;;;:::::::::::::;;;,,''',,,,,,,,,,,,'''.'cx0KXXXNNNNNNNNNNNNNNNXKOxoc;,,,,,,,;clllllloxkxoll
                     .;x0KKK00OkkkxxxxkkkkkOOOOkdc'.  ...................''''.''''''',,,,,,,,,,,,,,,,,,,'',,,,,,,,,,;;;,,,,,,'''''''',,,,,,,,,'''..,lk0KXXXXNNNNNNNNNNNX0kdl:;,,,,,,,,,,,;cllllllkNWNX0k
                    .'okOOxol:;,''.........';coddo:'. ...................'''''''''....''''''''''''''............''''''''''''',,,,,,,,,,,,,,,'''...;oOKXXXXXNNNNNXNXKOxoc;,,,,,,,,,,,,,,,,;cllllllOWMMMMW
                    .:odoc,.............     .,codo:'....................'''''''''.......''''...................''''',,,,,,,,,,,,,,,,,,,,,,'''..':d0KXXXXXXNNNX0kdl:;,,,,,,,,,,,,,,,,,,,,;cllllllkWMMMMM
                   ..;::,'...............    ..;lxkdc'....................''''''''''....'''''''...............''',,,,,,,,,,,,,,,,,,,,,,,,,''...'cx0KXXXXNXK0koc;,,,,,,,,,,,,,,,,,,,,,,,,,;clc::;;xWMMMMM
      .;:.          .',,,'.................. .';cdkko;...................,oc'''''''''''''.'''''............'''',,,,,,,,,,;;;;,,,,,,,,,,,''''...:x0KXXXXXKxc;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;:;,,,,,xWMMMMN
*/