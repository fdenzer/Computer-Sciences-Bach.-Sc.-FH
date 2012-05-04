# Werttypen

* Char

	* ASCII (256 zeichen, davon 20 Steuerzeichen)

	* IBM-Spezifisches

	* Unicode

	* Problem little/big endian

* Byte

## CPU

### ALU

Rechenwerk (Arithmetical Logical Unit)

Kann nur addieren, subtrahieren ist bei Zweierkomplementzahlen nicht nötig.


### Register

* Stackpointer

* Status

usw.

ca 130 Register sind vorhanden.


# Fließkomazahlen

	* float

Definiert in IEEE 754
( http://steve.hollasch.net/cgindex/coding/ieeefloat.html )

Aufbau: Vorzeichen, Exponent, Mantisse
im Bit-Verhältnis 1:8:23

normierte Darstellung der Mantisse

Eine Vorkommastelle:

Erste Ziffer (ungleich null)

Also im Bereich 1,0 bis 9,99999...

# Exponent

Bias: 127, wird beim lesen vom Exponent (immer >0) abgezogen

Somit können negative Exponenten dargestellt werden.

2^23 = ca 8.000.000 < 9.999.999 -> 6 signifikante Stellen

## Darstellung der Null

Mantisse 0 entspricht 1.0, exponent entspricht -127

	* double

	1:11:52 bit

	15-16 Dezimalstellen

	* decimal

	altes BCD-Format: Pro Dezimalziffer pro Byte ( erstes Halbbyte sind Nullen)
	
	Packed Binary Decimal nutzt zwei BCD-Zahlen pro Byte

	c#-decimal enthält ca. 25 Dezimalstellen

	* bool

	false: 0000.0000_2

	true: 1111.1111_2 = FF_hex

Weitere Zahlen als Klassen

Complex enthält auch die überladenen Operatoren um mit komplexen Zahlen zu rechnen.

C##: Templates, void-Zeiger entsprechen generics / Generischen Klassen


# Object 

Objekte vom Typ object bieten

* (tiefe) Kopien

* equals-Vergleich

# String

string sieht aus wie ein value type und verhält sich auch so. Ist aber eigtl. ein Referenztyp

Methoden
	
	PadLeft() PadRight()	füllt mir String auf
	
	
	Properties

	Length					Länge
	Empty					leerer String
	Chars					String-Indexer

# Boxing und unboxing

Unboxing muss explizit durchgeführt werden.

Es gibt keine Funktionsschreibweise aus C++ mehr:

geht nicht:	int(var)
geht:	(int)var

Console.Write() nutzt das automatische boxing

Unboxing

	object obj = "10";
	int i = (int) obj;

# Memory-management

## C++

Nach Wahl sind Variablen und Objekte beliebig in Heap oder Stack

## CSharp

* Referenzschreibweise ohne Stern

* Stackelement = Werttyp,

* Heapelement = Referenztyp

* Garbage Collection:

	* nichtdeterministisch: 

	* automatisch

# Arrays

## Methoden

GetLength() / Length

BinarySearch() - Binäre Suche

### ERP

Fehlt die Sortierung kann eine Sekundärindextabelle helfen.

Dimensionen eines Arrays: 0,1,2,N

Skalar
Vektor
Matrix
Tensor wenn gewisse Transformations-Eigenschaften erfüllt sind

# Parameterübergaben an Methoden

## C++

Call-by-reference oder call-by-value

`const` definiert nicht Konstanten sondern legt Read-only-variablen-Fest.
`const` in Parameterlisten bedeutet, dass die Funktion die Variable nicht
verändern darf.

## CSharp

call-by-reference über `ref` oder `out` wobei letzterer sicher geht,
das das Objekt versorgt wurde.

`const` in Parameterlisten gibt es in c# nichtmehr

2.0d = 2.0 (double)
2 (int)
2.0f (float)
2.0m (decimal)

Named Parameter gibt es seit C# 4.0. Sie sorgen für das richtige
Sortieren.

# Properties

getarnte Methodenaufrufe

	private int lgth;

	public int Lgth {

		get {				//public int get()
			return lgth;
		}

		set {				//public void set(int value)
			lgth = value;
		}
	}

## Indexer

indizierte Properties

	this[]

Beispiel an selbst gebauter generischer Collection

	class SampleCollection<T> {
		// Declare an array to store the data elements.
    	private T[] arr = new T[100];	

	    // Define the indexer, which will allow client code
    	// to use [] notation on the class instance itself.
    	// (See line 2 of code in Main below.)        
	    public T this[int i] {
			get {
				// This indexer is very simple, and just returns or sets
				// the corresponding element from the internal array.
				return arr[i];
   	     	}
   	     	set {
				arr[i] = value;
			}
		}
	}

Der []-Operator darf in C# nicht überladen werden da über den Indexer die gleichen Änderungen möglich sind.

Funktioniert nicht mit foreach, da dies eine Collection vorraussetzt.

# Switch-Selektion

Jeder Fall, auch default, muss mit break oder return enden.

# Vererbung

Im Gegensatz zu C++ gibt es keine privaten oder öffentlichen Ableitungen.

Mehrfachvererbung kann nur von abstrakten Klassen erfolgen. Die Funktionalitäten müssen dementsprechend noch nachgeliefert werden.

`inline`-Funktionen sind nichtmehr nötig/erlaubt. inline bedeutet, dass der Quellcode vom Compiler kopiert würde um sprünge usw. zu vermeiden.


# Konstruktoren

## Vererbung

super() (Java) heißt in C# base()

Mit this() kann ein Konstruktor einer abgeleiteten Klasse aufgerufen werden.

## statischer Konstruktor

Der statische Konstruktor hat keinen access modifier.

## Ableitung und Vererbung

### Beispiel mit Ableitungsschema A : B

Ein Zeiger auf B kann auch auf ein Objekt vom Typ A zeigen.

Für B wird im Heap Speicherplatz für Attribute Reserviert.
Für ein Objekt vom Typ A wird dieser um die Attribute von A erweitert.

# Desktruktor

## IDisposable

Zusätzlich zum garbage collector gibt es die Möglichkeit, über Dispose() Objekte zu entsorgen, die von IDisposable geerbt haben.

Klassen, welche unmanaged ressources (außerhalb des Frameworks) nutzen können diese über Dispose() und Close() wieder freigeben.

## Dekonstruktor

Der GC ruft bei nicht benötigten Objekten nichtdeterministisch, also zu keinem festgelegten Zeitpunkt, den Dekonstruktor auf.

## using-statement

Am Ende eines using-blocks wird Dispose() aufgerufen

		--> Nicht zu verwechseln mit den using directives <--

________________________________________________

# Virtuelle Methoden

## C++

Virtuelle Klassen werden in der Basisklasse mit virtual gekennzeichnet. 
Rein virtuelle Methoden werden mit `= 0;` gekennzeichnet
überschrieben wird ebenfalls mit dem Schlüsselwort virtual.

## CSharp

Virtual kann, muss aber nicht, überschrieben werden. Bei abstract ist das Überschreiben Pflicht.

`virtual`-Methoden müssen mit override überschrieben werden.
(In java wäre @override optional und eine Zeile zuvor zu nennen.)

In virtuellen Methoden steht mit base(...) die Methode der Basisklasse zur Verfügung.

### `new` in diesem Zusammenhang

Mit dem Schlüsselwort new kann ein überdecken 

### Vtable

Zur Laufzeit können in der Tabelle virtueller Methoden die konkreten Ausprägungen gelesen werden.
Der Compiler erzeugt noch vor den anderen Attributen einen Pointer auf die Vtable.

## sealed

Sealed-Klassen und -Methoden können nicht (weiter) beerbt werden.

Die Vtable ist kürzer wenn man die Varianten nichtmehr hat, die abgeleitete Klassen bieten. Dies bietet einen Geschwindigkeitsvorteil zur Laufzeit.

String (Sonderrolle verhält sich wie Werttyp) ist beispielsweise sealed.

____________________________________________________

# Interfaces

Nomenklatur: Fangen mit `I` an
`public abstract` ist implizit und wird meist nicht hingeschrieben.
`virtual` und `public` dürfen nicht verwendet werden.
Es darf Properties wie `decimal Saldo{ get;}` geben aber keine Attribute.

Ein Interface ist ein Vertrag, den eine implementierende Klasse erfüllen muss.

Ein Interface kann von anderen Interfaces erben.

Abgeleitete (implementierende) Klassen können über Interface-Referenzen instantiiert werden. Explizite Casts sind jedoch nötig um alle Methoden zu erreichen, die nicht Teil des Interfaces sind.

____________________________________________________________

# Collections

Alle Collections implementieren ICollection.

## Vorraussetzungen

* lesen/schreiben

* resetten

* weitergehen

	* --> oft Aufgabe Reihenfolge festlegen: Sortierung

* Ende erreicht?

Genaue Voraussetzungen weiter unten (IEnumerable ...).

## Arten von Collections

* Allg./generische Collections
	
	* früher `object` (erfordert explizite Typecasts), heute generics
	
	* ArrayList, Stack, Queue

* spezialisierte Collections

	* für Strings oder verkettete Listen

* bitverarbeitende Collections

	* Speichern von Bit-Gruppen


		interface IEnumerator {
			object Current{get;}
			bool MoveNext();
			void Reset();
		}

		interface IEnumerable {
			IEnumerator GetEnumerator();
		}

		interface ICollection : IEnumerable {
			int Count{get}
			bool isSynchronized{get;}	// true, wenn Zugriff synchronisiert
			object SyncRoot{get;}
			void CopyTo(Array target, int index);
		}


Weitere Interfaces

IComparer	Vergleich als Grundlage für eine Sortierung

IList

IDictionary

IDictionaryEnumerator


__________________________________________________________

