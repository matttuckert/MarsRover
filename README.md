# MarsRover

This program is a .net console application.

## Description

NASA intends to land robotic rovers on Mars to explore a particularly curious-looking plateau. The rovers must
navigate this rectangular plateau in a way so that their on board cameras can get a complete image of the
surrounding terrain to send back to Earth.
A simple two-dimensional coordinate grid is mapped to the plateau to aid in rover navigation. Each point on the grid is
represented by a pair of numbers X Y which correspond to the number of points East or North, respectively, from the
origin. The origin of the grid is represented by 0 0 which corresponds to the southwest corner of the plateau. 0 1 is
the point directly north of 0 0, 1 1 is the point immediately east of 0 1, etc. A rover’s current position and heading are
represented by a triple X Y Z consisting of its current grid position X Y plus a letter Z corresponding to one of the four
cardinal compass points, N E S W. For example, 0 0 N indicates that the rover is in the very southwest corner of the
plateau, facing north.
NASA remotely controls rovers via instructions consisting of strings of letters. Possible instruction letters are L, R,
and M. L and R instruct the rover to turn 90 degrees left or right, respectively (without moving from its current spot),
while M instructs the rover to move forward one grid point along its current heading.

## Steps to Run

1. clone the repo. `git clone https://github.com/matttuckert/MarsRover.git`     
2. [Install .net](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) if not already installed.
3. Run the program. It takes one parameter as a file path `dotnet run input/input1.txt`
        
Some sample input is available in the input directory. The first line of input shoud containe the X and Y bounds of the plateau separated by a space.
The following lines come in pairs. The first line of the pair represents the initial position and orientation of a Rover. The second line of the pair represnts the
movements of the Rover. The input file must have an odd number of lines. Each rover has two lines and there is one line for the plateau coordinates.
The output of the program is one line for each Rover representing the final position and orientation of each Rover in the order that they were specified
in the input. If the input file is invalid, the program will output an error.
        
## Design

There are four components to this program. The first is `Entry.cs`. This file contains the entry point of the program. It handles parsing the input file and error handling.
The second component is `Plateau.cs`. This file contains the plateau class which is responsible for containing the dimensions of the plateau and the list of rovers on the plateau.
The third component is `Rover.cs`. This file contains the rover class. The rover class is responsible for keeping track of its position on the plateau.
The fourth component is `Position.cs`. This file contains the position class. The position class keeps track of x and y coordinates, and an orientation. It also has logic for changing position according to its orientation.


