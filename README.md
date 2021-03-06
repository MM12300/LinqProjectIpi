**2022 - MADEJSKI Matthieu / PERLES Raphaël**

Application console développé en C# .NET ayant pour but de faire une démonstration de Linq.

Choix de la langue anglaise pour concevoir l'application dans la mesure où les jeux de données exploités sont en anglais.

**Deux jeux de données :** 
- format XML : les personnage de l'univers de Star Wars
- format JSON : les missions spatiales

**COMMENT UTILISER L'APPLICATION :** 
Dézipper le dossier LinqPublish.
Utiliser le .exe présent dans ce dossier.
Si vous utilisez les fonctions d'export d'un format vers un autre autre (JSON/XML ou XML/JSON), les fichiers sera copié dans ce dossier dpeuis lequel le .exe est exécuté.

**Les menus de l'application :**
  - _Les missions spatiales depuis 1957 :_
    - 1- All space missions, permet d'afficher l'ensemble des missions spatiales depuis 1957
    - 2- Recent missions, permet d'afficher les missions récentes (moins de 10ans)
    - 3- Old missions, permet d'afficher les missions les plus anciennes (plus de 40ans)
    - 4- Search, recherche simple sur un champ avec des possibilités de tri
    - 5- Advanced search, permet d'effectuer une recherche sur deux chalmps simultanément
    - 6- Add mission, permet d'ajouter une mission au jeu de données
    - 7- Convert Json DataSet into XML, permet de convertir le fichier json en fichier xml
    - 8- Return to main menu, permet de retourner au menu principal

  - _Star Wars :_ 
    - All characters details, permet d'afficher les détails de tous les personnages présents dans le jeu de donnée. Les informations indisponibles (NA pour "Non-Available) ne          sont pas affichées
    - Search Mode, permet de chercher un personnage en fonction d'un critère et classe les résultats de la recherche en fonction d'un autre critère (différent du premier)
        les résultats sont classés par odre alphabétique (ou croissant si ce sont des valeurs numériques).
        - Indiquer le critère de recherche
        - Indiquer le mot-clef ou la valeur de votre recherche
        - Indiquer le critère de tri pour votre résultat
        - Confirmez puis visualisez le résultat
    - Characters by special traits, permet la recherche de personnage en fonction de caractéristiques spécifiques
        - The giants : size >= 190cm, recherche tous les grands personnages, dont la taille est supérieure à 1,90m.
        - The midgets : size <= 120cm, recherche tous les petits personnages, dont la taille est inférieure à 1,90m.
        - The light-ones : mass <= 50kg, recherche tous les personnages légers, dont la masse est inférieure à 50kg.
        - The big-ones : size >= 150kg, recherche tous les personnages lourds, dont la masse est supérieure à 150kg.
        - The elders : age >= 100 years old, recherche tous les vieux personnages, dont l'âge est supérieure à 100 ans.
    - Add a character : permet d'ajouter un personnage en détaillant chacun de ses caractéristiques. Un nouveau personnage a besoin au minimum d'un nom et d'une caractéristique.
    - Convert XML Dataset into JSON : permet de convertir le jeu de données du format .XML vers le format .JSON (stocké dans ./JSON)
    - Return to main menu : retour au menu principal
    
