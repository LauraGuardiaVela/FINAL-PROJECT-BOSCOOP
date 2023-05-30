# BosCoop

NAMES: Carolina del Corral Farrarós, Adrià Julià Parada, Lauran Guàrdia Vela
NIAS: 217612, 242195, 240239

### Entrega 1 - 3D assets, audio, animations 
Hem construït la base de l'escenari amb diferents models de plantes, als quals els hi hem adaptat el color del material perquè coincideixi amb la nostra temàtica. Per conveniència hem fet alguns prefabs. A sobre de la base hem posat l'asset d'aigua, al qual hem modificat la seva transparència i velocitat. També hem afegit roques liles que seran cadascuna de les parts en les quals s'efectuaran les proves i l'illa final de color turquesa. A més també hem afegit els camins que hi haurà entre aquestes proves, que es poden habilitar o deshabilitar en funció de l'estat del joc. En el futur, la visibilitat de les proves i dels camins serà gestionada pel mateix joc.

Respecte als assets de cada prova, es troben a sobre de la roca corresponent. Hi ha els següents:
- Bolets
- Volcans
- Flors
- Formes
- Magranes i llavors

A més, hem afegit a l'escena les diferents músiques d'ambient i hem deixat en una carpeta *"Musica"* la resta de sons que farem servir per a les interaccions.

* Cada asset que hem agafat l'hem modificat per adaptar-lo a les nostres necessitats. *

### Entrega 2 - Initial project structure
En aquesta versió, hem començat a implementar les proves, afegir funcionalitats entre elles i reactivitat al joc. Hem creat fitxers per cadascuna de les proves:
- ProvaBolets: manté constància dels bolets de l'escena, genera i mostra la seqüència a realitzar i avalua si la prova s'ha superat.
- ProvaFlors: manté constància de les flors de l'escena, genera una seqüència i itera la llista per anar mostrant-les i avalua si la prova s'ha superat.
- ProvaVolcans: manté constància dels volcans de l'escena, genera una seqüència i itera la llista per anar amagant-los i avalua si la prova s'ha superat.
- ProvaConjunta: TODO
- ProvaLlums: TODO

Afegit behaviour a cadascun dels prefabs que participen de les proves:
- Bolet: s'il·lumina en saltar a sobre + comprova si era el següent bolet en la seqüència a realitzar.
- Flor: creix i reprodueix un so si el player l'ha "il·luminat" (el tracker passa per sobre) + comprova si era la flor que s'havia de sanar.
- Volca: es redueix fins a desaparèixer i reprodueix un so si el player trepitja a sobre + comprova si era el volcà correcte de la seqüència.

I un GameManager (gestionadorJoc) què té consciència de quines proves s'han realitzat amb èxit i quines no, per tal d'obrir els camins i roques corresponents.

Al lab vam provar els nostres canvis sense èxit, ja que tot i que l'escena es veia bé i els sons es reproduïen correctament, el sistema de tracking no funcionava i els nostres players no es podien moure per l'escena. Tot i que en un entorn d'escriptori, funciona amb les comandes per teclat. De cara al següent lab, realitzarem un conjunt de proves/test per tal de trobar l'error i poder continuar avançant.

### Entrega 3 - Intermediate advances of the project
En aquesta versió, hem revisat i millorat la funcionalitat de les proves ja existents. També, hem implementat les proves que quedaven per a fer (llums i conjunta) i completat la reactivitat del joc. D'aquesta manera, el workflow proposat inicialment (un jugador completa una prova i obre el camí de l'altre i viceversa) és totalment funcional i complet. Per tant:
- ProvaConjunta: quan el player 2 xuta les magranes, aquestes espolsen unes llavors que el player 1 ha de portar a un test per tal d'obrir el camí.
    - TODO: tenir un model per al test, ara mateix és una esfera que activa el trigger. I tenir una millor cinemàtica de la prova, ara és essencialment funcional.
- ProvaLlums: manté constància de la forma a traçar per l'usuari i s'il·lumina a mesura que aquest va superant la prova i seguint el patró indicat.

També ens hem dedicat a resoldre alguns bugs, randomitzar els algoritmes de certes proves com la dels bolets per tal d'obtenir una seqüència aleatòria a cada partida. El joc detecta si l'usuari no ha seguit el patró indicat i gestiona la desil·luminació dels bolets per a poder començar de nou la prova. El mateix concepte aplica a la prova de les llums.

La setmana passada al lab ens vàrem adonar que l'escena tenia alguns defectes visuals:
- Els camins eren massa grans i no es diferenciaven entre ells. En aquesta versió, els camins han estat millorats fent-los més estrets i reduint la component especular del material per tal que no enlluernin a l'usuari.
- La llum de l'escena no afavoria la reflectivitat de l'aigua, per això hem modificat la seva direcció per emfatitzar l'aigua.
- L'aigua no s'apreciava en tota l'escena, per això hem canviat lleugerament el seu color i propietats perquè es pugui apreciar millor.

Amb tots els canvis i novetats mencionades, deixem clar que el joc ja és 100% funcional. De tal manera, que en les següents setmanes dedicarem els nostres esforços a resoldre bugs o errors que detectem en el laboratori, millorar els algorismes de les proves i implementar cinemàtica al joc que completin l'experiència d'usuari.
