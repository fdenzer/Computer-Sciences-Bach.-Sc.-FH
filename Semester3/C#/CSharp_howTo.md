             /CCc    #  # 
             C      ######
             C       #  # 
             C      ######
             \CCc    #  # 

___________________________________

# Designphilosophie

## 1. Klassen sind entweder abstract oder sealed

### Gründe

* man kann bei Bedarf nicht von non-sealed auf `sealed` umstellen, umgekehrt hingegenen schon

	* daher sollte `sealed` der Standard sein

* `sealed` bietet Geschwindigkeitsvorteile

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

`i` kann `null` sein, da das Suffix `?` angehängt wurde.

## as-Keyword

Mit der Zuweisung

	int? i = k as int;

wird sichergestellt, dass keine `Exception` geworfen wird,
falls `k` inkompatibel mit dem cast nach `int` ist.

Dannach kann geprüft werden, ob `i null` enthält.

	if (i == null) {
		// beispielsweise Wert zuweisen wenn keiner Vorhanden
		i = 0;
	}

Objekte (und ***vermutlich auch*** andere Referenztypen) sind auch ohne
das Fragezeichen als Suffix auf null setzbar.

## Fehlerbehandlung mit try/catch

Die Alternative zum `as`-Schlüsselwort stellt ein `try`-`catch`-Block
dar, in dem ein (expliziter) cast aufgerufen wird.

	try {
		int i = (int) k;
	} catch (InvalidCastException inCaEx) {
		TextWriter errorWriter = Console.Error;
		errorWriter.WriteLine(inCaEx.Message);
		i = 0;
	}

___________________________________

# .NET-Framework

## System.DateTime

* Genauigkeit 100 ns = 1 tick

* können jeden Zeitpunkt vom 1.1.1 bis 31.12.9999 darstellen

	(nach dem gregorianischen, heute geläufigen, Kalender)

## Collections

# Dictionary

*							***ToDo***

___________________________________

# Weitere Schlüsselwörter

## partial

Wird eine Klasse oder void-Methode auf mehrere Quellcodedateien aufgeteilt so muss jede Stelle mit `partial` gekennzeichnet werden. Die einzelnen Teile werden vor dem Ausführen jedesmal automatisch zusammengefügt.

## yield

ist wichtig im Zusammenhang mit Iteratoren. An der Stelle des Aufrufs von `yield return` (z.B.) `value;` wird jeweils das nächste Element (hier value) der Aufzählung zurückgegeben.

	http://msdn.microsoft.com/en-us/library/9k7k7cf0.aspx

	Fibonacci-Folge mit yield: http://en.wikipedia.org/w/index.php?title=Comparison_of_C_Sharp_and_Java&oldid=483705520#Generator_methods

## ref

Wird ein Parameter einer Methode als `ref` gekennzeichnet, so erfolgt ein call by reference (statt dem normalen call by value, der mit einer Kopie des Wertes arbeitet). Der Typ der Variable bleibt ansonsten unverändert, d.h. ein value type wird nicht zu einem reference type gekapselt (ge*box*t).

## Abstrakten Typen

Unter anderem können Attribute und Methoden als `virtual` oder `abstract` gekennzeichnet werden. Ersteres bedeutet dabei, dass eine Implementation vorliegt, im zweiten Falle fehlt diese vollständig. Es muss aber eine Implementation geben, spätestens wenn der Mitgliedstyp geerbt wird ist diese mit --> `override` nachzutragen.

### override

Geerbte Methoden (u. andere Mitgliedstypen) können mit `override` vor der Signatur überschrieben werden. Im Fall von mit `virtual` erstellten Mitgliedern ist dies optional, `abstract` macht das Überschreiben Pflicht. 

## using

Um Resourcen nach der Verwendung wieder freizugeben kann man eine einzelne Anweisung oder einen Block (d.h. den Bereich zwischen zwei geschweiften Klammern) an eine `using`-Anweisung anhängen.
Die Resource wird in runden Klammern deklariert und initialisiert.

	using (TextWriter tw = new File.Create("Beispiel.txt")) {
		[...]
	}

	// ab hier ist tw gelöscht und dessen Resourcen sind freigegeben


___________________________________

# Extension Methods

Man schreibt in einer statischen Klasse eine statische Methode. Ein Parameter sei ein Objekt eines anderen Typs (hier MyClass). Dies lautet soweit wie folgt.

	private class MyClass {
		int k;
		public MyClass(int _k) k = _k;
	}

	public static class psc{
		public static void resetIntK(MyClass mc) {
			mc.K = 0;
		}
	}

	public static void main() {
		MyClass mc = new MyClass(5); // wir nehmen an, dass k = 5 gesetzt
		psc.resetIntK(mc);
	}

Man die wie folgt die Klasse MyClass um die Methode resetIntK erweitern: Mit dem Schlüsselwort `this` vor `MyClass mc` wird die Klasse MyClass erweitert,

	public static class psc{
		public static void resetIntK(this MyClass mc) {
			mc.K = 0;
		}
	}

	public static void main() {
		MyClass mc = new MyClass(5); // wir nehmen an, dass k = 5 gesetzt
		mc.resetIntK();
	}

___________________________________

# Interfaces

Interfaces enthalten Methodensignaturen, aber keine Attribute. Statt von einer abstrakten Klasse abzuleiten kann man Interfaces verwenden. Man leitet vom Interface ab und muss alle Methoden mit Sichtbarkeit `public` implementieren. Erben von mehreren Interfaces ist erlaubt.

## Beispiel

	http://www.codeproject.com/Articles/18743/Interfaces-in-C-For-Beginners

Ab _P9.cs_ wird es interessant:
Man kann ein Objekt instantiieren, welches ein Interface erfüllt. Der Containertyp ist also der des Interfaces. Es stehen dann nur die Methoden zur Verfügung, die im Objekt und dem Containertyp zur Verfügung stehen. Wenn weitere Interfaces eingebunden werden stehen diese nicht zur Verfügung (wie in _P11.cs_), außer man wählt einen anderen Container.

Bis auf die Mehrfachvererbung sollte sich eine abstrakte Basisklasse genau so verwenden lassen: der Container legt die zur Verfügung stehenden Methoden fest, der Typ zur Laufzeit (Schlüsselwort new) legt das Verhalten dieser Methoden fest. (--> siehe vtable)

`P16.cs` zeigt, dass auch Interfaces von Interfaces erben können.

___________________________________

# Quellen

## Websites

* Onlinereferenz von Microsoft

	* http://msdn.microsoft.com/en-us/library/default.aspx


* Vtable

	* de.wikipedia.org/w/index.php?title=Tabelle_virtueller_Methoden&stableid=99390919

## Literatur

* A. Troelsen, _Pro C# 2010 and the .NET 4 Platform_, Apress, **2010**

* D. Solis, _Illustrated C#_, Apress, **2010**

	* "illustrated" bezieht sich vor allem auf die Speichernutzung