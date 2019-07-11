# YellowTale

2D-BulletHell/RPG (Monogame C#)

https://jaemil.itch.io/yellowtale
https://www.youtube.com/watch?v=MLzTEgNlubM

## Installing

1. Install [Monogame 3.6](http://www.monogame.net/2017/03/01/monogame-3-6/) 
2. Install [Manaspace (Font)](https://www.dafont.com/manaspace.font)
3. Open the Project ("YellowTale.sln").

## Details

- You can find the documentation under "YellowTale Doku.pdf" (German).
- We also made a PowerPoint ("YellowTale.pptx").

## Project Description

- The main difference between a classical RPG and a Bullet-Hell-RPG is the combat system: 
It’s based on projectiles, shot by the player and the enemies and they can be dodged, manipulated, or even reflected.

- The player can choose between 3 Roles/Classes which have different abilities and properties.

- To choose the classes, we decided to use a menu-system which is built into the game, and you can access it by visiting a so called NPC (NPC = Non-PlayerCharacter).

- For comfort purposes, the NPC is located directly at the beginning of the game, but don’t worry, you’re still able to visit it even after you left the house in which it’s located at. The Menu includes 3 Buttons which let you choose your desired class. You can also upgrade your abilities for each class, once you’ve collected enough credits throughout the game.

- The house itself is located in the central of the entire map (Also called the “Town” Map) , which you can always re-enter after passing each biome.

- There are 3 biomes in total, the Forest-biome, the Ice-biome, and the Lavabiome. Each of them consists of 3 standard maps and 3 dungeon maps.

- The purpose of the standard maps is it to show the player the current conditions of the biome and prepare him for combat in the dungeon maps.

- The last dungeon map of every biome includes a boss fight. If the player manages to defeat the boss, he is rewarded with a treasure chest, which contains experience points - to unlock abilities -, credits -to upgrade abilities at the Shop-NPC - and food - to heal -.

- Every ability has 3 skill points, which indict the current strength of the ability, by upgrading the ability it deals more damage.

- The player loses HP (HP = Health Points) every time he gets hit by a hostile projectile, once the player loses all his HP he dies and gets a menu to choose between 3 actions. You can either quit the game, return to the home menu, or try
again. If you choose to try again, you respawn in the same map you died in previously, but you only have half the amount of your maximum HP.

## MapEditor

All maps were built with the Map Editor

## Assets we used

- [Manaspace](https://www.dafont.com/manaspace.font)

- [DungeonTileset](https://0x72.itch.io/dungeontileset-ii)

## Authors

* **Emil Hopf** - [Website](http://www.jaemil.de/)
* **Matthias Wohland** - [YouTube](https://www.youtube.com/user/mwohland23)
* **Benjamin Simikic** - [YouTube](https://www.youtube.com/user/Jimmongaming)

## License

This project is licensed under the MIT License.
