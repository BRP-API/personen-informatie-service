#language: nl

@proxy
Functionaliteit: gezagsrelaties vragen met fields


    Achtergrond:
      Gegeven de persoon met burgerservicenummer '000000048' heeft een 'kind' met de volgende gegevens
      | burgerservicenummer (01.20) |
      | 000000012                   |
      En de persoon heeft een 'kind' met de volgende gegevens
      | burgerservicenummer (01.20) |
      | 000000024                   |
      En de persoon heeft een 'partner' met de volgende gegevens
      | burgerservicenummer (01.20) |
      | 000000061                   |
      En voor de persoon geldt het volgende gezag
      | naam                             | waarde                   |
      | type                             | EenhoofdigOuderlijkGezag |
      | minderjarige.burgerservicenummer | 000000012                |
      | ouder.burgerservicenummer        | 000000048                |
      En voor de persoon geldt ook het volgende gezag
      | naam                             | waarde                    |
      | type                             | TweehoofdigOuderlijkGezag |
      | minderjarige.burgerservicenummer | 000000024                 |
      En het gezag heeft de volgende ouders
      | burgerservicenummer |
      | 000000048           |
      | 000000061           |
      En voor de persoon geldt ook het volgende gezag
      | naam                             | waarde           |
      | type                             | GezamenlijkGezag |
      | minderjarige.burgerservicenummer | 000000036        |
      | ouder.burgerservicenummer        | 000000061        |
      | derde.burgerservicenummer        | 000000048        |

  Regel: Het vragen van één of meerdere velden van 'gezag' levert alle velden van 'gezag' die van toepassing zijn op de persoon

    Abstract Scenario: gezag vragen met fields <fields> geeft alle van velden van alle soorten gezag van toepassing op de persoon
      Als personen wordt gezocht met de volgende parameters
      | naam                | waarde                          |
      | type                | RaadpleegMetBurgerservicenummer |
      | burgerservicenummer | 000000048                       |
      | fields              | <fields>                        |
      Dan heeft de response een persoon met een 'gezag' met de volgende gegevens
      | naam                             | waarde                   |
      | type                             | EenhoofdigOuderlijkGezag |
      | minderjarige.burgerservicenummer | 000000012                |
      | ouder.burgerservicenummer        | 000000048                |
      En heeft de persoon een 'gezag' met de volgende gegevens
      | naam                             | waarde                    |
      | type                             | TweehoofdigOuderlijkGezag |
      | minderjarige.burgerservicenummer | 000000024                 |
      En heeft 'gezag' een 'ouder' met de volgende gegevens
      | naam                | waarde    |
      | burgerservicenummer | 000000048 |
      En heeft 'gezag' een 'ouder' met de volgende gegevens
      | naam                | waarde    |
      | burgerservicenummer | 000000061 |
      En heeft de persoon een 'gezag' met de volgende gegevens
      | naam                             | waarde           |
      | type                             | GezamenlijkGezag |
      | minderjarige.burgerservicenummer | 000000036        |
      | ouder.burgerservicenummer        | 000000061        |
      | derde.burgerservicenummer        | 000000048        |

      Voorbeelden:
      | fields                                     |
      | gezag                                      |
      | gezag.type                                 |
      | gezag.minderjarige                         |
      | gezag.ouders                               |
      | gezag.ouder                                |
      | gezag.derde                                |
      | gezag.derden                               |
      | gezag.minderjarige.burgerservicenummer     |
      | gezag.ouders.burgerservicenummer           |
      | gezag.ouder.burgerservicenummer            |
      | gezag.derde.burgerservicenummer            |
      | gezag.derden.burgerservicenummer           |
      | gezag.ouders,gezag.ouder                   |
      | gezag.type,gezag.minderjarige,gezag.ouders |
