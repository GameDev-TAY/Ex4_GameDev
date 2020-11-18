![WhatsApp Image 2020-11-04 at 08 44 05](https://user-images.githubusercontent.com/57855070/98078036-f4b04180-1e79-11eb-9bde-48b3d32a201f.jpeg)

This project was done as part of the "Computer Game Development" course at Ariel University.

You can see the assignment at the following link: 

https://github.com/gamedev-at-ariel/gamedev-5781/blob/master/04-unity-triggers/homework.pdf

#### First section:
In this section we had to download code from the lesson of spaceship game.
The link to the code we started from: https://github.com/gamedev-at-ariel

We really enjoyed this question so we chose to make 4 changes in the original code instead of 2. 

Before we start detailing we wanted to show you what the game looks like:
![ezgif com-gif-maker](https://user-images.githubusercontent.com/57855070/99536778-75f7f000-29b3-11eb-81f6-76eb76951362.gif)

***The changes made are:***

1.The shield is not on the screen at first, but occasionally appears at a random point. When the player collides with the shield, a circle is added around the player's spaceship. The color of the circle weakens from second to second until it disappears after 5 seconds.

**Code reference:**

> https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Bonuses/Shield.prefab
> https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Spawners/ShieldSpawner.prefab <br />
> The TimedSpawnerRandomBonus script is accepted as parameters:
> 1. object for spawning 
> 2. Time range for spawning
> 3. Gets the boundaries from the camera
> And spawns the object at a random time and position on the screen. <br />
> https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/2-spawners/TimedSpawnerRandomBonus.cs <br />
> The ShieldActivate script is in the player and the role of the script is to detect that the player has collided with a Shield object and then add the element of the fading  circle over time <br />
> https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/3-collisions/ShieldActivate.cs <br />
> In the ShieldThePlayer script the trigger of the colliders is activated as soon as it recognizes that the player has touched it then it activates the shield <br />
> https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/3-collisions/ShieldThePlayer.cs <br />

The red arrow indicates the shield:

![image](https://user-images.githubusercontent.com/57855070/99460587-c8e09180-2938-11eb-9053-6a7bbf5c2ed1.png)

This how the spaceship looks like after it has collected the shield:

![image](https://user-images.githubusercontent.com/57855070/99460739-12c97780-2939-11eb-803e-2326f6769477.png)

2.We added a cannon that occasionally appears on the screen, at a random point. As the player collects the cannon, he can fire a larger and more powerful laser, for a few seconds. The cannon is disposable like the shield - disappears after the player collects it.
The difference between a regular laser and a powerful laser is that the stronger laser is bigger faster and is not destroyed after one hit on the enemy, meaning it can hit more than one enemy after being shot.

**Code reference:**

Same as the Shield
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/2-spawners/TimedSpawnerRandomBonus.cs


https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Bonuses/Cannon.prefab
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Spawners/CannonSpawner.prefab

the BigLaserShooter and the LaserShooter is components of the player.
https://github.com/GameDev-TAY/Ex4_GameDev/tree/main/Assets/Prefabs/Lasers

The CannonThePlayer script is located at the cannon object.
The role of the script is after an identification is made that the player has collected it and then he neutralizes the regular laser and then activates the more powerful laser(BigLaserShooter) for a set time.
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/2-spawners/BigLaserShooter.cs
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/3-collisions/CannonThePlayer.cs

The red arrow indicates the cannon:

![image](https://user-images.githubusercontent.com/57855070/99461291-393be280-293a-11eb-8e15-7b9076ad1d50.png)

This how the Laser looks like after it the spaceship has collected the cannon:

![image](https://user-images.githubusercontent.com/57855070/99461614-c8e19100-293a-11eb-91ef-91bec6232c7f.png)

3.The player's spaceship is not destroyed immediately when he collides with the enemy, but he has 3 "hit points" at the beginning of the game.
In addition we have added that it will be possible to collect "life" during the game by collecting hearts. It is important to note that if a player has 3 "hit points" then he will not be able to collect the hearts.

**Code reference:**

Same as the Shield
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/2-spawners/TimedSpawnerRandomBonus.cs

The HealthSystem component is in the player.
It takes as a parameter the number of lives the player currently has.
Also the damge function is in it and is responsible for lowering the life of the player and reducing the player.
And if necessary also its destruction if it is disqualified.

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/3-collisions/HealthSystem.cs

Within the Health prefab there is a script called AddHealth whose roll is to add life to the player when the Health type objects recognize connection 
with the player This script increases the life of the player and increases his character. This only happens when the player's life is less than 3.
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Bonuses/Health.prefab
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/3-collisions/AddHealth.cs

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Spawners/HealthSpawner.prefab


The red arrow indicates the heart:

![image](https://user-images.githubusercontent.com/57855070/99462228-e3683a00-293b-11eb-82df-2c43aba38128.png)

4.Our original change was to create enemies of a different kind from the enemies that exist now, these enemies are chasing our player and trying to dismantle him. Each touch on the enemy lowers is life him one hit point.

**Code reference:**

The script is in the object chaserץ
The chaser's script is responsible for aiming the enemy's face to direct the player at a constant and changeable rotational speed that is obtained as a parameter.
In addition the role of the script is to move the enemy chasing the player at a movement speed that is accepted as a format.
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Prefabs/Enemies/EnemyChaser.prefab
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/1-movers/Chaser.cs

The enemy is as happy as the other enemies below code:
https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/2-spawners/TimedSpawnerRandom.cs

The red arrow indicates the new enemies:

![image](https://user-images.githubusercontent.com/57855070/99462975-7bb2ee80-293d-11eb-9331-97254adc1d55.png)

#### Second section:
In this section we were asked to add 3 different borderies to our game.
1. The first border is a flat world with visible borders, such as impassable walls.
We added walls in a random position and at a random time on the screen so that the player can not go through them just like a regular wall.
In order for the player movement to really be like in the real world we defined the rigid body component as dynamic and for the collisions to happen correctly all the triggers in the Collider component were activated in the other objects, the trigger in the player in the Collider component was not enable.

**Code reference:**

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/Boundaries/SpawnRandomWalls.cs

The red arrow indicates the wall:

![image](https://user-images.githubusercontent.com/57855070/99463531-a782a400-293e-11eb-9f3a-35308894289b.png)


2.A flat world with invisible borders means that when the enemies pass the bottom of the screen, they are destroyed and when the laser crosses the top of the screen - it is destroyed.
To understand our application to this section it is important to remember that the enemies and the laser use the same mover component.
Therefore, in order for the enemies and lasers to be destroyed after they leave a certain limit, we defined in the mover component that when they reach the camera + extra limits, they will be destroyed.
The reason we added extra to the range is because we wanted the Spawning that are out of camera range to be able to put the objects in the camera boundaries without being destroyed.
But on the other hand we wanted that when objects come out of the cemera limit will be destroyed.
To illustrate if the spawns are in the area of the black square we caused objects to be destroyed in the blue line.

**Code reference:**

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/1-movers/Mover.cs

![image](https://user-images.githubusercontent.com/57855070/99498891-c7d35280-2980-11eb-855c-8162a0afae45.png)

3.Round World - When the player reaches one side of the world, he appears on the other side.
We created this effect by exiting from one side and back from the other side in the same position only on the opposite side.
In order for the animation to work in a subdivision manner we moved the spaceship only when it was completely out of the camera realm.
We did this by accepting the boundaries of the spaceship and adding them to the position calculation.

**Code reference:**

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/Boundaries/ScreenWrap.cs

You can play the game here:

https://gamedev-tay.itch.io/spaceship

#### background:
We created a new material that uses a star image whose warp mode is in repeat and then we defined its shader as transparent and then we created a background object whose element is the material and then we added the ScrollBG script whose job is to change the offset of its material. We created two background objects and placed them in different places, sizes and speeds in order to create a three-dimensional movement effect.

![image](https://user-images.githubusercontent.com/57855070/99517716-5d2e1100-2998-11eb-8190-a36b5801e636.png)

https://github.com/GameDev-TAY/Ex4_GameDev/blob/main/Assets/Scripts/1-movers/ScrollBG.cs

#### Third section:

We created a game where a frog has to cross the road without getting hit by cars.
We created three lanes that simulated the road, and we created a spawner for each lane that schedules the object that represents the cars at some random time. We built a code that moves the cars in a continuous movement from right to left (or vice versa) and the player according to the input from the arrow keys. We used a trigger to check if the player was run over on the way, and another trigger to check if the player reached the other side successfully.
from more information read the readme of the project.

**Code reference:**

https://github.com/GameDev-TAY/JumperFrog

###### Note the code of this section in a separate repository.

You can play the game here:

https://gamedev-tay.itch.io/ju

![image](https://user-images.githubusercontent.com/57855070/99500757-74aecf00-2983-11eb-9c3d-5bbb5a1d6ab1.png)


