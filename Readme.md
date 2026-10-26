# Exo 03 - Final 📽️
Exo basé sur la demo ASP.Net MVC 04 (Séance de cinéma).  
Ajouter la gestion des utilisateurs dans l'application.

## Fonctionnalité

### Gestion des films
- Ajouter du film
- Afficher 
	- Détail d'un films
	- Liste avec pagination
- Rechercher par critere (Titre, Réal, Genre)
- Modifier les détails d'un film
- Support du Cinecheck

### Gestion de séance
- Ajouter, Supprimer une séance
- Afficher
	- Liste par jour
	- Liste par film
- Annuler une séance
- [Bonus] Gestion des "Avant-Première"
	- Planification autorisé cinq jours avant la date de sortie
	- Le tag « Séance Spéciale » apparait automatiquement

### Gestion de l'utilisateur
- Connection d'utilisateur
- Création d'un nouveau compte
- Gestion des roles : User, Modo, Admin
- [Bonus] Envoyer un mail de validation à la création d'un compte
    - Pour l'envoi de mail, utiliser le package : https://github.com/jstedfast/MailKit 
	- Pour les tests utilise l'application Smtp4Dev : https://github.com/rnwood/smtp4dev

## Détails de la gestion des roles

### Modo & Admin :
- Ajouter du film
- Modifier les détails d'un film
- Ajouter une séance
- Annuler une séance

### Admin :
- Supprimer une séance

### Connecté : 
- Afficher les séances
- Rechercher de film par critere

### Non connecté :
- Page d'accueil
- Liste de films

## Architecture de l'application
Application Monolithe en couche

### Description des couches

#### WebApp
Application Web en ASP.Net MVC. \
→ Controllers, Views, ViewModels/FormModels

#### BLL _(Business Logic Layer)_
Gestion des règles métiers. \
→ Services, Models

#### DAL _(Data Access Layer)_
Gestion des données (DB, WebAPI, Fichier, etc...). \
→ Repositories, Entities
