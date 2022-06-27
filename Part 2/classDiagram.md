# Class Diagram

## User

Une première classe user sera présente. Cette classe comprendra toutes les informations sur l'utilisateur afin de lui permettre la meilleure expérience possible. Les "goal" permettent de trier et de proposer les exercices les plus adaptés à ce que recherche l'utilisateur. Le poids, la taille permet à l'utilisateur de suivre son évolution au fil du temps. 


## Sport

Est une classe abstraite, elle comporte les attributs génériques / communs entre la classe Program & Exercice. Elle permet à ses classes héritières Program et Exercice de ne pas avoir besoin de redéfinir certains attributs tel que le nom, la difficulté, l'image et une bouléen qui permet de savoir si il appartient aux favoris ou non, qui est modifié par la méthode addFavorites.

## Exercice

Cette classe hérite de sport et possède en plus une description (chaine de caractère). De plus, un exercice est composé de 2 listes: une pour les muscles et une autre pour les types de l'exercice

## Muscles 

est une énumération des différents muscles qui peuvent etre sélectionnés pour les exercices

## Types 

est une énumération des différents types qui peuvent etre sélectionnés pour les exercices

## Program

Tout comme Exercice, cette classe hérite de Sport, elle possède une durée ainsi qu'un type et la zone travaillé. Cette classe possède également une liste d'exercice. La méthode totalTime permet de calculer la durée cumulée des exercices. Le temps repos et le temps d'exercice permet de définir le temps des exos et de repos et ainsi créer l'entrainement

