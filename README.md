# C# Salesman

## Description
### Traveling Salesman Problem
The Traveling Salesman is an algorithm that finds the shortest route which vists a layout of "cities" once (As a traveling salesman would do). Each city is a node on a 2d grid, I've implemented a "greedy" and brute-force approach. Most my reading is from the [TSP Wiki](https://en.wikipedia.org/wiki/Travelling_salesman_problem) .

### Project
My project uses MS Net Core 3.1 and WPF (Window's Presentation Format). I wouldn't consider myself experienced in C# but I am now very familiar with the syntax and basic OOP implementation as well as threading via Tasks. 
The main goal of this was to learn the basics of WPF (and I did achieve this) but after a week most my focus and thought was on the problem myself. There's a lot I'd like to improve. I would recommend anyone try to recreate a solution for these more classical computer science problems.

### Usage
- Click anywhere on the white canvas to create a node. 

- In the Drop-down in the top right, the algorithm can be selected.
  
- The "Calculate" button then solves and draw's said solution on the canvas as lines between each node. 
  
- The "Clear" button removes all points and solutions.

- The "Add Point" button adds a random point to the canvas.
  
- The "Randomise" button moves all the nodes to random positions.


## Images
  
Empty Canvas
![The app, with all button's above and an empty canvas](https://i.imgur.com/90BzcDB.png)
  
Nine Nodes and Before "Calculate"
![Nine nodes placed on the canvas](https://i.imgur.com/PWSFxdM.png)
  
The shortest "Greedy" Solution
![Four nodes placed on the canvas](https://i.imgur.com/OoFY8E4.png)
  
The Shortest Solution from Brute-Force
![Four nodes placed on the canvas](https://i.imgur.com/XiOdqZN.png)
  
A tenth unsolved point added via "Add Point" button
![Four nodes placed on the canvas](https://i.imgur.com/mCjeA7f.png)

### Improvements (TODO)
- "Ant Colony" Algorithm
- Perf Optimisations on the Brute-Force
- Resizable App
- Grid / Meaning to the scale
- Algorithm Benchmark (relative distance difference, processing time)
- Solution Comparison (multiple visible solutions)


## Licence

**MIT License**

Copyright © 2023 Andrew McCall
