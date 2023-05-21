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
En aquesta versió hem començat a implementar les proves, afegir funcionalitats entre elles i reactivitat al joc. Hem creat fitxers per cadascuna de les proves:
- ProvaBolets: manté constancia dels bolets de la escena, genera i mostra la seqüència a realitzar i evalua si la prova s'ha superat.
- ProvaFlors: manté constancia de les flors de la escena, genera una seqüència i itera la llista per anar mostrant-les i evalua si la prova s'ha superat.
- ProvaVolcans: manté constancia dels volcans de la escena, genera una seqüència itera la llista per anar amagant-los i evalua si la prova s'ha superat.
- ProvaConjunta: TODO
- ProvaLlums: TODO

Afegit behaviour a cadascun dels prefabs que participen de les proves:
- Bolet: s'il·lumina en saltar a sobre + comprova si era el següent bolet en la seqüència a realitzar.
- Flor: creix i reprodueix un so si el player la ha "il·luminat" (el tracker passa per sobre) + comprova si era la flor que s'havia de sanar.
- Volca: es redueix fins desapareixer i reprodueix un so si el player trepitja a sobre + comprova si era el volcà correcte de la seqüència.

I un GameManager (gestionadorJoc) què té consciencia de quines proves s'han realitzat amb èxit i quines no, per tal d'obrir els camins i roques corresponents.
