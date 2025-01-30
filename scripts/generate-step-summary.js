const fs = require('fs');
const path = require('path');
const { processFile } = require('./process-cucumber-file');

const outputFile = path.join(__dirname, './../test-reports/cucumber-js/personen/step-summary.txt');
fs.writeFileSync(outputFile, '', 'utf8');

const fileMap = new Map([
    ["./../test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt", "docs (zonder integratie)"],
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
]);

fileMap.forEach((caption, filePath) => {
    processFile(path.join(__dirname, filePath), outputFile, caption);
});