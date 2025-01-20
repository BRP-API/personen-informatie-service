# language: nl
@api
Functionaliteit: gezagsrelaties vragen met fields

  Regel: Het vragen van één of meerdere velden van 'gezag' levert alle velden van 'gezag' die van toepassing zijn op de persoon

    Abstract Scenario: gezag vragen met fields <fields> geeft alle van velden van alle soorten gezag van toepassing op de persoon
      Gegeven de persoon met burgerservicenummer '000000048' heeft de volgende gegevens
        | naam                                 | waarde          |
        | voornamen (02.10)                    | <voornamen>     |
        | adellijke titel of predicaat (02.20) |                 |
        | voorvoegsel (02.30)                  | <voorvoegsel>   |
        | geslachtsnaam (02.40)                | <geslachtsnaam> |
      En de persoon heeft een 'kind' met de volgende gegevens
        | burgerservicenummer (01.20) |
        |                   000000012 |
      En voor de persoon geldt het volgende gezag
        | naam                             | waarde                   |
        | type                             | EenhoofdigOuderlijkGezag |
        | minderjarige.burgerservicenummer |                000000012 |
        | ouder.burgerservicenummer        |                000000048 |
      En de persoon met burgerservicenummer '000000012' heeft de volgende gegevens
        | naam                                 | waarde                       |
        | voornamen (02.10)                    | <minderjarige.voornamen>     |
        | adellijke titel of predicaat (02.20) |                              |
        | voorvoegsel (02.30)                  | <minderjarige.voorvoegsel>   |
        | geslachtsnaam (02.40)                | <minderjarige.geslachtsnaam> |
        | geboortedatum (03.10)                | <minderjarige.geboortedatum> |
      Als personen wordt gezocht met de volgende parameters
        | naam                | waarde                          |
        | type                | RaadpleegMetBurgerservicenummer |
        | burgerservicenummer |                       000000048 |
        | fields              | <fields>                        |
      Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
        | naam                             | waarde                       |
        | type                             | EenhoofdigOuderlijkGezag     |
        | minderjarige.burgerservicenummer |                    000000012 |
        | minderjarige.naam.volledigeNaam  | <minderjarige.volledigeNaam> |
        | minderjarige.leeftijd            | <minderjarige.leeftijd>      |
        | ouder.burgerservicenummer        |                    000000048 |
        | ouder.naam.volledigeNaam         | <volledigeNaam>              |

      Voorbeelden:
        | fields                                     | voornamen       | voorvoegsel | geslachtsnaam | volledigeNaam           | omschrijving       | minderjarige.voornamen | minderjarige.voorvoegsel | minderjarige.geslachtsnaam | minderjarige.volledigeNaam | minderjarige.geboortedatum | minderjarige.leeftijd |
        | gezag                                      | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.type                                 | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.minderjarige                         | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.ouders                               | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.ouder                                | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.derden                               | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.minderjarige.burgerservicenummer     | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.ouder.burgerservicenummer            | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.derde.burgerservicenummer            | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.derden.burgerservicenummer           | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.ouders,gezag.ouder                   | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
        | gezag.type,gezag.minderjarige,gezag.ouders | Christina Maria |             | Maassen       | Christina Maria Maassen | zonder voorvoegsel | Tim                    |                          | Maassen                    | Tim Maassen                | vandaag - 17 jaar          |                    17 |
