2022 - MADEJSKI Matthieu / PERLES Raphaël

Application console développé en C# .NET ayant pour but de faire une démonstration de Linq.

Pour lancer l'application, utiliser le .exe présent dans le dossier "application".

Choix de la langue anglaise pour concevoir l'application dans la mesure où les jeux de données exploités sont en anglais.

Deux jeux de données : 
- format XML : les personnage de l'univers de Star Wars
- format JSON : les missions spatiales

COMMENT UTILISER L'APPLICATION : 

Les menus de l'application :
  - Menu principal : 
  
    - Les missions spatiales depuis 1957 :
      1-
      2-
      3-
      4-
      
    - Star Wars : 
      1- All characters details, permet d'afficher les détails de tous les personnages présents dans le jeu de donnée.
      2 - Search Mode, permet de chercher un personnage en fonction d'un critère et classe les résultats de la recherche en fonction d'un autre critère (différent du premier)
          les résultats sont classés par odre alphabétique (ou croissant si ce sont des valeurs numériques).
          - Indiquer le critère de recherche
          - Indiquer le mot-clef ou la valeur de votre recherche
          - Indiquer le critère de tri pour votre résultat
          - Confirmez puis visualisez le résultat
      3 - Characters by special traits, permet la recherche de personnage en fonction de caractéristiques spécifiques
          - 1 - The giants : size >= 190cm, recherche tous les grands personnages, dont la taille est supérieure à 1,90m.
          - 2 - The midgets : size <= 120cm, recherche tous les petits personnages, dont la taille est inférieure à 1,90m.
          - 3 - The light-ones : mass <= 50kg, recherche tous les personnages légers, dont la masse est inférieure à 50kg.
          - 4 - The big-ones : size >= 150kg, recherche tous les personnages lourds, dont la masse est supérieure à 150kg.
          - 5 - The elders : age >= 100 years old, recherche tous les vieux personnages, dont l'âge est supérieure à 100 ans.
      4 - Add a character : permet d'ajouter un personnage en détaillant chacun de ses caractéristiques. Si une caractéristique est inconnue, merci d'indiquer NA.
      5 - Convert XML Dataset into JSON : permet de convertir le jeu de données du format .XML vers le format .JSON (stocké dans ./JSON)
      6 - Return to main menu : retour au menu principal
    
