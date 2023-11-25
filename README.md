# ToyRobotChallenge
Welcome to the Toy Robot Challenge!

# Problem Description
The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units

There are no other obstructions on the table surface

The robot is free to roam around the surface of the table, but must be prevented from falling to destruction

Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed

Application can read in commands of the following form -
```
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
```

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.

The origin (0,0) can be considered to be the SOUTH WEST most corner.

The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.

MOVE will move the toy robot one unit forward in the direction it is currently facing.

LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

REPORT will announce the X,Y and F of the robot.

A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.

# Constraints 
The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Any move that would cause the robot to fall must be ignored.

# Example Input and Output
```
a) PLACE 0,0,NORTH
   MOVE
   REPORT
   Output: 0,1,NORTH

b) PLACE 0,0,NORTH
   LEFT
   REPORT
   Output: 0,0,WEST

c) PLACE 1,2,EAST
   MOVE
   MOVE
   LEFT
   MOVE
   REPORT
   Output: 3,3,NORTH
```
# Assumptions
To make it easier to interact with the app, the following assumptions were made:
* Commands and directions are considered case-insensitive and accepted in upper-case, lower-case and mixed casing. However, the output will be displayed in upper-case
* Commands are trimmed.For instance:
`        leFT `   === parsed as ===>   `LEFT`.
* When the user enters invalid commands, application will display error messages.
* If the robot is already placed on the table and given an invalid PLACE command, the robot will stay where it is.
* The application has an extra command, which is EXIT. This was given to enable the user to STOP/EXIT the application gracefully.

# Usage

Clone this repository and build in Visual Studio in release mode. This is developed in Visual Studio 2022 Community.

OR

You can directly run the .exe present at ToyRobotChallenge\bin\Release\net6.0 and follow the instructions.

  





 
