using System;
using UnityEngine;

/// <summary>
/// A daily task provided by the user
/// </summary>
[Serializable]
public struct SpartanTask {

	public string Title {
		get; set;
	}
	public Category Category {
		get; set;
	}
	public bool IsCompleted {
		get; set;
	}
	public TimeSpan ReminderTime {
		get; set;
	}

	/// <summary>
	/// Instead of having to set target days of the week, we also want the ability to set target counts per week
	/// </summary>
	public int TargetFrequency {
		get; set;
	} //Note: Frequency will be related to TargetDaysOfWeek if not empty
	public Guid Id {
		get; private set;
	}
	public DayOfWeek[] TargetDaysOfWeek {
		get; set;
	}

	public SpartanTask(string title, Category category, TimeSpan reminderTime, int targetFrequency = 0, DayOfWeek[] targetDaysOfWeek = null)
	{
		this.Id = Guid.NewGuid();
		this.Title = title;
		this.Category = category;
		this.ReminderTime = reminderTime;
		this.IsCompleted = false;
		this.TargetFrequency = targetFrequency;
		this.TargetDaysOfWeek = targetDaysOfWeek;
	}


}
