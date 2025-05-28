const fs = require('fs');
const path = require('path');
const { processFile } = require('./process-cucumber-file');

const outputFile = path.join(__dirname, './../test-reports/cucumber-js/personen/step-summary.txt');
fs.writeFileSync(outputFile, '', 'utf8');

const fileMap = new Map([
    ["./../test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt", "docs (zonder integratie)"],
    ["./../test-reports/cucumber-js/step-definitions/test-result-integratie-summary.txt", "docs (integratie)"],
    ["./../test-reports/cucumber-js/step-definitions/test-result-informatie-api-summary.txt", "docs informatie api context"],
    ["./../test-reports/cucumber-js/step-definitions/test-result-data-api-summary.txt", "docs data api context"],
    ["./../test-reports/cucumber-js/step-definitions/test-result-gezag-api-summary.txt", "docs gezag api context"],
    ["./../test-reports/cucumber-js/step-definitions/test-result-gezag-api-deprecated-summary.txt", "docs gezag api deprecated context"],

    ["./../test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-summary.txt", "zoeken en raadplegen"],
    ["./../test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-summary.txt", "gezag persoon beperkt"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-beperkt-summary.txt", "persoon beperkt"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-summary.txt", "persoon"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-adressering-summary.txt", "persoon adressering"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-europees-kiesrecht-summary.txt", "persoon europees kiesrecht"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geboorte-summary.txt", "persoon geboorte"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geheimhouding-summary.txt", "persoon geheimhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezag-summary.txt", "persoon gezag"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezagsverhouding-summary.txt", "persoon gezagsverhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-immigratie-summary.txt", "persoon immigratie"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-kind-summary.txt", "persoon kind"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-leeftijd-summary.txt", "persoon leeftijd"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-naam-summary.txt", "persoon naam"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-nationaliteit-summary.txt", "persoon nationaliteit"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-opschorting-bijhouding-summary.txt", "persoon opschorting bijhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-ouder-summary.txt", "persoon ouder"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-overlijden-summary.txt", "persoon overlijden"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-partner-summary.txt", "persoon partner"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-rni-summary.txt", "persoon rni"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-uitsluiting-kiesrecht-summary.txt", "persoon uitsluiting kiesrecht"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfplaats-summary.txt", "persoon verblijfplaats"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfstitel-summary.txt", "persoon verblijfstitel"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verificatie-summary.txt", "persoon verificatie"],

    ["./../test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-deprecated-summary.txt", "zoeken en raadplegen (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-deprecated-summary.txt", "gezag persoon beperkt (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-beperkt-deprecated-summary.txt", "persoon beperkt (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-deprecated-summary.txt", "persoon (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-adressering-deprecated-summary.txt", "persoon adressering (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-europees-kiesrecht-deprecated-summary.txt", "persoon europees kiesrecht (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geboorte-deprecated-summary.txt", "persoon geboorte (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geheimhouding-deprecated-summary.txt", "persoon geheimhouding (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezag-deprecated-summary.txt", "persoon gezag (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezagsverhouding-deprecated-summary.txt", "persoon gezagsverhouding (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-immigratie-deprecated-summary.txt", "persoon immigratie (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-kind-deprecated-summary.txt", "persoon kind (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-leeftijd-deprecated-summary.txt", "persoon leeftijd (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-naam-deprecated-summary.txt", "persoon naam (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-nationaliteit-deprecated-summary.txt", "persoon nationaliteit (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-opschorting-bijhouding-deprecated-summary.txt", "persoon opschorting bijhouding (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-ouder-deprecated-summary.txt", "persoon ouder (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-overlijden-deprecated-summary.txt", "persoon overlijden (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-partner-deprecated-summary.txt", "persoon partner (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-rni-deprecated-summary.txt", "persoon rni (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-uitsluiting-kiesrecht-deprecated-summary.txt", "persoon uitsluiting kiesrecht (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfplaats-deprecated-summary.txt", "persoon verblijfplaats (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfstitel-deprecated-summary.txt", "persoon verblijfstitel (deprecated)"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verificatie-deprecated-summary.txt", "persoon verificatie (deprecated)"],
]);

fileMap.forEach((caption, filePath) => {
    processFile(path.join(__dirname, filePath), outputFile, caption);
});