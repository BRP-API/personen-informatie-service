#language: nl

@info-api
Functionaliteit: gezagsrelaties vragen met fields

  Scenario: geleverde persoon heeft eenhoofdig ouderlijk gezag
    Gegeven de minderjarige 'P1'
    En de meerderjarige 'P2'
    En 'P1' heeft de volgende gezagsrelaties
    * eenhoofdig ouderlijk gezag over 'P1' met ouder 'P2'
    Als 'gezag' wordt gevraagd van personen gezocht met burgerservicenummer van 'P1'
    Dan heeft 'P1' de volgende gezagsrelaties
    * het gezag over 'P1' is eenhoofdig ouderlijk gezag met ouder 'P2'

  Scenario: geleverde persoon heeft gezamenlijk ouderlijk gezag
    Gegeven de minderjarige 'P1'
    En de meerderjarige 'P2'
    En de meerderjarige 'P3'
    En 'P1' heeft de volgende gezagsrelaties
    * gezamenlijk ouderlijk gezag over 'P1' met ouder 'P2' en ouder 'P3'
    Als 'gezag' wordt gevraagd van personen gezocht met burgerservicenummer van 'P1'
    Dan heeft 'P1' de volgende gezagsrelaties
    * het gezag over 'P1' is gezamenlijk ouderlijk gezag met ouder 'P2' en ouder 'P3'
