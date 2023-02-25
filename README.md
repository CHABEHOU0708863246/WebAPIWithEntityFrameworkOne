# WebAPIWithEntityFrameworkOne

1) Création du projet Web API

2) Implémenter notre classe de modèle de données dans un dossier "Models" puis on ajoute les propriété de la classe qui est en 
réalité ou qui represente les champs de notre table (nom de la classe) dans notre base de donnée.

3) Ajout des packages Nugget au projet pour utiliser EntityFrameworkCore
	a) Microsoft.EntityFrameworkCore
	b) Microsoft.EntityFrameworkCore.SqlServer
	c) Microsoft.EntityFrameworkCore.Tools

4) Ajouter une classe de contexte qui sera chargé de coordonnée les fonctionnalités, Entity Framework pour un modèle de données. Cette classe est créée en dérivant de la classe "Microsoft.EntityFrameworkCore.DbContext"

5) Ajouter une chaine de connexion aux fichier app.settings.json pour la relier en local avec SQL server : 
"ConnectionStrings": {
    "DefaultConnection": "Server=(Nom du serveur mssql);Database=(nom de la base de donnée);User Id=sa;Password=1234; Trusted_Connection=True; Encrypt=False;"
  }

6) faire une injection de dependance : Maintenant, nous allons enregistrer notre contexte de base de données dans le conteneur IOC intégré dans le fichier program.cs

7) Création d’une base de données avec des migrations à l’aide de la fonctionnalité EF Core Migrations
Ouvrez Outils -> Gestionnaire de package NuGet > Console du Gestionnaire de package (PMC) et exécutez la commande suivante dans le Gestionnaire de package (PMC) : >>>>> Add-Migration Initial

La commande génère du code pour créer le schéma de base de données initial basé sur le modèle spécifié dans la classe MovieContext. L’argument Initial est le nom de la migration et n’importe quel nom peut être utilisé >>>>> Add-Migration

À l’étape suivante, exécutez la commande suivante dans le PMC :

>>>> Update-Database

La commande exécute la méthode dans le fichier Migrations/{time-stamp}_Initial.cs, qui crée la base de données 
>>>> Update-DatabaseUp

Vous verrez la base de données nouvellement créée dans votre MSSQL SERVER


8) Création d’un contrôleur d’API et de méthodes

Dans cette section, vous allez créer le contrôleur d’API Movies et y ajouter les méthodes, ainsi que tester ces méthodes.

Ajoutons d’abord le contrôleur. Cliquez avec le bouton droit sur le dossier Controller et sélectionnez Add -> Controller.. puis sélectionnez API Controller - Vide

La classe de votre Controller doit hérité de la classe "ControllerBase".

Merci a vous: plus d'info veullez me contacter au 00225 07 08 86 32 46 ou par mail : auxence.chabehou@gmail.com
