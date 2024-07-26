#language: nl

@proxy
Functionaliteit: Gezag Persoon beperkt: adressering velden vragen met fields/fields alias

  Wanneer een consumer van de BRP API niet is geautoriseerd voor het bevragen van de adresregel velden voor een verblijfplaats buitenland
  Dan moet de consumer de adresseringBinnenland fields alias gebruiken om aan te geven dat hij adresregel velden voor een verblijfplaats binnenland vraagt

  Regel: de 'adresseringBinnenland' field alias moet worden gebruikt door een consumer die niet is geautoriseerd voor het vragen van adresregels horende bij verblijfplaats buitenland

    Scenario: afnemer is niet geautoriseerd voor 'adressering buitenland' en vraagt met de fields alias alle adresregel velden met hun volledig pad van een adres
      Gegeven de afnemer met indicatie '000008' is geautoriseerd voor 'adressering binnenland' gegevens
      En adres 'A1' heeft de volgende gegevens
      | naam                                     | waarde           |
      | gemeentecode (92.10)                     | 0518             |
      | straatnaam (11.10)                       | Borgesiusstraat  |
      | huisnummer (11.20)                       | 103              |
      | postcode (11.60)                         | 2497BV           |
      | woonplaats (11.70)                       | Scheveningen     |
      | identificatiecode verblijfplaats (11.80) | 0599010051001502 |
      En de persoon met burgerservicenummer '000000097' is ingeschreven op adres 'A1' met de volgende gegevens
      | naam                               | waarde   |
      | datum aanvang adreshouding (10.30) | 20200401 |
      Als personen wordt gezocht met de volgende parameters
      | naam                             | waarde                                                              |
      | type                             | ZoekMetAdresseerbaarObjectIdentificatie                             |
      | adresseerbaarObjectIdentificatie | 0599010051001502                                                    |
      | fields                           | adresseringBinnenland.adresregel1,adresseringBinnenland.adresregel2 |
      Dan heeft de response een persoon met de volgende 'adressering' gegevens
      | naam        | waarde                |
      | adresregel1 | Borgesiusstraat 103   |
      | adresregel2 | 2497 BV  SCHEVENINGEN |