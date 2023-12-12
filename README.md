# Water Bucket Challenge

## Description

Build an application that solves the Water Bucket Challenge for dynamic inputs (X, Y, Z). 

You have an X-bucket and a Y-bucket that you can fill from a lake. (Assume lake has unlimited amount of water.) 

By using only an X-bucket and Y-bucket (no third bucket), measure Z buckets of water.

## Goals

- Measure Z buckets of water in the most efficient way.
- Build an API where a user can enter any input for X, Y, Z and see the solution.
- If no solution, display “No Solution”.

## Limitations

- Actions allowed: Fill, Empty, Transfer

## Note

For convenience, I'm referring to the gallons as buckets, hence using the name Water Bucket Challenge instead of Water Jug Challenge.

# Project usage

After cloning the project, run it with ``` dotnet run ```.

You can either send a request via ```postman``` or using the UI ```swagger```.

You can use the following endpoint: ```[GET] api/WaterBucket/ShowSteps/x/y/z``` sending the variables via query parameters. X being the X-bucket, Y being the Y-bucket, and Z being the buckets of water that have to be measured (target).

As a result, after using the variables 7/3/2 as an example, you will get the following response: 

```
    [
    "Y: 3. X: 0.   Filled bucket Y",
    "Y: 0. X: 3.   Transfered from bucket Y to bucket X",
    "Y: 3. X: 3.   Filled bucket Y",
    "Y: 0. X: 6.   Transfered from bucket Y to bucket X",
    "Y: 3. X: 6.   Filled bucket Y",
    "Y: 2. X: 7.   Transfered from bucket Y to bucket X"
    ]
```

Showing every step that has been made and the status of the buckets at every step.

# Thought process for finding the solution

After some investigation and solving the problem by hand with different variables, I came to the conclusion of finding two solutions by repeating the same pattern of steps until the target is reached. 

The pattern is the following: Fill the starting bucket and transfer to the other one, when either bucket reaches its limit, empty it; when either bucket reaches 0, fill it. 

The difference of both solutions is the starting point: The program will compute 2 solutions, the solution starting at the X-gallon, and the other solution starting at the Y-gallon, finally, we can return the solution with less steps (the optimal one).
