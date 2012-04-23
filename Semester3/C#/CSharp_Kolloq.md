# Aufbau des Speichers

	FF...					0
	|__________|____________|
		Stack		Heap

Heap wird von 0 aufwärts befüllt.
Der Stack läuft ihm entgegen. Er fängt am Ende an und wird absteigend befüllt.

Im Heap liegt das Codesegment. Dort befinden sich alle u.a. Methoden.
Auf dem Stack befinden sich Variablen, auch solche, die von Methoden
angelegt werden.

# Objektdeklaration und -instantiierung

	Int32 i;

legt einen (32 oder 64 bit je nach Architektur) Speicherplatz für einen Zeiger an.

	i = Int32(1);

legt in mehreren Schritten ein Objekt im Heap an.

Zunächst wird vom Compiler der Speicherplatz, der zum Großteil für Attribute benötigt wird, reserviert. Dann wird der Konstruktor aufgerufen. Da der Konstruktur das Objekt kennen muss, welches er initialisiert, wird

	Int32(5)

zu

	Int32(referenz_auf_i, 5)

Dies kann erfolgen, da der Aufruf von i.Int32(5) gleichbedeutend ist mit this.Int32(5) und der this-Zeiger auf das eigene Objekt zeigt.


# Nichtstatische Methoden

aus objekt.ToString() wird ToString(refZumObjekt)

# Zugriff auf Attribute eines Objekts aus statischen Methoden heraus

StaticToString(refZumObjekt.Attribut) ist möglich, es muss aber refZumObjekt per Hand eingegeben werden 