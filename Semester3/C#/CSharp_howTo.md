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

# 



___________________________________

# Quellen

* Vtable

	* de.wikipedia.org/w/index.php?title=Tabelle_virtueller_Methoden&stableid=99390919

Literatur

* A. Troelsen, _Pro C# 2010 and the .NET 4 Platform_, Apress, **2010**

* D. Solis, _Illustrated C#_, Apress, **2010**

	* "illustrated" bezieht sich auf die Speichernutzung