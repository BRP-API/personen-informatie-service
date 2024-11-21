#!/bin/bash

PARAMS="{ \
    \"apiUrl\": \"http://localhost:5002/haalcentraal/api\", \
    \"logFileToAssert\": \"./test-data/logs/personen-informatie-service.json\", \
    \"oAuth\": { \
        \"enable\": false \
    } \
}"

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt \
                -f summary \
                features/docs \
                --tags "not @skip-verify" \
                --tags "not @integratie"

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-summary.txt \
                -f summary \
                features/raadpleeg-met-burgerservicenummer \
                features/zoek-met-adresseerbaar-object-identificatie \
                features/zoek-met-geslachtsnaam-en-geboortedatum \
                features/zoek-met-geslachtsnaam-voornamen-en-gemeente-van-inschrijving \
                features/zoek-met-nummeraanduiding-identificatie \
                features/zoek-met-postcode-en-huisnummer \
                features/zoek-met-straatnaam-huisnummer-en-gemeente-van-inschrijving \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS"

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-summary.txt \
                -f summary \
                features/gezag-persoon-beperkt \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS"

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-beperkt.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-beperkt-summary.txt \
                -f summary \
                features/persoon-beperkt \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS"

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-summary.txt \
                -f summary \
                features/*.feature \
                features/persoon/*.feature \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS"

verify() {
    npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-$1.json \
                    -f summary:./test-reports/cucumber-js/personen/test-result-persoon-$1-summary.txt \
                    -f summary \
                    features/persoon/$1 \
                    --tags "not @skip-verify" \
                    --world-parameters "$PARAMS"
}

verify "adressering"
verify "europees-kiesrecht"
verify "geboorte"
verify "geheimhouding"
verify "gezag"
verify "gezagsverhouding"
verify "immigratie"
verify "kind"
verify "leeftijd"
verify "naam"
verify "nationaliteit"
verify "opschorting-bijhouding"
verify "ouder"
verify "overlijden"
verify "partner"
verify "rni"
verify "uitsluiting-kiesrecht"
verify "verblijfplaats"
verify "verblijfstitel"
verify "verificatie"
