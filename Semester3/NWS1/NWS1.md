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

