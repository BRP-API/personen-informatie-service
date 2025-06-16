# language: nl
@info-api
Functionaliteit: gezagsrelaties vragen met fields

  Regel: Het vragen van één of meerdere velden van 'gezag' levert alle velden van 'gezag' die van toepassing zijn op de persoon

    Abstract Scenario: gezag vragen met fields <fields> geeft alle van velden van alle soorten gezag van toepassing op de persoon
      Gegeven de minderjarige 'P1'
      * heeft de volgende gegevens
        | geslachtsnaam (02.40) | voornamen (02.10) | geboortedatum (03.10) |
        | Maassen               | Tim               | vandaag - 10 jaar     |
      En de meerderjarige 'P2'
      * heeft de volgende gegevens
        | geslachtsnaam (02.40) | voornamen (02.10) |
        | Pietersen             | Christina Maria   |
      En 'P1' heeft de volgende gezagsrelaties
      * eenhoofdig ouderlijk gezag over 'P1' met ouder 'P2'
      Als 'gezag' wordt gevraagd van personen gezocht met burgerservicenummer van 'P1'
      Dan heeft 'P1' de volgende gezagsrelaties
      * het gezag over 'P1' is eenhoofdig ouderlijk gezag met ouder 'P2'
      * heeft de minderjarige de volgende gegevens
        | naam.volledigeNaam | leeftijd |
        | Tim Maassen        |       10 |
      * heeft de ouder de volgende gegevens
        | naam.volledigeNaam        |
        | Christina Maria Pietersen |
