#language: nl

@proxy
Functionaliteit: leveren 'indicatie vastgesteld verblijft niet op adres' test combinatie adressering en verblijfplaats


  Regel: aanduiding in onderzoek waarde '089999' wordt geleverd als indicatieVastgesteldVerblijftNietOpAdres adressering veld en alle geleverde adresregel velden zijn in onderzoek

    Abstract Scenario: gevraagde persoon verblijft niet meer op het geregistreerde adres en één adresregel veld wordt gevraagd
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10)       | huisnummer (11.20) | postcode (11.60) | woonplaats (11.70) |
      | 0518                 | Jonkheer van Riemsdijkln | 88                 | 2583XL           | Scheveningen       |
      En de persoon met burgerservicenummer '000000152' is ingeschreven op adres 'A1' met de volgende gegevens
      | aanduiding in onderzoek (83.10) | datum ingang onderzoek (83.20) |
      | 089999                          | 20020701                       |
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                          |
      | type                | RaadpleegMetBurgerservicenummer |
      | burgerservicenummer | 000000152                       |
      | fields              | <groep>.<veld>                  |
      Dan heeft de response een persoon met alleen de volgende 'adressering' gegevens
      | naam                                                       | waarde      |
      | <veld>                                                     | <waarde>    |
      | indicatieVastgesteldVerblijftNietOpAdres                   | true        |
      | inOnderzoek.<veld>                                         | true        |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.type        | Datum       |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.datum       | 2002-07-01  |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.langFormaat | 1 juli 2002 |

      Voorbeelden:
      | groep                 | veld        | waarde                      |
      | adressering           | adresregel1 | Jonkheer van Riemsdijkln 88 |
      | adressering           | adresregel2 | 2583 XL  SCHEVENINGEN       |
      | adresseringBinnenland | adresregel1 | Jonkheer van Riemsdijkln 88 |
      | adresseringBinnenland | adresregel2 | 2583 XL  SCHEVENINGEN       |
  
    Scenario: gevraagde persoon verblijft niet meer op het geregistreerde adres en meerdere adresregel velden wordt gevraagd
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10)       | huisnummer (11.20) | postcode (11.60) | woonplaats (11.70) |
      | 0518                 | Jonkheer van Riemsdijkln | 88                 | 2583XL           | Scheveningen       |
      En de persoon met burgerservicenummer '000000152' is ingeschreven op adres 'A1' met de volgende gegevens
      | aanduiding in onderzoek (83.10) | datum ingang onderzoek (83.20) |
      | 089999                          | 20020701                       |
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                                          |
      | type                | RaadpleegMetBurgerservicenummer                 |
      | burgerservicenummer | 000000152                                       |
      | fields              | adressering.adresregel1,adressering.adresregel2 |
      Dan heeft de response een persoon met alleen de volgende 'adressering' gegevens
      | naam                                                       | waarde                      |
      | adresregel1                                                | Jonkheer van Riemsdijkln 88 |
      | adresregel2                                                | 2583 XL  SCHEVENINGEN       |
      | indicatieVastgesteldVerblijftNietOpAdres                   | true                        |
      | inOnderzoek.adresregel1                                    | true                        |
      | inOnderzoek.adresregel2                                    | true                        |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.type        | Datum                       |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.datum       | 2002-07-01                  |
      | inOnderzoek.datumIngangOnderzoekVerblijfplaats.langFormaat | 1 juli 2002                 |


  Regel: indicatieVastgesteldVerblijftNietOpAdres adressering veld wordt alleen geleverd wanneer ten minste één adresveld wordt gevraagd
    indicatieVastgesteldVerblijftNietOpAdres wordt geleverd wanneer ten minste één van de volgende velden gevraagd zijn in fields:
    - adresssering.adresregel1
    - adresssering.adresregel2
    - adresssering.adresregel3
    - adresssering.land

    Abstract Scenario: gevraagde persoon verblijft niet meer op het geregistreerde adres en een aanschrijfnaam van adressering wordt gevraagd en ook een veld van verblijfplaats
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10)       | huisnummer (11.20) | postcode (11.60) | woonplaats (11.70) |
      | 0518                 | Jonkheer van Riemsdijkln | 88                 | 2583XL           | Scheveningen       |
      En de persoon met burgerservicenummer '000000012' heeft de volgende gegevens
      | naam                           | waarde      |
      | voornamen (02.10)              | Robin Melle |
      | voorvoegsel (02.30)            | van         |
      | geslachtsnaam (02.40)          | Puffelen    |
      | geslachtsaanduiding (04.10)    | M           |
      | aanduiding naamgebruik (61.10) | E           |
      En de persoon is ingeschreven op adres 'A1' met de volgende gegevens
      | aanduiding in onderzoek (83.10) | datum ingang onderzoek (83.20) |
      | 089999                          | 20020701                       |
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                                                |
      | type                | RaadpleegMetBurgerservicenummer                       |
      | burgerservicenummer | 000000012                                             |
      | fields              | adressering.<fields veld>,verblijfplaats.functieAdres |
      Dan heeft de response een persoon met alleen de volgende 'adressering' gegevens
      | naam            | waarde             |
      | <geleverd veld> | <geleverde waarde> |
      En heeft de persoon de volgende 'verblijfplaats' gegevens
      | naam                                         | waarde      |
      | type                                         | Adres       |
      | functieAdres.code                            | W           |
      | functieAdres.omschrijving                    | woonadres   |
      | indicatieVastgesteldVerblijftNietOpAdres     | true        |
      | inOnderzoek.type                             | true        |
      | inOnderzoek.functieAdres                     | true        |
      | inOnderzoek.datumIngangOnderzoek.type        | Datum       |
      | inOnderzoek.datumIngangOnderzoek.datum       | 2002-07-01  |
      | inOnderzoek.datumIngangOnderzoek.langFormaat | 1 juli 2002 |

      Voorbeelden:
      | fields veld           | geleverd veld         | geleverde waarde          |
      | aanhef                | aanhef                | Geachte heer Van Puffelen |
      | aanschrijfwijze       | aanschrijfwijze.naam  | R.M. van Puffelen         |
      | gebruikInLopendeTekst | gebruikInLopendeTekst | de heer Van Puffelen      |
