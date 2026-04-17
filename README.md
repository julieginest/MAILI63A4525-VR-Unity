# VR Restaurant - Unity XR Project - *"le café de l'île Nook"*

> équipe : Kinsey & Julie (scripts et "gameplay") - Sophie & Ambre (maquettes & design de la scène)



## Screenshots

<img width="1919" height="831" alt="image2" src="https://github.com/user-attachments/assets/dd5ccff7-a93a-464e-9ca4-2295638cda44" />
<img width="1918" height="838" alt="image1" src="https://github.com/user-attachments/assets/a4097e0c-31fb-48b2-a08d-5b4c04eca266" />



## Description

Application de réalité virtuelle développée sous Unity permettant d'**aménager librement une salle de restaurant** en environnement immersif. L'utilisateur peut faire apparaître des objets depuis un catalogue, les déplacer, les faire pivoter ou les supprimer, et réinitialiser la scène à tout moment.

Le projet tourne sur **Meta Quest** (build APK) et peut être testé en éditeur grâce au **XR Device Simulator**.



## Fonctionnalités implémentées

### Contenu principal
- **Scène extérieure / restaurant** avec sol, structures et décors (bord de mer)
- **Spawn d'objets** via un catalogue interactif :
  - Chaise
  - Table
  - Balle
  - Parasol
- **Interface catalogue** (ouverture / fermeture via touche `C`)
- **Interactions sur les objets** (en ciblant un objet) :
  - `G` — Grab (saisir / déplacer un objet)
  - `Q` / rotation — Faire pivoter l'objet de -45°
  - `Hold Delete` — Supprimer l'objet ciblé
  - `Backspace` — Reset complet de la scène

### Contenu secondaire
- **Environnement immersif** (bord de mer, végétation, relief montagneux)
- **Décors animés** (personnage animé dans la cabane)
- **Feedback visuel** lors du grab (highlight bleu de l'objet sélectionné)
- **Raycasting** pour cibler les objets à distance



## Contrôles

| Touche | Action |
|--------|--------|
| `G` | Grab — saisir un objet |
| `Q` | Rotate -45° |
| `Hold Delete` | Supprimer l'objet ciblé |
| `Backspace` | Reset la scène |
| `C` | Ouvrir / Fermer le catalogue |



## Stack technique

- **Moteur** : Unity 6
- **XR** : Unity XR Toolkit + XR Device Simulator
- **Langage** : C#
- **Cible** : Meta Quest (APK Android)
- **Pipeline de rendu** : URP (Universal Render Pipeline)



## Structure du projet

```
Assets/
├── Scenes/          # Scène principale
├── Scripts/         # Scripts C# (spawn, interaction, catalogue, reset...)
├── Materials/       # Matériaux et textures
├── Prefabs/         # Objets instanciables (chaise, table, balle, parasol...)
├── Settings/        # Paramètres URP / XR
└── Packages/        # Packages Unity importés
```



## Lancer le projet

1. Cloner le repo :
   ```bash
   git clone https://github.com/julieginest/MAILI63A4525-VR-Unity.git
   ```
2. Ouvrir avec **Unity 6** via Unity Hub
3. Ouvrir la scène principale dans `Assets/Scenes/`
4. Lancer en mode Play avec le **XR Device Simulator** activé pour tester sans casque

### Build APK (Meta Quest)
1. `File > Build Settings > Android`
2. Sélectionner la scène principale
3. `Build And Run`



## Note

L'utilisation du Casque VR pour lancer notre scene n'a pas fonctionné pendant la semaine de cours. 
Pour tester notre projet, nous avons utilisé le **XR Device Simulator** (d'où l'utilisation de contrôles clavier/touches)



## Ressources utilisées

- [Unity Asset Store](https://assetstore.unity.com)
- [Sketchfab](https://sketchfab.com/search?type=models)
- [Documentation Unity](https://docs.unity.com)
