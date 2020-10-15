# Áttekintés

A program indításakor "whosAlap" koncepció néven elérhető menü található ahol a felhasznál eldöntheti, hogy melyik profiljával szeretne belépni a programba.  Itt összesen létre tud hozni 5 db felhasználót akiket az adatbázisba fogunk tárolni.

Miután beléptünk a programba "mainAlap" koncepció képernyő ahol a képernyő fejlécében tudunk navigálni a nagy listák között. 

Ha rákattintunk a **Home gombra** akkor ez a alap képernyőt fogja betölteni.

Ha rákattintunk a **TV Shows gombra** csak azokat a elemeket fogja listázni a sávokba amik a sorozat kategóriába tartoznak. 

Ha rákattintunk a **Movies gombra** csak azokat a elemeket fogja listázni a sávokba amik a filmek kategóriába tartoznak. 

Ha rákattintunk a **My List gombra** csak azokat a elemeket fogja listázni a sávokba amiket mi bejelöltük hogy megszeretnénk nézni az adott művet.

Az első sávban a **Continue**  már elkezdett alkotásokat fogja listázni amit az adatbázisból fogunk megkapni a második sávban a legfrissebben "My List"-be rakott filmeket/sorozattokat fogja betölteni. Ha egy alkotás elvan kezdve és MyList-be van rakva akkor a automatikusan a **Continue** sávba kerül. Ezek a sávok alatt már csak műfajilag szeretnénk felbontani az alkotásokat véletlenszerűen. Egy sáv 24 darab alkotás helyezkedhet el.

Az **"Update" gomb** azt fogja jelezni, hogy az adatbázisba került új elem és ha megnyomjuk kiírja a címét és a megjelenési dátumát. 

A **"Profil" gomb** megnyomásával vissza kerülünk a menü-be.

## mainOpen Leírás

Ha rányomunk az egyik filmre akkor betölti a hozzá tartozó "adatlapot". Ilyenkor kiíródik az alkotás címe, megjelenési idejének az éve, rendezője neve, 3 legfontosabb színész neve, a hossza percbe, az "életkori" ajánlás, az IMDB pontszáma, play gombbal tudjuk elindítani a média lejátszót, "Watch-list" gomb amivel betudjuk rakni a My List listába és a "Watched" gomb amivel megtudjuk jelölni, hogy láttuk a filmet.

## Player Leírás:

A célunk legfőképpen egy olyan média lejátszót létrehozni ami egy adatbázisból betölti az adott médiaanyagot és kilépéskor annak az aktuális állapotát eltudja menteni ezek mellett küllemileg próbáltuk a ma divatos lejátszókat koppintani.

**backButton**-vissza kerülünk a főmenübe

**playButton**-elindul a média fájl

**rePlaybutton**- 5 másodperccel vissza teker

**forwardButton**- 5 másodperccel előrébb teker 

**volumeButton**-  Ilyenkor megjelenik egy csúszka amivel képesek lehetünk beállítani a média fájl hangerejét. 

**ccButton**- Egy listából kiválaszthatjuk, hogy milyen nyelven és milyen felirattal szeretnénk nézni az adott alkotást. A feliratnál van None lehetőség.

**"playerCsúszka"** - itt tudjuk beállítani azt, hogy a média fájlunk hol jár az idejében. Ha rákattintunk egy adott pontjára akkor a média fájl oda tekerődik ahol arányilag ott jár. 
