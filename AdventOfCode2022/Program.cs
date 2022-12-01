using AdventOfCode2022.Shared;

Console.WriteLine("Welcome to my Advent of Code project!");
var taskInput = ReadLine.Read("Which task would you like to run?");
var resolvedTask = TaskResolver.ResolveTask(Convert.ToDouble(taskInput));
resolvedTask.Run();
ReadLine.Read("Run complete!");
