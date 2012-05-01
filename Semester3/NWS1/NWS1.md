# Hub

Aus Netzwerksicht nicht da. Dient nur als Signalverstärker.

# Switch

aka Transparent Bridges / Layer-2 Switches

T.B.s legen eine Liste der MAC-Adressen an, um jedes Paket gezielt nur an
die Empfänger zu senden.

Anforderungen an die Liste

* lange genug, um alle MACs der Netzwerke zu speichern

* schnelle Suchzeit, da für jedes einzelne Paket in der Tabelle der
  Adressat herausgesucht werden muss

## cut through switch

14 Byte bis destination MAC gelesen sind nur nötig. Da das Kollisionsfenster 64 byte lang ist kann noch eine Kollision stattfinden.

## collision free switch

Wartet entsprechend dem Minimum für 64 byte.

## store and forward switch

Wartet bis zum CRC am Nachrichtenende um das Paket zu überprüfen.
Häufigste Switchart (an der FH).

Erlaubt als einziges, verschiedene Netzwerktypen zu mischen.
Egal ob Full oder half duplex, egal ob 100 oder 1000 MBit.

______________

Broadcasts gehen an _alle_ anderen Clients. Man nennt diesen Bereich Broadcastdomain. Für Broadcasts ist ein Switch durchlässig.

## Collisiondomain

______________

# 10 GBit

* es gibt nur full duplex über switch

64/66 B Kodierung --> viele Nutzdaten, wenig Takt

850 nm laser

* 10GBASE-SR short range

	* 26m - 80 m

* 10GBASE-LR long range

	* 1310 nm

	* 10 - 25 km

* 10GBASE-ZR

	* 1550 nm

	* 80 km

* 10GBASE-CX4

	* baud rate 3.125 GHz/lane mit 8B/10B coding

	* 15 m

* 10GBASE-T

	* cat 6e, 7

	* 100m

# Parallelschaltung von Switches

* Problem Broadcast-Endlosschleife (Broadcaststurm)

**==> Spanning tree protocol**

1. Root-Bridge durch Prioritätenwahl von Admin oder kleinste MAC-Adresse

2. Root port ist kürzeste Distanz zum Root Switch

3. Designated Port ist kürzester Weg zurück

4. alle anderen Ports werden geblockt --> loopfreie Topologie

# BPDU

switch status

* blocking (BLK)

* learning

* forwarding (FWD)

* disabled - abgschaltet vom Admin

# VLAN

physisch nicht, aber praktisch getrennte LANs

# Satellitennetzwerk

* nicht CSMA/CD wegen zu langer "minimaler" Paketlänge um Kollisionen vorzubeugen

* kein Taktsignal für slotted Aloah. Außerdem ist der Nachbar nicht hörbar.

* --> pure aloah, nur max. 18% Durchsatz

# Token Passing Protokoll

Token Ring

* Übertragung

	* Sendet in eine Richtung. Empfängt man die eigene Nachricht ist sie einmal durchgelaufen und wird nichtmehr weitergeleitet.

	* Token läuft rundum. Die Station, welche das Token hat, darf senden.

		* besteht aus Startdelimiter, Zugriffssteuerung (Access Delimiter) und Enddelimiter

* Angeschaltete Maschinen liefern 1 Bit Verzögerung

* minimale Länge des Rings ist 24 Bit

	* Monitorstation wird ausgewürfelt

* Senden

	* SD wird negiert, neue AC und FC erzeugt und Nachricht folgt

	* Daten theoretisch unbegrenzt, faktisch max. 9KB durch 10ms Timer

	* Endet mit Frame Status

		* falls Zielhost nicht vorhanden wird dies bemerkt

		* Zielhost kippt vorhandenes erstes Bit

			* bei erfolgreichem lesen wird auch das zweite Bit gekippt

_________________________________________

# ARPA 1969

## 1.1.1983

Big bang: neues Protokoll für das Internet (kein NCP mehr)

_________________________________________

# Layer 2 - Datalink

* MAC-Addresse

	48 oder 64 bit breit

* Frame Relay

	10 bit (0-1023)

* oder Telefonnumer (internationaler Rufnummernplan)

__________________________________________________

# Layer 3

32 bit stehen zur Verfügung

* Class A

	* Fangen mit null an, es folgen 7 + 24 bit

	* Wenige große Netze (128 mal 16.777 Mio. Einträge)

	* Maske: 127.255.255.255 (entspricht /8 in Prefix-Notation)

* Class B

	* Fangen mit 10 an. (2^14 =) 16.384 Netze mit jeweils (2^16 =) 65.536 IPs

	* Maske: 191.255.255.255

* Class C

	* Fängt mit 110 an

	* 2 Millionen Netze mit jeweils 256 IPs (21 zu 8 freie Bits)

	* Maske: 223.255.255.255

* Class D

	* 1110, Multicast Address, Raum 4.3 Mrd. von Addressen

	* Viele Listener auf eine Quelle

	* Endaddresse: 239.255.255.255

* Class E

	* 1111, reserved for future use, ebenfalls 4.3 G

	* Endaddresse: 255.255.255.254 bzw. 255

__________________________________________

# 0.0.0.0

Absendeaddresse, nie Ziel

Nur beim Systemstart

Anmeldung: 0.0.0.0 sagt bitte gibt mir eine IP

	This host

# 0.0.X.Y

	Host on this network

# 1111111111111111

Limited Broadcast im lokalen Netz

Nur Ziel, nie Quelladdresse

_____________________________________________

# TCP/IP

Pro Netzwerkadapter eine IP-Addresse

Unterschied Host/Gateway

Gateway transportiert traffic für dritte. Hosts nicht, auch wenn sie multi homed (mehrere Netzwerkadapter) sind.

.1 bis 254 sind verfügbar, 0 und 255 ist das gesamte Netzwerk als Sender bzw. Empfänger.

# Dreickeck aus Gateways

Bei vollständiger Vermaschung ist auch ein Netzwerk ausreichen,
statt zwischen jedem Pärchen ein Netzwerk aufzubauen.

# Subnetting

Host ID wird gesplittet in Subnet und kürzere Host IDs.

Class C kann beispielsweise 4:4 oder 5:3 bit gesplittet werden.

Subnetting wird über Masken realisiert. RFC-Konform wäre die Einsen
beliebig zu verteilen. De facto wird immer von links mit Einsen aufgefüllt.

Die gesammte Net ID muss immer überschrieben werden.

* Class A

	* 255.0.0.0

	* in Präfixschreibweise /8

* B

	* 255.255.0.0 bzw. /16

* C

	* 255.255.255.0 /24

* D

	* 255.255.255.

		* für 4:4 split: .240 oder /28 

		* für 5:3 split: .248 oder /29
	
		* für 6:2 split: .252 oder /30. Dank broadcast und 0 gibt es nur zwei freie IPs --> Punkt-zu-Punkt-Verbindung

## Masken und IP-Aufteilung

/29 kann nur bei 0,8,16, ... beginnen

/28 könnte nur bei 0,16,32, ... beginnen

## RFC 1918

* 10.0.0.0-10.255.255.255 (10/8 prefix)

	einzelner Class A Block

* 172.16.0.0 - 172.31.255.255 (175.16/12 prefix)

	* 16 Class B Netze

* 192.168.0.0 - 192.168.255.255 (192.168/16 prefix)

	* 256 Class C Netze

# Zusammenfassung

0.0.0.0/8	this network
10.0.0.0/8	private-use network
127.0.0.0/8	loopback
169.254.0.0/16	link lokal - z.B. bei fehlendem DHCP-Server unter Windows.
172.160.0.0/12	
192.0.2.0/24	Test-NET1 Documentation
192.88.99.0/24	6to4 Relay Anycast
192.168.0.0/16	private-use network
198.18.0.0/15	2 Class B Blocks - Benchmark testing
198.51.100.0/24	Test-NET2 Documentation
224.0.0.0/4
240.0.0.0/4

__________________________________________________

# Supernetting

Der Netzteil wird gesplitted (statt dem Host-Teil)

Sub- und Supernetting kombiniert:

# Classless interdomain routing - CIDR

___________________________________________________

# Praktikum

143.93.246.0/27 + 247.0/27 können zu 246.0/28 zusammengelegt werden, da wir bei geradem subnetz losgehen

Weiterhin:

180.0/22 --> Basisadresse muss durch vier teilbar sein.

___________________________________________________

# RIPE NCC

FH Worms - Status: Assigned PI - provider independend

Assigned PA - providerspezifisch
