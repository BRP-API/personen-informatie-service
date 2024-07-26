# language: nl

@proxy
Functionaliteit: Als gebruiker van de API wil ik geen onbekend waardes ontvangen binnen locatie
  zodat ik deze niet hoef te (kunnen) interpreteren en ik geen code voor hoef te schrijven om deze situatie af te vangen

  Wanneer in de registratie specifieke waarden gereserveerd zijn voor een onbekende waarde, worden deze waarden niet doorgegeven in de API.
  Wanneer een element in de registratie een standaardwaarde heeft, die betekent dat de waarde onbekend is, wordt het corresponderende veld niet opgenomen in de response.


Regel: datumvelden waarde "00000000": worden vertaald naar DatumOnbekend

  Scenario: volledig onbekende datum aanvang adreshouding in verblijfplaats
    Gegeven adres 'A1' heeft de volgende gegevens
    | naam                        | waarde                      |
    | gemeentecode (92.10)        | 0518                        |
    | locatiebeschrijving (12.10) | Woonboot bij de Grote Sloot |
    En de persoon met burgerservicenummer '000000371' is ingeschreven op adres 'A1' met de volgende gegevens
    | naam                               | waarde   |
    | datum aanvang adreshouding (10.30) | 00000000 |
    Als personen wordt gezocht met de volgende parameters
    | naam                | waarde                          |
    | type                | RaadpleegMetBurgerservicenummer |
    | burgerservicenummer | 000000371                       |
    | fields              | verblijfplaats.datumVan         |
    Dan heeft de response een persoon met alleen de volgende 'verblijfplaats' gegevens
    | naam                 | waarde        |
    | type                 | Locatie       |
    | datumVan.type        | DatumOnbekend |
    | datumVan.onbekend    | true          |
    | datumVan.langFormaat | onbekend      |