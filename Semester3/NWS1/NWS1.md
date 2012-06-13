# Hub

Aus Netzwerksicht nicht da. Dient nur als Signalverstrker.

# Switch

aka Transparent Bridges / Layer-2 Switches

T.B.s legen eine Liste der MAC-Adressen an, um jedes Paket gezielt nur an
die Empfnger zu senden.

Anforderungen an die Liste

* lange genug, um alle MACs der Netzwerke zu speichern

* schnelle Suchzeit, da fr jedes einzelne Paket in der Tabelle der
  Adressat herausgesucht werden muss

## cut through switch

14 Byte bis destination MAC gelesen sind nur ntig. Da das Kollisionsfenster 64 byte lang ist kann noch eine Kollision stattfinden.

## collision free switch

Wartet entsprechend dem Minimum fr 64 byte.

## store and forward switch

Wartet bis zum CRC am Nachrichtenende um das Paket zu berprfen.
Hufigste Switchart (an der FH).

Erlaubt als einziges, verschiedene Netzwerktypen zu mischen.
Egal ob Full oder half duplex, egal ob 100 oder 1000 MBit.

______________

Broadcasts gehen an _alle_ anderen Clients. Man nennt diesen Bereich Broadcastdomain. Fr Broadcasts ist ein Switch durchlssig.

## Collisiondomain

______________

# 10 GBit

* es gibt nur full duplex ber switch

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

1. Root-Bridge durch Priorittenwahl von Admin oder kleinste MAC-Adresse

2. Root port ist krzeste Distanz zum Root Switch

3. Designated Port ist krzester Weg zurck

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

* nicht CSMA/CD wegen zu langer "minimaler" Paketlnge um Kollisionen vorzubeugen

* kein Taktsignal fr slotted Aloah. Auerdem ist der Nachbar nicht hrbar.

* --> pure aloah, nur max. 18% Durchsatz

# Token Passing Protokoll

Token Ring

* bertragung

	* Sendet in eine Richtung. Empfngt man die eigene Nachricht ist sie einmal durchgelaufen und wird nichtmehr weitergeleitet.

	* Token luft rundum. Die Station, welche das Token hat, darf senden.

		* besteht aus Startdelimiter, Zugriffssteuerung (Access Delimiter) und Enddelimiter

* Angeschaltete Maschinen liefern 1 Bit Verzgerung

* minimale Lnge des Rings ist 24 Bit

	* Monitorstation wird ausgewrfelt

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

Big bang: neues Protokoll fr das Internet (kein NCP mehr)

_________________________________________

# Layer 2 - Datalink

* MAC-Addresse

	48 oder 64 bit breit

* Frame Relay

	10 bit (0-1023)

* oder Telefonnumer (internationaler Rufnummernplan)

__________________________________________________

# Layer 3

32 bit stehen zur Verfgung

* Class A

	* Fangen mit null an, es folgen 7 + 24 bit

	* Wenige groe Netze (128 mal 16.777 Mio. Eintrge)

	* Maske: 127.255.255.255 (entspricht /8 in Prefix-Notation)

* Class B

	* Fangen mit 10 an. (2^14 =) 16.384 Netze mit jeweils (2^16 =) 65.536 IPs

	* Maske: 191.255.255.255

* Class C

	* Fngt mit 110 an

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

Gateway transportiert traffic fr dritte. Hosts nicht, auch wenn sie multi homed (mehrere Netzwerkadapter) sind.

.1 bis 254 sind verfgbar, 0 und 255 ist das gesamte Netzwerk als Sender bzw. Empfnger.

# Dreickeck aus Gateways

Bei vollstndiger Vermaschung ist auch ein Netzwerk ausreichen,
statt zwischen jedem Prchen ein Netzwerk aufzubauen.

# Subnetting

Host ID wird gesplittet in Subnet und krzere Host IDs.

Class C kann beispielsweise 4:4 oder 5:3 bit gesplittet werden.

Subnetting wird ber Masken realisiert. RFC-Konform wre die Einsen
beliebig zu verteilen. De facto wird immer von links mit Einsen aufgefllt.

Die gesammte Net ID muss immer berschrieben werden.

* Class A

	* 255.0.0.0

	* in Prfixschreibweise /8

* B

	* 255.255.0.0 bzw. /16

* C

	* 255.255.255.0 /24

* D

	* 255.255.255.

		* fr 4:4 split: .240 oder /28 

		* fr 5:3 split: .248 oder /29
	
		* fr 6:2 split: .252 oder /30. Dank broadcast und 0 gibt es nur zwei freie IPs --> Punkt-zu-Punkt-Verbindung

## Masken und IP-Aufteilung

/29 kann nur bei 0,8,16, ... beginnen

/28 knnte nur bei 0,16,32, ... beginnen

## RFC 1918

* 10.0.0.0-10.255.255.255 (10/8 prefix)

	einzelner Class A Block

* 172.16.0.0 - 172.31.255.255 (175.16/12 prefix)

	* 16 Class B Netze

* 192.168.0.0 - 192.168.255.255 (192.168/16 prefix)

	* 256 Class C Netze

# Zusammenfassung

0.0.0.0/8	this network
10.0.0.0/8	private-use networks
127.0.0.0/8	loopback
169.254.0.0/16	link lokal - z.B. bei fehlendem DHCP-Server unter Windows.
172.160.0.0/12	private-use networks
192.0.2.0/24	Test-NET1 Documentation
192.88.99.0/24	6to4 Relay Anycast
192.168.0.0/16	private-use networks
198.18.0.0/15	2 Class B Blocks - Benchmark testing
198.51.100.0/24	Test-NET2 Documentation
224.0.0.0/4	multicast
240.0.0.0/4	reserved for future use
255.255.255.255	limited broadcast

## Lokaler/limited Broadcast

endet an gateways. router und switches lassen ihn passieren.

__________________________________________________

# Supernetting

Der Netzteil wird gesplitted (statt dem Host-Teil)

# Classless interdomain routing - CIDR

Sub- und Supernetting kombiniert

___________________________________________________

# Praktikum

143.93.246.0/27 + 247.0/27 knnen zu 246.0/28 zusammengelegt werden, da wir bei geradem subnetz losgehen

Weiterhin:

180.0/22 --> Basisadresse muss durch vier teilbar sein.

___________________________________________________

# RIPE NCC

FH Worms - Status: Assigned PI - provider independend

Assigned PA - providerspezifisch

___________________________________________________

# Wdh.

127.x.y.z localhost

Multihomed hosts leiten keinen fremden Traffic weiter.

Subnetting: Class B --> 256 Class-C-Netzwerke
Subnetz 255 ist eher unproblematisch, Subnet 0 hingeben teilw. reserviert
je nach Endgert gibt es also Probleme.

NAT

98%ige Lsung, grtes Manko: bertrgt keine verschlsselten Daten.

___________________________________________________

# Mapping

Drei Verfahren

* Manuell gepflegte Liste

	* bei X25 oder ATM notwendig

	* MAC-Adresse wird durch IP-Adresse ersetzt

* ARP

	reverse ARP: IP-Addresse fr bekannte MAC nachsehen

* 1. Hardware Type | 2. Protocol Type

	1.1. HLEN

	1.2. PLEN Protocol len

	2.1. Operation

* Sender Hardware Address_{0-3}

	* Sender Hardware Address_{4-5}
	
	* Sender IP Address_{0-1}

	* Sender IP Address_{2-3}

	* Target Hardware Address_{0-1}

* Target Hardware Address_{2-5} (bei reverse ARP leer)

* Target IP Address_{2-5} (bei ARP leer)


# MAC-Addresse

bia: Burn in address ist physisch mitgegebene Addresse

# IP Encapsulation

* Head: Dest+Source MAC, je 6 byte

* Body: 

	* 2 Byte fr Type/Length, Unterscheidung:

		* 0x5DE = maximale Lnge (1500_dez) d.h. bei >0x600 handelt es sich um Typen
	
	* Type 0x800 (2 Byte)

		* IP Datagramm (46-1500 Byte)

		* 2+46 Byte sind Mindestlnge wg. Kollisionen.

	* Type 0x806 (2 Byte)

		* ARP request/reply (28 Byte)

		* PADding (18 Byte)

	* Type 0x806 (2 Byte)

		* RARP request/reply, PAD(28+18)

* Tail: CRC 4 bytes

# RFC 1042

Statt Typ (bei Ethernet II) kommt zunchst Length, erst nach 8 Byte folgt der Typ.

2 Byte Length, dann 1, 1, 1, 3 Byte org code, dann erst Typinformation

38-1492 Byte Daten

MTUs knnen bei 10GBit-Verbindungen hher eingestellt werden.

________________________________________________________________

65.536 Pakete pro 30 Sekunden sind ein Limit, dass bei Fragmentierung auftritt:
Keine zwei Fragemente aus unterschiedlichen Paketen drfen dann die selbe ID haben.

____________________________________________________________

# Record Route Option

HLen 4 bit, 0-15, jeweils ein Vollwort (4 bytes each) --> 60 Byte

Platz fr Hops: nicht 256 --> 4 hin, 4 zurck

`lgt im Gegensatz zu trace route nie`

## Pointer

IP-Adresse des Gateways im Zielnetz

## Codes

### ??

* Code 7: copy bit nicht gesetzt

### Internet Timestamp option

* maximal 4 hops

* Code 68: copy nicht gesetzt

### Strict source and record route option

* maximal 9 hops

* Code 131: copy bit gesetzt

G1->G2 MTU: 730
G2->G3 MTU: 330


		Host	ID	Anzahl Datenbytes	Laenge des IP-Paketes	F.Offset	MF

		A	1985	940		978 (18 byte optionen)	0	0

		G_1	"	688 = 8*86	726			0	1

		G_1	"	252		290			86	0

		G_2	"	288 = 36*8	326			0	1

		G_2	"	288		326			36	1

		G_2	"	112		150			72	1[sic]

		G_2	"	252		290			86	0


G2->G4 MTU: 198 (->G3) fr das eine Paket mit Offset 86


		Host	ID	Anzahl Datenbytes	Laenge des IP-Paketes	F.Offset	MF

		A	1985	940		978 (18 byte optionen)	0	0
		
		...

		G_1	"	252		290			86	0

		G_2	"	160 = 20*8	198			86	1

		G_2	"	92		130			106	0

______________________________________________________________________________________

G1->G2 MTU: 730
G2->G3 MTU: 430

code 18 --> dont copy


		Host	ID	Anzahl Datenbytes	Laenge des IP-Paketes	F.Offset	MF

		A	4711	840		878 (18 byte optionen)	0	0

		G_1	"	688 = 86*8	726 (18 byte optionen)	0	1

		G_1	"	152 von 704(nocopy)	172 (0 byte optionen)	86	0

		G_2	"	392 = 49*8	430 (18 byte optionen)	0	1

		G_2	"	296 von 408(nocopy)	316 (0 byte optionen)	49	1

		G_2	" 	152 von 408(nocopy)	172 (0 byte optionen)	86	0


G2->G4 MTU: 218 (-> G3)

		Host	ID	Anzahl Datenbytes	Laenge des IP-Paketes	F.Offset	MF

		A	4711	840		878 (18 byte optionen)	0	0

		G_1	"	688 = 86*8	726 (18 byte optionen)	0	1

		G_1	"	152 von 176(nocopy)	172 (0 byte optionen)	86	0 --> luft durch MTU 218, alles bestens
		
		
# Wiederholung

D - Low delay
T - Hight Throughput
R - High Reliability (Verschlüsselung?)
C - Low Cost

DSCP findet an Netzwerk- und Administrationsgrenzen statt

Network-Gateway = Router

# IP-Routing

Host in Netzwerk. Das Netzwerk kennt zwei Gateways.
Der Host entscheidet, an welches Gateway er seine Pakete schickt.


# Routing an Internet Datagram

^ = bitweise und

Es wird verglichen, ob QuellIP ^ Maske == ZielIP ^ Maske

Im gleichen Netzwerk ist kein Routing notwendig.

Im Falle QuellIP ^ Maske != ZielIP ^ Maske muss ein Gateway den Transfer
übernehmen. Der Absender schaut in seine Routing-Table um das Gateway zu finden.
Der Router hat eine Routing-Table mit (mindestens?) den verbundenen Netzen.

Das Gateway ändert nichts am Paket, nur die MAC-Adresse ändert sich.

## Beispiel 10.0.0.0 nach 40.0.0.0

Alle Einträge, um nach 40.0.0.0 zu kommen müssen dem Gateway eins und jeweils allen Folgenden bekannt sein.

D.h. es reicht nicht, wenn 40.0.0.0 nur dem ersten Gateway bekannt ist.

_Next Hop_ enthält die Gateways, um zum _Net_ zu kommen.

Realfall: Hin- und Rückwege sind nicht identisch.

## Beispiel Hosts A bis D, Routing-Table A und C

Lösung für das Problem jede Ziel-IP der Welt: default-Gateway, meist 0.0.0.0

Gateways enthalten idealerweise keine default-gateways, da unbekannte Hosts zu einer Endlosschleife führen können.

Altes Internet: default-free-router an der spitze, alle anderen Router haben hierarchisch einen näher daran liegende default-route.

Bei gleichem Bereich in verschiedenen Subnetzen (erkennbar z.B. an unterschiedlichen Masken) nimmt der Router das kleinste Subnetz.
Das spezifischste gewinnt also.

# VSLM

Subnetzmasken mit variabler Länge 

## Klausuraufgabe

/19 bedeutet bis +32.+255 da 8192/256 = 32 bzw. 2^(32-19-8 = 5) = 32

173.0/24 bis 188.0/24 entspricht:
173.0/24
174.0/23 (durch zwei teilbar)
176.0/21 (durch acht teilbar)
184.0/22 (durch vier teilbar)
188.0/24

_______________________________________________________

# IMCP

ICMP-Protokollfeld-ID = 1

Tunnel Encapsulation --> 4

Checksum, die nicht über den Header, sondern den ganzen Rest geht,
wird nur am Start erstellt und am Ziel ausgewertet.

## Echo request

Besteht aus

* type 8

* code 0

* Checksum

* identifier = ID/Nummer der Anfrage

* sequence number

	* Anzahl der Pakete

	* dient dem feststellen von Verlust und Vertauschung

* optional Data

	* enthält Datenmüll zum auffüllen der Länge

### Beispiel

Daten 56 byte + ICMP-Header 8 byte
IP-Header + Daten = 84 byte

# Anmerkung

Maximale Paket-Länge _mit_ Fragmentierung 2^16 = 65.536

# ICMP

## source quench

Fehlermeldung bei zu wenig Bandbreite (auf einer Teilstrecke). Kommt aber oft nicht an, weil der Fehler in beide Richtungen den traffic beeinträchtigen kann

## redirect

Ein Paket wird von einem Gateway an anderes Gateway weitergeleitet und der Absender darüber mit dem redirect informiert.
Die Routingtable des Absenders soll hiernach also erweitert werden.

## time exceeded

ttl = 0 erreicht oder fragmentation reassembly time exceeded


# Virtuelle Gateways

G' erhält IP' und MAC'

# Folie 938

Load sharing: je nach Ziel läuft die Verbindung über 3.0.0.0 oder 4.0.0.0

## ping -r
9 max-Sprünge
60-20 = 40 byte, Kopfwort von 4 byte, es bleiben 9 Worte als Informationen über Sprünge. Verwendung eher im LAN, quasi nie im (globalen) Internet.

## hingegen bei traceroute:
TTL_start = 1, TTL++ bis zum Ziel bei jedem Sprung.
Die ICMP-Time-Exceeded-Fehlermeldung enthält die Information, wo das Paket jeweils ist
--> Absendeadresse der Fehlermeldung wird zurückgeliefert.
Bei unsymetrischen Routen wird also evtl eine IP geliefert, die das Paket nicht empfangen hat.

# Wiederhohlung

D - Low delay
T - Hight Throughput
R - High Reliability (Verschlüsselung?)
C - Low Cost

DSCP findet an Netzwerk- und Administrationsgrenzen statt

Network-Gateway = Router

# IP-Routing

Host in Netzwerk. Das Netzwerk kennt zwei Gateways.
Der Host entscheidet, an welches Gateway er seine Pakete schickt.


# Routing an Internet Datagram

^ = bitweise und

Es wird verglichen, ob QuellIP ^ Maske == ZielIP ^ Maske

Im gleichen Netzwerk ist kein Routing notwendig.

Im Falle QuellIP ^ Maske != ZielIP ^ Maske muss ein Gateway den Transfer
übernehmen. Der Absender schaut in seine Routing-Table um das Gateway zu finden.
Der Router hat eine Routing-Table mit (mindestens?) den verbundenen Netzen.

Das Gateway ändert nichts am Paket, nur die MAC-Adresse ändert sich.

## Beispiel 10.0.0.0 nach 40.0.0.0

Alle Einträge, um nach 40.0.0.0 zu kommen müssen dem Gateway eins und jeweils allen Folgenden bekannt sein.

D.h. es reicht nicht, wenn 40.0.0.0 nur dem ersten Gateway bekannt ist.

_Next Hop_ enthält die Gateways, um zum _Net_ zu kommen.

Realfall: Hin- und Rückwege sind nicht identisch.

## Beispiel Hosts A bis D, Routing-Table A und C

Lösung für das Problem jede Ziel-IP der Welt: default-Gateway, meist 0.0.0.0

Gateways enthalten idealerweise keine default-gateways, da unbekannte Hosts zu einer Endlosschleife führen können.

Altes Internet: default-free-router an der spitze, alle anderen Router haben hierarchisch einen näher daran liegende default-route.

Bei gleichem Bereich in verschiedenen Subnetzen (erkennbar z.B. an unterschiedlichen Masken) nimmt der Router das kleinste Subnetz.
Das spezifischste gewinnt also.

# VSLM

Subnetzmasken mit variabler Länge 

## Klausuraufgabe

/19 bedeutet bis +32.+255 da 8192/256 = 32 bzw. 2^(32-19-8 = 5) = 32

173.0/24 bis 188.0/24 entspricht:
173.0/24
174.0/23 (durch zwei teilbar)
176.0/21 (durch acht teilbar)
184.0/22 (durch vier teilbar)
188.0/24

_______________________________________________________

# IMCP

ICMP-Protokollfeld-ID = 1

Tunnel Encapsulation --> 4

Checksum, die nicht über den Header, sondern den ganzen Rest geht,
wird nur am Start erstellt und am Ziel ausgewertet.

## Echo request

Besteht aus

* type 8

* code 0

* Checksum

* identifier = ID/Nummer der Anfrage

* sequence number

	* Anzahl der Pakete

	* dient dem feststellen von Verlust und Vertauschung

* optional Data

	* enthält Datenmüll zum auffüllen der Länge

### Beispiel

Daten 56 byte + ICMP-Header 8 byte
IP-Header + Daten = 84 byte

# Anmerkung

Maximale Paket-Länge _mit_ Fragmentierung 2^16 = 65.536

# ICMP

## source quench

Fehlermeldung bei zu wenig Bandbreite (auf einer Teilstrecke). Kommt aber oft nicht an, weil der Fehler in beide Richtungen den traffic beeinträchtigen kann

## redirect

Ein Paket wird von einem Gateway an anderes Gateway weitergeleitet und der Absender darüber mit dem redirect informiert.
Die Routingtable des Absenders soll hiernach also erweitert werden.

## time exceeded

ttl = 0 erreicht oder fragmentation reassembly time exceeded


# Virtuelle Gateways

G' erhält IP' und MAC'

# Folie 938

Load sharing: je nach Ziel läuft die Verbindung über 3.0.0.0 oder 4.0.0.0

## ping -r
9 max-Sprünge
60-20 = 40 byte, Kopfwort von 4 byte, es bleiben 9 Worte als Informationen über Sprünge. Verwendung eher im LAN, quasi nie im (globalen) Internet.

## hingegen bei traceroute:
TTL_start = 1, TTL++ bis zum Ziel bei jedem Sprung.
Die ICMP-Time-Exceeded-Fehlermeldung enthält die Information, wo das Paket jeweils ist
--> Absendeadresse der Fehlermeldung wird zurückgeliefert.
Bei unsymetrischen Routen wird also evtl eine IP geliefert, die das Paket nicht empfangen hat.