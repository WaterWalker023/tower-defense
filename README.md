# tower defense

## Mechanics
### plaatsen van torens
### wave susteem
### upgranden
### torens attack
### enemy kill = money 

graph TD
    A((tower placed)) -->B(remove money)
    B --> C{are enemies in ranch}
    C -->|no| C
    C -->|yes 1| E(shoot)
    C -->|yes multiple| F(scan for the first)
    F -->E
    E -->A
