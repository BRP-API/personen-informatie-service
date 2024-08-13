# language: nl

@proxy
Functionaliteit: geheimhouding: niet verstrekken van gegevens van een persoon aan derden

  Wanneer een consumer van de BRP API gegevens bevraagt van een persoon die geen toestemming heeft gegeven voor het verstrekken van zijn gegevens aan derden
  Dan wil de consumer hiervan worden geattendeerd middels een indicatie bij de gevraagde gegevens

Regel: indicatie geheim waarde 0 wordt niet geleverd

  Scenario: persoon die toestemming heeft gegeven voor het verstrekken van zijn gegevens aan derden, wordt geraadpleegd met burgerservicenummer
    Gegeven de persoon met burgerservicenummer '000000152' heeft de volgende gegevens
    | geslachtsnaam (02.40) | geboortedatum (03.10) |
    | Jansen                | 19630405              |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | naam                     | waarde |
    | indicatie geheim (70.10) | 0      |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | Jansen                              |
    | geboortedatum | 1963-04-05                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000152 |

Regel: indicatie geheim met waarde hoger dan 0 wordt vertaald naar geheimhoudingPersoonsgegevens waarde true en ongevraagd meegeleverd

  Abstract Scenario: persoon met indicatie geheim <waarde> en er wordt gevraagd om burgerservicenummer
    Gegeven de persoon met burgerservicenummer '000000152' heeft de volgende gegevens
    | geslachtsnaam (02.40) | geboortedatum (03.10) |
    | Jansen                | 19630405              |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | naam                     | waarde   |
    | indicatie geheim (70.10) | <waarde> |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | Jansen                              |
    | geboortedatum | 1963-04-05                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response een persoon met de volgende gegevens
    | naam                          | waarde    |
    | burgerservicenummer           | 000000152 |
    | geheimhoudingPersoonsgegevens | true      |

    Voorbeelden:
    | waarde |
    | 1      |
    | 2      |
    | 3      |
    | 4      |
    | 5      |
    | 6      |
    | 7      |
