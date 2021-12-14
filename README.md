# Winds-Of-Valgnar
Welcome to Winds of Valgnar, a first person fantasy RPG!

This ReadMe should give you an understanding of the game's philosophy and architecture.

1. Philosophy
	
2. Architecture

	a. Technologies:
		Unity Editor 2021.2.3f1
		Visual Studio
		Git
		Deploying on Windows 10+ with minor support for Mac and Linux
		
	b. The Player:

		The Player GameObject (and it's associated scripts) can be found in the "Loading" scene before the game starts and in the "DontDestroyOnLoad" scene while the game is running.
		The player consists of a camera, a capsule collider, and a model that is not rendered but which contains some basic animations and bones that objects such as weapons can be attached to.
		
		Below are the main scripts that comprise the "Player".

		CharacterController
		Camera
		Model
		Stats
			Major
			Minor
			Tertiary
		Inventory
		Equipment
		Journal
		Quests
		Abilities

		
	c. Zones:

		NPCS
		Items
		Lighting
		Terrain


	d. Saving and Loading:

		Player Data
		Zone Data
			Temporary Zone Data
			Permanent Zone Data

	e. GUI:

	f. Rendering:
