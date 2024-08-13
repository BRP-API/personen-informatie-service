# language: nl

@proxy
Functionaliteit: Persoon - verblijfplaats binnenland (locatie): verblijfadres velden vragen met fields

  Achtergrond:
    Gegeven adres 'A1' heeft de volgende gegevens
    | naam                        | waarde                      |
    | gemeentecode (92.10)        | 0518                        |
    | locatiebeschrijving (12.10) | Woonboot bij de Grote Sloot |
    En de persoon met burgerservicenummer '000000152' is ingeschreven op adres 'A1' met de volgende gegevens
    | naam                               | waarde   |
    | datum aanvang adreshouding (10.30) | 20150808 |
    | datum ingang geldigheid (85.10)    | 20220222 |

  Scenario: 'locatiebeschrijving (12.10)' wordt gevraagd met field pad 'verblijfplaats.verblijfadres.locatiebeschrijving'
    Als personen wordt gezocht met de volgende parameters
    | naam                | waarde                                           |
    | type                | RaadpleegMetBurgerservicenummer                  |
    | burgerservicenummer | 000000152                                        |
    | fields              | verblijfplaats.verblijfadres.locatiebeschrijving |
    Dan heeft de response een persoon met de volgende 'verblijfplaats' gegevens
    | naam                              | waarde                      |
    | type                              | Locatie                     |
    | verblijfadres.locatiebeschrijving | Woonboot bij de Grote Sloot |

  Scenario: alle adres velden wordt gevraagd met field pad 'verblijfplaats.verblijfadres'
    Als personen wordt gezocht met de volgende parameters
    | naam                | waarde                          |
    | type                | RaadpleegMetBurgerservicenummer |
    | burgerservicenummer | 000000152                       |
    | fields              | verblijfplaats.verblijfadres    |
    Dan heeft de response een persoon met de volgende 'verblijfplaats' gegevens
    | naam                              | waarde                      |
    | type                              | Locatie                     |
    | verblijfadres.locatiebeschrijving | Woonboot bij de Grote Sloot |
