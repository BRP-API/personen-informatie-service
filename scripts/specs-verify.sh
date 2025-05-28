#!/bin/bash

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt \
                -f summary \
                features/docs \
                -p UnitTest \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-integratie-summary.txt \
                -f summary \
                features/docs \
                -p Integratie \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-informatie-api.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-informatie-api-summary.txt \
                -f summary \
                features/docs \
                -p InfoApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-data-api.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-data-api-summary.txt \
                -f summary \
                features/docs \
                -p DataApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-gezag-api.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-gezag-api-summary.txt \
                -f summary \
                features/docs \
                -p GezagApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-gezag-api-deprecated.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-gezag-api-deprecated-summary.txt \
                -f summary \
                features/docs \
                -p GezagApiDeprecated \
                > /dev/null

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
                -p InfoApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-deprecated.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-deprecated-summary.txt \
                -f summary \
                features/raadpleeg-met-burgerservicenummer \
                features/zoek-met-adresseerbaar-object-identificatie \
                features/zoek-met-geslachtsnaam-en-geboortedatum \
                features/zoek-met-geslachtsnaam-voornamen-en-gemeente-van-inschrijving \
                features/zoek-met-nummeraanduiding-identificatie \
                features/zoek-met-postcode-en-huisnummer \
                features/zoek-met-straatnaam-huisnummer-en-gemeente-van-inschrijving \
                -p InfoApiDeprecated \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-summary.txt \
                -f summary \
                features/gezag-persoon-beperkt \
                -p InfoApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-deprecated.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-deprecated-summary.txt \
                -f summary \
                features/gezag-persoon-beperkt \
                -p InfoApiDeprecated \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-beperkt.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-beperkt-summary.txt \
                -f summary \
                features/persoon-beperkt \
                -p InfoApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-beperkt-deprecated.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-beperkt-deprecated-summary.txt \
                -f summary \
                features/persoon-beperkt \
                -p InfoApiDeprecated \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-summary.txt \
                -f summary \
                features/*.feature \
                features/persoon/*.feature \
                -p InfoApi \
                > /dev/null

npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-deprecated.json \
                -f summary:./test-reports/cucumber-js/personen/test-result-persoon-deprecated-summary.txt \
                -f summary \
                features/*.feature \
                features/persoon/*.feature \
                -p InfoApiDeprecated \
                > /dev/null

verify() {
    npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-$1.json \
                    -f summary:./test-reports/cucumber-js/personen/test-result-persoon-$1-summary.txt \
                    -f summary \
                    features/persoon/$1 \
                    -p InfoApi \
                    > /dev/null

    npx cucumber-js -f json:./test-reports/cucumber-js/personen/test-result-persoon-$1-deprecated.json \
                    -f summary:./test-reports/cucumber-js/personen/test-result-persoon-$1-deprecated-summary.txt \
                    -f summary \
                    features/persoon/$1 \
                    -p InfoApiDeprecated \
                    > /dev/null
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
