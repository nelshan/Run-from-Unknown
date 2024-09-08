Game Title: Run from Unknown

Genre: Horror, Puzzle

Platform: PC

1. Overview (Game Description)

"Run from Unknown" is a short, first-person survival horror game set in an abandoned building. The player takes on the role of an unnamed protagonist who must navigate through eerie and dangerous environments filled with unsettling puzzles, jump scares, and a terrifying creature hunting them. The core game mechanics focus on defenseless horror, where players have no means to fight back and must rely on stealth, puzzle-solving, and navigation to escape. The player’s ultimate goal is to find a way out while surviving through two distinct levels, each more terrifying than the last.

This project was developed as part of my final year in a bachelor's study, leveraging key tools and technologies such as Unity Engine, Blender, PlayFab, and Audacity, with some 3D assets sourced online.

2. Key Features

Defenseless Horror: The player is unable to fight back, creating tension and fear through avoidance and stealth.

Puzzles & Obstacles: A series of puzzles that increase in complexity and contribute to progressing through the game.

Multiple Levels and Scenes: 2 playable game levels and 6 total scenes, including login, menus, and credit scenes.

Authentication System: PlayFab-powered login system that handles user authentication.

Atmospheric Sound Design: A fully immersive soundscape with ambient noise, horror sound effects, and jump scares designed to keep the player on edge.

AI-Driven Monster: A terrifying creature that stalks the player, implemented using Unity’s NavMesh Agent for intelligent pathfinding and player detection.

3. Story and Setting

The player awakens in an unfamiliar, dark building. Without any knowledge of how they got there, they must navigate a series of creepy and claustrophobic floors, each with its unique set of dangers and eerie atmosphere. A looming creature stalks them through the levels, adding constant pressure. The player will have to solve puzzles, unlock doors, and avoid deadly traps in a race against time to escape before they are caught.

4. Game Mechanics

4.1. Player Controls

Movement: WASD keys for movement and mouse for camera control.

Interactions: Players can interact with objects (doors, keys, etc.) by clicking the left mouse button.

Inventory: Players can collect and use key items to progress through locked areas.

4.2. Level Design

The game is split into two major levels, each with a distinct environment and set of challenges.

Level 1:

The player starts on Floor 1 of an abandoned building, progressing through a series of increasingly dangerous and bizarre floors. The level design emphasizes puzzle-solving and exploration:

Floor Progression: Each floor contains locked doors, puzzles, and traps that prevent the player from backtracking.

Puzzles: Simple environmental puzzles, such as finding keys to unlock doors.

Jump Scares: Sudden scares triggered by player actions, like entering specific rooms or interacting with objects.

Level 2:

A maze-like environment where the player must not only solve puzzles but also evade the creature actively hunting them:

Chase Sequences: A monster relentlessly follows the player, making the gameplay tense and fast-paced.

Final Puzzle: Players must find a hidden password to escape, adding to the pressure of being chased.

5. Game World

5.1. Visual Design

The world of "Run from Unknown" is designed to be claustrophobic and immersive. Low lighting, detailed textures, and eerie visual elements heighten the tension.


Environment: Dark corridors, flickering lights, broken furniture, and mysterious objects scattered across the floors.

Lighting: Dynamic lighting plays a significant role, with flashlight mechanics to illuminate dark areas and create tension through limited visibility.

5.2. Sound Design

Sound plays a critical role in establishing the atmosphere. From the subtle creaks of doors to sudden loud noises that accompany jump scares, the soundscape is designed to unsettle the player.

Ambiance: Creepy background music, random distant noises, and footsteps create a feeling of constant dread.

Audio Triggers: Sounds triggered by certain player actions, such as unlocking doors or triggering specific areas.

6. Game Levels

6.1. Level 1 (Floors 1-8)

Floor 1: The starting point. The player explores basic interactions like opening doors.

Floor 2: The player encounters locked doors and finds a flashlight to navigate the dark areas.

Floor 3: Features the first major jump scare and locked doors. The player finds a key to continue to the next floor.

Floor 4: Adds environmental details such as an old radio and cabinets. When triggered, eerie sounds play, and a door unlocks to proceed.

Floor 5-6: A combination of jump scares and puzzles. Players find another key after surviving jump scares to proceed to the next set of floors.

Floor 7: A long, eerie hallway with walls that close behind the player as they move forward.

Floor 8: The final floor, features a hallway with red lights and a dramatic chase sequence that ends with the player attempting to open a door while a monster approaches.

6.2. Level 2 (The Maze)

The second level transitions to a maze-like structure where the player is hunted by the creature.

Monster AI: The creature hunts the player using Unity’s NavMesh system, changing states from stalking to chasing based on proximity and visibility.

Puzzle: The player must explore the maze to find a password, all while avoiding the monster. Successfully solving this puzzle leads to the game's final jump scare and conclusion.

7. Technology and Tools Used

Unity Engine: Core development of the game, including level design, lighting, and AI.

Blender: Created and customized 3D models used for the game environment and props.

PlayFab SDK: Implemented the authentication system, allowing players to create accounts and log in through the Login Menu Scene.

Audacity: Used to create and edit sound effects and atmospheric audio.

NavMesh: Integrated AI pathfinding for the monster to dynamically follow and chase the player.

8. Code Examples

8.1. Player Authentication with PlayFab

This system allows users to create accounts, log in, and save progress. It uses Unity’s UI system to handle user input, and PlayFab SDK handles backend account management.

// Simplified example of PlayFab user login
PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest(){
    Email = emailAddress,
    Password = password
    },
    request => {
        Debug.Log($"Successful Account Login: {emailAddress}");
        SceneManager.LoadScene("Main Menu");
    },
    error => {
        Debug.Log($"Unsuccessful Account Login: {emailAddress} \n {error.ErrorMessage}");
    });

8.2. Monster AI with NavMesh

The AI that controls the monster switches between a stalking state and a chase state, depending on the player’s proximity and visibility.

// Basic AI behavior switching between stalking and chasing
void Update() {
    switch (state) {
        case BehaviorState.Stalking:
            if (CanSeePlayer()) {
                state = BehaviorState.Chasing;
                agent.speed = chaseSpeed;
            }
            break;
        case BehaviorState.Chasing:
            if (!CanSeePlayer()) {
                state = BehaviorState.Stalking;
                agent.speed = stalkSpeed;
            }
            break;
    }
}

9. Conclusion

“Run from Unknown” is a thrilling first-person horror experience, showcasing gameplay mechanics that emphasize fear, tension, and problem-solving. By blending immersive sound design, creative-level architecture, and intelligent AI, this game aims to create a chilling atmosphere and an engaging gameplay experience.
