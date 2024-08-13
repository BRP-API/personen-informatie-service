#language: nl

@proxy
Functionaliteit: Gezag Persoon beperkt: geboorte velden vragen met fields

    Abstract Scenario: 'geboortedatum (03.10)' wordt gevraagd met field pad '<fields>'
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
      | 0518                 | 0599010051001502                         |
      En de persoon met burgerservicenummer '000000152' heeft de volgende gegevens
      | naam                            | waarde                    |
      | geboortedatum (03.10)           | 19830526                  |
      En de persoon is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) |
      | 0518                              |
      Als personen wordt gezocht met de volgende parameters
      | naam                             | waarde                                  |
      | type                             | ZoekMetAdresseerbaarObjectIdentificatie |
      | adresseerbaarObjectIdentificatie | 0599010051001502                        |
      | fields                           | <fields>                                |
      Dan heeft de response een persoon met de volgende 'geboorte' gegevens
      | naam              | waarde      |
      | datum.type        | Datum       |
      | datum.datum       | 1983-05-26  |
      | datum.langFormaat | 26 mei 1983 |

      Voorbeelden:
      | fields                     |
      | geboorte.datum             |
      | geboorte.datum.type        |
      | geboorte.datum.datum       |
      | geboorte.datum.langFormaat |
