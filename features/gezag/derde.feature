#language: nl

Functionaliteit: derde

  Scenario: gezamenlijk gezag met onbekende derde
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0599                 | 0599010051001502                         |
    En de persoon met burgerservicenummer '000000048' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0599                              |
    En voor de persoon geldt ook het volgende gezag
    | naam                             | waarde           |
    | type                             | GezamenlijkGezag |
    | minderjarige.burgerservicenummer | 000000036        |
    | ouder.burgerservicenummer        | 000000061        |
    | derde.type                       | OnbekendeDerde   |
    Als personen wordt gezocht met de volgende parameters
    | naam                             | waarde                                  |
    | type                             | ZoekMetAdresseerbaarObjectIdentificatie |
    | adresseerbaarObjectIdentificatie | 0599010051001502                        |
    | fields                           | gezag                                   |
    Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
    | naam                             | waarde           |
    | type                             | GezamenlijkGezag |
    | minderjarige.burgerservicenummer | 000000036        |
    | ouder.burgerservicenummer        | 000000061        |
    | derde.type                       | OnbekendeDerde   |

  Scenario: gezamenlijk gezag met onbekende derde
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0599                 | 0599010051001502                         |
    En de persoon met burgerservicenummer '000000048' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0599                              |
    En voor de persoon geldt ook het volgende gezag
    | naam                             | waarde           |
    | type                             | GezamenlijkGezag |
    | minderjarige.burgerservicenummer | 000000036        |
    | ouder.burgerservicenummer        | 000000061        |
    | derde.type                       | OnbekendeDerde   |
    Als personen wordt gezocht met de volgende parameters
    | naam                | waarde                          |
    | type                | RaadpleegMetBurgerservicenummer |
    | burgerservicenummer | 000000048                       |
    | fields              | gezag                           |
    Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
    | naam                             | waarde           |
    | type                             | GezamenlijkGezag |
    | minderjarige.burgerservicenummer | 000000036        |
    | ouder.burgerservicenummer        | 000000061        |
    | derde.type                       | OnbekendeDerde   |

  Scenario: voogdij met meerdere bekende derden
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0599                 | 0599010051001502                         |
    En de persoon met burgerservicenummer '000000048' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0599                              |
    En voor de persoon geldt ook het volgende gezag
    | naam                             | waarde    |
    | type                             | Voogdij   |
    | minderjarige.burgerservicenummer | 000000036 |
    En het gezag heeft de volgende derden
    | type         | burgerservicenummer |
    | BekendeDerde | 000000061           |
    | BekendeDerde | 000000062           |
    Als personen wordt gezocht met de volgende parameters
    | naam                             | waarde                                  |
    | type                             | ZoekMetAdresseerbaarObjectIdentificatie |
    | adresseerbaarObjectIdentificatie | 0599010051001502                        |
    | fields                           | gezag                                   |
    Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
    | naam                             | waarde    |
    | type                             | Voogdij   |
    | minderjarige.burgerservicenummer | 000000036 |
    En heeft 'gezag' een 'derde' met de volgende gegevens
    | type         | burgerservicenummer |
    | BekendeDerde | 000000061           |
    En heeft 'gezag' een 'derde' met de volgende gegevens
    | type         | burgerservicenummer |
    | BekendeDerde | 000000062           |

  Scenario: voogdij met meerdere bekende derden
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0599                 | 0599010051001502                         |
    En de persoon met burgerservicenummer '000000048' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0599                              |
    En voor de persoon geldt ook het volgende gezag
    | naam                             | waarde    |
    | type                             | Voogdij   |
    | minderjarige.burgerservicenummer | 000000036 |
    En het gezag heeft de volgende derden
    | type         | burgerservicenummer |
    | BekendeDerde | 000000061           |
    | BekendeDerde | 000000062           |
    Als personen wordt gezocht met de volgende parameters
    | naam                | waarde                          |
    | type                | RaadpleegMetBurgerservicenummer |
    | burgerservicenummer | 000000048                       |
    | fields              | gezag                           |
    Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
    | naam                             | waarde    |
    | type                             | Voogdij   |
    | minderjarige.burgerservicenummer | 000000036 |
    En heeft 'gezag' een 'derde' met de volgende gegevens
    | type         | burgerservicenummer |
    | BekendeDerde | 000000061           |
    En heeft 'gezag' een 'derde' met de volgende gegevens
    | type         | burgerservicenummer |
    | BekendeDerde | 000000062           |
