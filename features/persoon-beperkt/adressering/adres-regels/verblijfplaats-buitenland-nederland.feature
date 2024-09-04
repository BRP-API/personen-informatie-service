# language: nl

@proxy
Functionaliteit: verblijfplaats categorie 13 met adres in Nederland en adressering wordt gevraagd

    Scenario: verblijfplaats in Nederland voor persoon ingeschreven in RNI
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende gegevens
      | geslachtsnaam (02.40) | geboortedatum (03.10) |
      | Maassen               | 19830526              |
      En de persoon is ingeschreven op een buitenlands adres met de volgende gegevens
      | naam                             | waarde          |
      | land adres buitenland (13.10)    | 6030            |
      | regel 1 adres buitenland (13.30) | Laantje 2       |
      | regel 2 adres buitenland (13.40) | 2222CD Ons Dorp |
      Als personen wordt gezocht met de volgende parameters
      | naam          | waarde                                                                                   |
      | type          | ZoekMetGeslachtsnaamEnGeboortedatum                                                      |
      | geslachtsnaam | Maassen                                                                                  |
      | geboortedatum | 1983-05-26                                                                               |
      | fields        | adressering.adresregel1,adressering.adresregel2,adressering.adresregel3,adressering.land |
      Dan heeft de response een persoon met de volgende 'adressering' gegevens
      | naam        | waarde          |
      | adresregel1 | Laantje 2       |
      | adresregel2 | 2222CD Ons Dorp |
