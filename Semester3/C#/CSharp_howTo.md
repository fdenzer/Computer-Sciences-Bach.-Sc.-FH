             /CCc    #  # 
             C      ######
             C       #  # 
             C      ######
             \CCc    #  # 

___________________________________

# Designphilosophie

## 1. Klassen sind entweder abstract oder sealed

### Gründe

* man kann bei Bedarf nicht von non-sealed auf sealed umstellen, umgekehrt hingegenen schon

	* daher sollte sealed der Standard sein

* sealed bietet Geschwindigkeitsvorteile

	* zur Laufzeit muss in keiner vtable nachgeschlagen werden

* Die Sicherheit steigt, da keine zusätzlichen, modifizierten Klassen Attribute benutzten dürfen.

## 2. Deklarativ statt imperativ

### Ziele

* besser lesbarer Code, da der Sinn besser erkennbar wird

* oft kürzer als imperative vorgehensweise

___________________________________

# Vtable

Tabelle virtueller Methoden

Zur Compilierzeit ist die Subklasse (konkrete Ausprägung) eines Objektes nicht bekannt. Nur die Basisklasse ist zu disem Zeitpunkt bekannt.

Beim Aufruf einer Funktion zur Laufzeit wird diejenige Funktion aufgerufen, welche dem Typ der tatsächlichen Instanz entspricht.

___________________________________

# Nullable und Fehlerbehandlung

	int? i;

i kann null sein, da das Suffix "?" angehängt wurde.

## as-Keyword

Mit der Zuweisung

	int? i = k as int;

wird sichergestellt, dass keine Exception geworfen wird,
falls k inkompatibel mit dem cast nach int ist.

Dannach kann geprüft werden, ob i null enthält.

	if (i == null) {
		// beispielsweise Wert zuweisen wenn keiner Vorhanden
		i = 0;
	}

Objekte (und ***vermutlich auch*** andere Referenztypen) sind auch ohne
das Fragezeichen als Suffix auf null setzbar.

## Fehlerbehandlung mit try/catch

Die Alternative zum as-Schlüsselwort stellt ein try-catch-Block
dar, in dem ein (expliziter) cast aufgerufen wird.

	try {
		int i = (int) k;
	} catch (InvalidCastException inCaEx) {
		TextWriter errorWriter = Console.Error;
		errorWriter.WriteLine(inCaEx.Message);
		i = 0;
	}

___________________________________

# Quellen

* Vtable

	* de.wikipedia.org/w/index.php?title=Tabelle_virtueller_Methoden&stableid=99390919

Literatur

* A. Troelsen, _Pro C# 2010 and the .NET 4 Platform_, Apress, **2010**

* D. Solis, _Illustrated C#_, Apress, **2010**

	* "illustrated" bezieht sich auf die Speichernutzung