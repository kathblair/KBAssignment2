How to run Kath's Assignment 2:

1. Print out nest.jpg
2. load KBlairAssignment2/KBlairAssignment2 folder in Unity 
3. Build and run on an Android device with a compass and gyroscope
4. Place the nest image in front of the camera, needs to be fairly visible (not at too steep of an angle).

What happens?
- the bird starts moving around the corners of the tracker
- when you have the device in "FaceUp" orientation, the bird ruffles its feathers (I called the orientation "mode" in the video)
- it returns to idle when you put the device in another orientation
- when you point the top of the device to the southeast (IE, if the compass heading is between 90 and 180), the cardinal takes on a golden hue
-- (the base colour of the material on the game object changes from grey to yellow, and goes back otherwise)
-- I chose southeast because that's the direction actual cardinals are from Calgary.
- when the bird gets to the last corner of the nest, it sings.

Video: https://www.youtube.com/watch?v=hETVpaM0IVw

The bird will keep moving through its steps if the app loses the tracker, but it only repeats once.

Credits:
I used this pacakge of birds: https://assetstore.unity.com/packages/3d/characters/animals/living-birds-15649
And based this on the EasyAR MultiTracker Example we were working on in tutorial.
Nest image from: https://commons.wikimedia.org/wiki/File:Crow_corvus_nest.jpg