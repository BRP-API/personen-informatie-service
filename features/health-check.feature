#language: nl

@integratie
Functionaliteit: Health check endpoint van de Personen Informatie Service
  Als provider
  wil ik dat de Personen Informatie Service een health check endpoint heeft
  zodat ik kan controleren of de service beschikbaar is

  Scenario: Health check endpoint van de Personen Informatie Service is beschikbaar
    Wanneer een GET request wordt gedaan naar het health check endpoint van de Personen Informatie Service
    Dan is de response healthy
