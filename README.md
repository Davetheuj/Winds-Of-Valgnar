# Winds Of Valgnar
Welcome to Winds of Valgnar, a first person fantasy RPG!

# First Time Set-Up:

1. Download Unity Editor 2021.2.3f1
2. Clone this project to the directory of your choice
3. Open UnityHub and add the directory path as a new project
4. Open the Winds-Of-Valgnar project
5. Add Assets/Scenes/Entry/Gamestart.Unity to your active scenes

# Architecture
		
## The Player

The Player GameObject (and it's associated scripts) can be found in the "Loading" scene before 
the game starts and in the "DontDestroyOnLoad" scene while the game is running.
The player consists of a camera, a capsule collider, and a model that is not rendered but which 
contains some basic animations and bones that objects such as weapons can be attached to.

Below are the main scripts that comprise the "Player".

### CharacterController

### Camera

### Model
Mesh
Bones
Animations

### Stats

Major

Minor

Tertiary

### StatusController

### Inventory

### Equipment

### Journal

### Quests

### Abilities

### SoundControllers


		
## Zones

### NPCs
Model

Scripts

### Items

Model

Scripts

Inventory Image

### Terrain

Creation

### Lighting


## Saving and Loading

### Player Data

### Zone Data

Temporary Zone Data

Permanent Zone Data


## GUI


## Rendering
