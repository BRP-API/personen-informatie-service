#language: nl

@proxy
Functionaliteit: Zoek met geslachtsnaam en geboortedatum

Regel: Geslachtsnaam (niet hooflettergevoelig) en geboortedatum zijn verplichte parameters. 

  Abstract Scenario: Zoek een persoon met zijn volledige geslachtsnaam en geboortedatum
    Gegeven de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) |
    | 19830526              | Maassen               | Pieter            |
    En de persoon met burgerservicenummer '000000025' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) | voorvoegsel (02.30) |
    | 19830526              | Maassen               | Jan Peter         | van                 |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam>                     |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 2 personen
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000024 |
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000025 |

    Voorbeelden:
    | geslachtsnaam |
    | Maassen       |
    | maassen       |
    | MAASSEN       |

  Abstract Scenario: Zoek een persoon met diakrieten in zijn geslachtsnaam
    Gegeven de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | geslachtsnaam (diakrieten) | voornamen (02.10) |
    | 19830526              | Kaster                | Käster                     | Albertus Johannes |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam>                     |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000024 |

    Voorbeelden:
    | geslachtsnaam |
    | Käster        |
    | Kaster        |

  Abstract Scenario: Zoek een persoon met een deel van zijn geslachtsnaam
    Gegeven de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) |
    | 19830526              | Maassen               | Pieter            |
    En de persoon met burgerservicenummer '000000025' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) | voorvoegsel (02.30) |
    | 19830526              | Maassen               | Jan Peter         | van                 |
    En de persoon met burgerservicenummer '000000026' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) |
    | 19830526              | Jansen                | Jan               |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam>                     |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 0 personen

    Voorbeelden:
    | geslachtsnaam |
    | Maas          |
    | jans          |
    | MAAS          |

  Scenario: Zoek een persoon wiens geslachtsnaam twee karakters lang is
    Gegeven de persoon met burgerservicenummer '000000026' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Os                    |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | os                                  |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000026 |

Regel: Optionele 'naam' parameters (niet hooflettergevoelig) kunnen worden toegevoegd om de zoek criteria aan te scherpen.

  Abstract Scenario: Zoek met volledige voornamen
    Gegeven de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) |
    | 19830526              | Maassen               | Pieter            |
    En de persoon met burgerservicenummer '000000025' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) | voorvoegsel (02.30) |
    | 19830526              | Maassen               | Jan Peter         | van                 |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam>                     |
    | voornamen     | <voornamen>                         |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde                |
    | burgerservicenummer | <burgerservicenummer> |

    Voorbeelden:
    | geslachtsnaam | voornamen | burgerservicenummer |
    | Maassen       | Pieter    | 000000024           |
    | maassen       | PIETER    | 000000024           |
    | MAASSEN       | pieter    | 000000024           |
    | maassen       | jan peter | 000000025           |

  Abstract Scenario: Zoek met volledig voorvoegsel
    Gegeven de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) |
    | 19830526              | Maassen               | Pieter            |
    En de persoon met burgerservicenummer '000000025' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) | voorvoegsel (02.30) |
    | 19830526              | Maassen               | Jan Peter         | van                 |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam>                     |
    | voorvoegsel   | <voorvoegsel>                       |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000025 |

    Voorbeelden:
    | geslachtsnaam | voorvoegsel |
    | Maassen       | van         |
    | maassen       | VAN         |
    | MAASSEN       | Van         |

Regel: De optionele 'geslacht' parameter (niet hooflettergevoelig) kan worden toegevoegd om de zoek criteria aan te scherpen.

  Abstract Scenario: Zoek met geslacht
    Gegeven de persoon met burgerservicenummer '000000027' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | geslachtsaanduiding (04.10) |
    | 19830526              | Aedel                 | V                           |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | Aedel                               |
    | geslacht      | <geslachtsaanduiding>               |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000027 |

    Voorbeelden:
    | geslachtsaanduiding |
    | v                   |
    | V                   |

Regel: De optionele 'inclusiefOverledenPersonen' parameter moet worden opgegeven om een overleden persoon te kunnen vinden

  Scenario: Zoek een overleden persoon
    Gegeven de persoon met burgerservicenummer '000000028' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Jansen                |
    En de persoon met burgerservicenummer '000000035' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Jansen                |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | naam                                 | waarde |
    | reden opschorting bijhouding (67.20) | O      |
    Als personen wordt gezocht met de volgende parameters
    | naam                       | waarde                              |
    | type                       | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam              | Jansen                              |
    | inclusiefOverledenPersonen | true                                |
    | geboortedatum              | 1983-05-26                          |
    | fields                     | burgerservicenummer                 |
    Dan heeft de response 2 personen
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000028 |
    En heeft de response een persoon met de volgende gegevens
    | naam                          | waarde    |
    | burgerservicenummer           | 000000035 |
    En heeft de persoon de volgende 'opschortingBijhouding' gegevens
    | naam               | waarde     |
    | reden.code         | O          |
    | reden.omschrijving | overlijden |

Regel: De optionele 'gemeenteVanInschrijving' parameter kan worden toegevoegd om de zoek criteria aan te scherpen

  Abstract Scenario: Zoek met gemeenteVanInschrijving
    Gegeven adres 'A1' heeft de volgende gegevens
    |gemeentecode (92.10) |
    | 0014|
    En adres 'A2' heeft de volgende gegevens
    |gemeentecode (92.10) |
    | 0015|
    Gegeven de persoon met burgerservicenummer '000000027' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Aedel                 |
    En de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0014                              |
    En de persoon met burgerservicenummer '000000028' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Aedel                 |
    En de persoon is ingeschreven op adres 'A2' met de volgende gegevens
    | gemeente van inschrijving (09.10) |
    | 0015                              |
    Als personen wordt gezocht met de volgende parameters
    | naam                    | waarde                              |
    | type                    | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam           | Aedel                               |
    | geboortedatum           | 1983-05-26                          |
    | gemeenteVanInschrijving | 0014                                |
    | fields                  | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000027 |

Regel: Voor de geslachtsnaam en voornamen parameters kan wildcard matching (niet hooflettergevoelig) worden toegepast.
      Er moet dan minimaal 3 letters (exclusief de wildcard "*" teken) worden opgegeven.
      De wildcard moet als laatste karakter worden opgegeven.
      De wildcard komt overeen met nul of meer (niet-spatie) karakters.

  Abstract Scenario: Zoek personen met "*" wildcard matching in geslachtsnaam
    Gegeven de persoon met burgerservicenummer '000000029' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Groen                 |
    En de persoon met burgerservicenummer '000000030' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Groot                 |
    En de persoon met burgerservicenummer '000000031' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) |
    | 19830526              | Groenlo               |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | <geslachtsnaam filter>              |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 3 personen
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000029 |
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000030 |
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000031 |

    Voorbeelden:
    | geslachtsnaam filter |
    | gro*                 |
    | Gro*                 |
    | GRO*                 |

  Abstract Scenario: Zoek personen met "*" wildcard matching in voornamen
    Gegeven de persoon met burgerservicenummer '000000025' heeft de volgende gegevens
    | geboortedatum (03.10) | geslachtsnaam (02.40) | voornamen (02.10) | voorvoegsel (02.30) |
    | 19830526              | Maassen               | Jan Peter         | van                 |
    Als personen wordt gezocht met de volgende parameters
    | naam          | waarde                              |
    | type          | ZoekMetGeslachtsnaamEnGeboortedatum |
    | geslachtsnaam | maassen                             |
    | voornamen     | <voornamen filter>                  |
    | geboortedatum | 1983-05-26                          |
    | fields        | burgerservicenummer                 |
    Dan heeft de response 1 persoon
    En heeft de response een persoon met de volgende gegevens
    | naam                | waarde    |
    | burgerservicenummer | 000000025 |

    Voorbeelden:
    | voornamen filter |
    | Jan*             |
    | jan*             |
    | JAN*             |

