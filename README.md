# GameWiki
GameWiki is a database for videogames. It includes game developers, games, and game characters. 

The DeveloperEntity is the parent with GameEntity being its child and CharacterEntity being the child of GameEntity.

DeveloperEntity contains the Primary Key, Id, and properties Name, YearCreated, CEO, and a list of games that are connected to each developer. 

GameEntity contains the Priamry Key, Id, and properties of Name, Description, DevId (ForiegnKey), and list of characters that are connect to each game.

CharacterEntity contains an Id, name, character description, and game character is in.

Developer, Game, and Character all have the methods to create, read(all and by id), update, and delete. 
In addition to these, developer can be gotten alphabetically and games can be gotten by developer.

Contribution: 

Julia
- DeveloperEntity
- Developer Models
- DeveloperService / IDeveloperService
- DeveloperController

Chris
- Character Entity
- Character Models
- Character Services
- Character Controller

Rob
- Game Entity
- Game Models
- Game Service / IGameService
- ServiceController
