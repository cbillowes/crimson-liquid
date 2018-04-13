# Word Analysis

The Core library contains the logic to find frequent words and calculate Scrabble scores.
The Tests are only available for the Core library
The Console application is the starting point for the user

## Performance

* I process the file line by line cleaning up as I go along
* Cleaning up involves removing characters so that I can work with words alone
* I used the ReSharper Performance Profiling > Sampling to get an idea of where I can optimize
* II looked into the find-and-replace functionality and found that I could optimize it further

Original output:

  * 0,14 MB took 263ms to process.
  * 3,20 MB took 3082ms to process.
  * 6,10 MB took 4593ms to process.
  * 11,62 MB took 11072ms to process.

Optimized output:

  * 0,14 MB took 88ms to process.
  * 3,20 MB took 1601ms to process.
  * 6,10 MB took 1301ms to process.
  * 11,62 MB took 5333ms to process.

To further improve performance I would follow these steps:

* Ensure fast-executing tests - inspect clunky tests for potential bottlenecks
* Inspect code analysis looking for obvious flaws and painful cyclomatic complexity
* Look for expensive calls or executions and optimize them
* Use tools like Resharper's Profile, Visual Studio's Performace Profiler, Visual Studio's Code analysis, SonarQube
* Find out what other people use

**Note** I am not happy with the regular expression but it is optimal enough to not hinder performance too much

---

 of experimentation with word aggregation and Scrabble scoring

## Resources

* Project Gutenberg download for War and Peace: http://www.gutenberg.org/files/2600/2600.txt
* Scrabble scoring

    A 1    
    B 3    
    C 3    
    D 2    
    E 1    
    F 4    
    G 2    
    H 4    
    I 1    
    J 8    
    K 5    
    L 1    
    M 3    
    N 1    
    O 1    
    P 3    
    Q 10    
    R 1    
    S 1    
    T 1    
    U 1    
    V 4    
    W 4    
    X 8    
    Y 4    
    Z 10    
