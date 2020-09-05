# Plumbing

A game made in Unity where you need to keep the water moving and avoid obstacles

Itch.io page: https://oxygencraft.itch.io/plumbing

The game was made for the jam My First Game Jam Summer 2020 https://itch.io/jam/my-first-game-jam-summer-2020

# Game Info

You start with some water and you need to keep it moving and avoid it touching obstacles. If it does touch obstacles, you will lose water. When you lose all your water or no water particles are within the view of the camera, you lose.

The water is constantly moving forward. The water can also fly but this never occurs on its own and must be influenced to do so. You cannot physically move the water. Instead, you must influence the water's movement. You have influencing ability which is like currency for influencing water. If you have no influencing ability, you cannot influence the water. Influencing ability decreases slowly over time. Influencing ability decreases quickly while you are influencing water. The speed it decreases at depends on the influence you are currently using. You can gain influencing ability by colliding into obstacles but you will still lose water. The obstacle will slowly wear off and break when exposed to water. The water will perform random actions at random times while you are not influencing it. The water sometimes might ignore your influence.

There are three types of influences (from least expensive to most expensive):
Making the water jump, 
Controlling the speed of the movement (but the camera speed doesn't change), 
Making the water fly. 

You can destroy parts of the environment to help you but you have destruction heat. While you are destroying the environment, you are gaining destruction heat. The more destruction heat you have, the slower you will destroy the environment. When you reach max destruction heat, you will have to wait until destruction heat cools down completely before you can destroy the environment again. 

You also have a destruction limit which counts the amount environment you have destroyed within a certain timeframe. When the maximum is reached, you cannot destroy the environment until the destruction limit resets. The environment destruction limit reset time is 30 seconds. When you stop destroying the environment, the timer of 30 seconds start. After those 30 seconds have past, the destruction limit will reset back to 0. If you destroy the environment again within that 30 second timer, the timer will reset and you will have to wait 30 seconds again after you stop destroying again for the destruction limit to reset.
