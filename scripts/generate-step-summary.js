const fs = require('fs');
const path = require('path');

const outputFile = path.join(__dirname, './../test-reports/cucumber-js/personen/step-summary.txt');
fs.writeFileSync(outputFile, '', 'utf8');

function processFile(inputPath, outputPath, caption) {
    const content = fs.readFileSync(inputPath, 'utf8');
    const lines = content.split('\n');
    const results = [];
    let footerLines = [];

    if (lines.length >= 4) {
        footerLines = lines.slice(-4);
    }

    let finalOutput = `#### ${caption}\n`;
    finalOutput += footerLines.join('\n') + '\n';

    lines.forEach((line) => {
        const match = line.match(/^\d+\) Scenario: .*# (.+:\d+)/);
        if (match) {
            results.push((results.length + 1) + ": " + match[1]);
        }
    });

    if (results.length > 0) {
        finalOutput += `<details>\n<summary>Bestandsnamen en regelnummers</summary>\n\n`;
        finalOutput += results.join('\n') + '\n';
        finalOutput += `\n</details>\n\n`;
    }

    fs.appendFileSync(outputPath, finalOutput, 'utf8');
}

const fileMap = new Map([
    ["./../test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt", "docs (zonder integratie)"],
    ["./../test-reports/cucumber-js/personen/test-result-zoeken-en-raadplegen-summary.txt", "zoeken en raadplegen"],
    ["./../test-reports/cucumber-js/personen/test-result-gezag-persoon-beperkt-summary.txt", "gezag persoon beperkt"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-beperkt-summary.txt", "persoon beperkt"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-summary.txt", "persoon"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-adressering-summary.txt", "adressering"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-europees-kiesrecht-summary.txt", "europees-kiesrecht"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geboorte-summary.txt", "geboorte"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-geheimhouding-summary.txt", "geheimhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezag-summary.txt", "gezag"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-gezagsverhouding-summary.txt", "gezagsverhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-immigratie-summary.txt", "immigratie"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-kind-summary.txt", "kind"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-leeftijd-summary.txt", "leeftijd"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-naam-summary.txt", "naam"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-nationaliteit-summary.txt", "nationaliteit"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-opschorting-bijhouding-summary.txt", "opschorting-bijhouding"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-ouder-summary.txt", "ouder"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-overlijden-summary.txt", "overlijden"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-partner-summary.txt", "partner"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-rni-summary.txt", "rni"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-uitsluiting-kiesrecht-summary.txt", "uitsluiting-kiesrecht"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfplaats-summary.txt", "verblijfplaats"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verblijfstitel-summary.txt", "verblijfstitel"],
    ["./../test-reports/cucumber-js/personen/test-result-persoon-verificatie-summary.txt", "verificatie"]
]);

fileMap.forEach((caption, filePath) => {
    processFile(path.join(__dirname, filePath), outputFile, caption);
});