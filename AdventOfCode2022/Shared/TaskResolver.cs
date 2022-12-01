﻿using System;
namespace AdventOfCode2022.Shared
{
	public class TaskResolver
	{
        /// <summary>
        /// Take a task number and resolve to a task class.
        /// Examples:
        /// 1.1 => Day 1, Task 1 => AdventOfCode2022.Day1.Task1
        /// 4.2 => Day 4, Task 2 => AdventOfCode2022.Day4.Task2
        /// etc....
        /// </summary>
        /// <param name="taskNumber"></param>
        /// <returns></returns>
        public static IAdventOfCodeTask ResolveTask(double taskNumber)
		{
			var splits = taskNumber.ToString().Split('.');
            var taskDay = splits[0];
			var task = splits[1];
			var fullClassName = $"AdventOfCode2022.Day{taskDay}.Task{task}";
            var objectType = Type.GetType(fullClassName);
            return Activator.CreateInstance(objectType) as IAdventOfCodeTask;
        }
	}
}

