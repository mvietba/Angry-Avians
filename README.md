# Angry-Avians
This is a solution to the 1st assignment from the course **CS-E4002 Virtual and Augmented Reality**,  Aalto University.

Student: **Viet Ba, Mai**.

Mail: <firstname_without_space>.<lastname>@aalto.fi

Developed with Unity3D version 2017.3.0f3 Personal on Windows 10.

## External in-game elements
### Free Unity Assets:
* Background,  background elements  & cannon body - Free 2D Adventure Beach Pack, Brutal 2D Adventure Mega Pack
* Crates - Dungeon Art Pack
* Avian skin - Birds Pack (Bird #4)
* Sound effects - Unity_Free_8bit_snd

### Other:
Cannon wheel: https://pngtree.com/freepng/wheel_745586.html

## Scenes
The game consists of two scenes:
* * WelcomeScene* - with game instructions, loads *GameScene* on clicking *START* button.
* *GameScene* - game level

## Instructions
* The player is a cute bird, Avian, who furiously destroys wood logs, crates and collects for points.
* Points differ between the type of object that was hit.
* Use **arrow keys** (▲ or ▼) to change the angle of the leaf cannon.
* Use **spacebar* to launch the cute, but slightly angry Avian.
* The longer the spacebar is held, the higher force is applied to Avian. Maximum force is set to 250, since there is not much changes beyond that.
* Press **ESC** to exit the application or restart the level  at any time.

## Functionalities in addition to required in the assignment
* Animations
* Player trail
* Sound effects
* Explosion effect
* Fun gameplay (?)

## Possible buggy behaviour
The game ends once Avian stops moving, which is done by checking whether *velocity.sqrMagnitude* is 0. Sometimes, however, it happens that the GameObject does not stop moving for a long time after destroying objects, hence the game does not end. It is recommended to use the ESC button to open the options to restart the game or exit the application in such case.

<!--- Project's Github repository: https://github.com/mvietba/Angry-Avians--->