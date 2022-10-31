# tower defense
## Eigen mechanic 1 (tower upgraden):
### als speler wil ik mijn torens sterker kunnen maken
### als speler wil ik kunnen zien dat mijn torens sterker zijn
### als programmeur wil ik eenvoudig nieuwe upgrades kunnen toevoegen

## Eigen mechanic 2 (minimap):
### als speler wil ik kunnen zien waar mijn enemies naartoe lopen 
### als speler wil ik een overzicht hebben van de locaties van de enemies 
### als programmeur wil ik dat als het pad veranderd dat het dan automatisch mee veranderd in de minimap
```mermaid
flowchart TD
    A((tower placed)) -->B(remove money)
    B --> C{are enemies in ranch}
    C -->|no| C
    C -->|yes 1| E(shoot)
    C -->|yes multiple| F(scan for the first)
    F -->E
    E -->A
