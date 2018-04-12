# Word Analysis

The  Core library contains logic to find frequent words and calculate Scrabble scores.

## Practices and Principles
The code is written with the SOLID principle in mind. 
Each class has a function and executes that function well.

Interfaces are used for creating a contract between shared concrete classes.
They are also used for available for any dependency injection or mocking during testing.

## New language features
Using newer features in C#

* Static namespace => using static System.Console;
* Tuples => (string word, int total) Calculate()
* String Interpolation  $"Hello {input}";

## Performance
To improve performance I would follow these steps:

* Ensure fast-executing tests - inspect clunky tests for potential bottlenecks
* Inspect code analysis looking for obvious flaws like cyclomatic complexity
* Look for expensive calls or executions and optimise them
* Use tools like Resharper's Profile, Visual Studio's Performace Profiler, Visual Studio's Code analysis, SonarQube
* I'll see what other people are using within my development space, in the community and online