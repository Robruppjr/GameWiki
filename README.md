# GameWiki

GameWiki is a database for videogames. It includes game developers, games, and game characters. 

The DeveloperEntity is the parent with GameEntity being its child and CharacterEntity being the child of GameEntity.

DeveloperEntity contains the Primary Key, Id, and properties Name, YearCreated, CEO, and a list of games that are connected to each developer. 

GameEntity contains the Primary Key, Id, and properties name, game description, and a ForiegnId DevId, and a list of characters that are connected to the each game.

CharacterEntity contains an Id, name, character description, and a gameId for the game the character is from.

Developer, Game, and Character all have the methods to create, read, update, and delete. 
In addition to these, developer can be gotten alphabetically.
...

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
-GameEntity
-GameModels
-GameService / IGameService
-GameController
