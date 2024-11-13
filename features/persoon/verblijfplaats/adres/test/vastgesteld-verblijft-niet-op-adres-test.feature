#language: nl

@proxy
Functionaliteit: leveren 'indicatie vastgesteld verblijft niet op adres' veld bij het vragen van verblijfplaats gegevens test

      Achtergrond:
        Gegeven adres 'A1' heeft de volgende gegevens
        | gemeentecode (92.10) | straatnaam (11.10) | huisnummer (11.20) | identificatiecode verblijfplaats (11.80) | identificatiecode nummeraanduiding (11.90) |
        | 0519                 | Spui               | 123                | 0599010000208579                         | 0599200000219678                           |
        En de persoon met burgerservicenummer '000000152' is ingeschreven op adres 'A1' met de volgende gegevens
        | aanduiding in onderzoek (83.10) | datum ingang onderzoek (83.20) | datum aanvang adreshouding (10.30) | datum ingang geldigheid (85.10) |
        | 089999                          | 20020701                       | 20000423                           | 20220222                        |


  Regel: aanduiding in onderzoek waarde '089999' wordt geleverd als indicatieVastgesteldVerblijftNietOpAdres verblijfplaats veld en alle geleverde verblijfplaats velden zijn in onderzoek

    Abstract Scenario: gevraagde persoon verblijft niet meer op het geregistreerde adres en <groep> veld <veld> wordt gevraagd
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                          |
      | type                | RaadpleegMetBurgerservicenummer |
      | burgerservicenummer | 000000152                       |
      | fields              | <groep>.<veld>           |
      Dan heeft de response een persoon met de volgende 'verblijfplaats' gegevens
      | naam                                         | waarde      |
      | type                                         | Adres       |
      | indicatieVastgesteldVerblijftNietOpAdres     | true        |
      | <veld>                                       | <waarde>    |
      | inOnderzoek.type                             | true        |
      | inOnderzoek.<veld>                           | true        |
      | inOnderzoek.datumIngangOnderzoek.type        | Datum       |
      | inOnderzoek.datumIngangOnderzoek.datum       | 2002-07-01  |
      | inOnderzoek.datumIngangOnderzoek.langFormaat | 1 juli 2002 |

      Voorbeelden:
      | groep                    | veld                             | waarde           |
      | verblijfplaats           | adresseerbaarObjectIdentificatie | 0599010000208579 |
      | verblijfplaats           | nummeraanduidingIdentificatie    | 0599200000219678 |
      | verblijfplaatsBinnenland | adresseerbaarObjectIdentificatie | 0599010000208579 |


    Abstract Scenario: gevraagde persoon verblijft niet meer op het geregistreerde adres en <groep> verblijfadres veld <veld> wordt gevraagd
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                          |
      | type                | RaadpleegMetBurgerservicenummer |
      | burgerservicenummer | 000000152                       |
      | fields              | <groep>.verblijfadres.<veld>           |
      Dan heeft de response een persoon met de volgende 'verblijfplaats' gegevens
      | naam                                                       | waarde      |
      | type                                                       | Adres       |
      | indicatieVastgesteldVerblijftNietOpAdres                   | true        |
      | inOnderzoek.type                                           | true        |
      | inOnderzoek.datumIngangOnderzoek.type                      | Datum       |
      | inOnderzoek.datumIngangOnderzoek.datum                     | 2002-07-01  |
      | inOnderzoek.datumIngangOnderzoek.langFormaat               | 1 juli 2002 |
      | verblijfadres.<veld>                                       | <waarde>    |
      | verblijfadres.inOnderzoek.<veld>                           | true        |
      | verblijfadres.inOnderzoek.datumIngangOnderzoek.type        | Datum       |
      | verblijfadres.inOnderzoek.datumIngangOnderzoek.datum       | 2002-07-01  |
      | verblijfadres.inOnderzoek.datumIngangOnderzoek.langFormaat | 1 juli 2002 |

      Voorbeelden:
      | groep                    | veld            | waarde |
      | verblijfplaats           | korteStraatnaam | Spui   |
      | verblijfplaats           | huisnummer      | 123    |
      | verblijfplaatsBinnenland | korteStraatnaam | Spui   |
      | verblijfplaatsBinnenland | huisnummer      | 123    |
