# Techniki Obiektowe LAB 5

## ZADANIE LABORATORYJNE

## Rozwiązanie:

### Opis rozwiązania:
* Main
  * `Program`  tworzy `ControlStation` i ładuje do niej `FireStation`-s przy pomocy `CSVParser`-a z pliku .csv. `FireStation`-s domyślnie tworzą w sobie określoną liczbę `FireTruck`-s.
  * `Program` programy co jakiś *losowy* czas tworzony jest `Incident` który ma swoją nazwę, lokalizację oraz typ `MZ` albo `PZ` a także z góry założone czy jest to prawdziwe czy fałszywe zagrożenie
* `ControlStation`
  * odbiera `Incident` następnie tworzy `FireSquad` do którego dodawane są `FireTruck`-s według `IEventStrategy` który szuka najbliższe `2` lub `3` wozy strażackie w zależności od `Incident.Type`
  * po przygotowaniu `FireSquad` asynchronicznie uruchamia ich działanie
* `FireSquad`
  * dojeżdza na miejsce zdażenia
  * następnie sprawdza `Incident.Real` i w zależności od Typu wybiera `IExecutionStrategy` - automatyczny powrót, lub działanie jeżeli zagrożenie jest prawdziwe
  * po zakończeniu pojazdy wracają do bazy z `IdleStatus`
* ![UML Diagram](TO_LAB_5.png)