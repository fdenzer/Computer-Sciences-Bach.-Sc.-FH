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