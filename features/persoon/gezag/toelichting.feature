  #language: nl

  @api
  Functionaliteit: adressering adresregel velden vragen met fields

  Regel: wanneer adresregel1 en/of adresregel2 velden van de adressering groep voor een persoon met een adres wordt gevraagd, dan wordt altijd de waarde van 'straatnaam (11.10)' en 'huisnummer (11.20)' geleverd

  Scenario: persoon heeft een adres met alleen een straatnaam en huisnummer als verblijfplaats en adresregel1 wordt gevraagd
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10)       | huisnummer (11.20) |
      | 0518                 | Jonkheer van Riemsdijkln | 88                 |
      En de persoon met burgerservicenummer '000000188' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) |
      | 0518                              |
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                          |
      | type                | RaadpleegMetBurgerservicenummer |
      | burgerservicenummer | 000000188                       |
      | fields              | gezag                           |
      Dan heeft de response een persoon met de volgende 'gezag' gegevens
      | naam        | waarde                                                                           |
      | type        | GezagNietTeBepalen                                                               |