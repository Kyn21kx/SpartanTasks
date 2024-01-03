using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TaskCreationManager : MonoBehaviour {

	[SerializeField]
	private TMP_InputField titleText;

	[SerializeField]
	private TMP_Dropdown categoryDropdown;
	private CategoryController categoryController;

	[SerializeField]
	private TMP_Dropdown goalTypeDropdown;

	#region Goal types section references
	[SerializeField]
	private GameObject frequencyGoalSection;
	[SerializeField]
	private GameObject targetDaysGoalSection;
	[SerializeField]
	private GameObject singleDayGoalSection;
	#endregion

	[SerializeField] 
	private TMP_Dropdown hourDropdown;
	[SerializeField]
	private TMP_Dropdown minuteDropdown;
	[SerializeField]
	private TMP_Dropdown timeAmPmDropdown;
	[SerializeField]
	private TMP_InputField frequencyText;

	private TimeSelectionController timeSelectionController;
	private GoalTypes selectedGoalType;

	private void Start()
	{
		this.SetupCategories();
		this.SetupTimeSelection();
		this.SetupGoalTypeSection();
	}

	public void SubmitInformation()
	{
		//Create a new task
		string title = this.titleText.text;
		if (string.IsNullOrEmpty(title))
		{
			throw new UserFriendlyException("You must set title for your task!");
		}
		//Create the reminder time
		TMP_Dropdown.OptionData selectedHour = this.hourDropdown.options[this.hourDropdown.value];
		TMP_Dropdown.OptionData selectedMinute = this.minuteDropdown.options[this.minuteDropdown.value];
		TMP_Dropdown.OptionData timePartSelection = this.timeAmPmDropdown.options[this.timeAmPmDropdown.value];
		bool isPm = timePartSelection.text == "PM";

		//Create the rest of the struct
		TimeSpan reminderTime = this.timeSelectionController.OptionToTimestamp(selectedHour, selectedMinute, isPm);
		string categoryName = this.categoryDropdown.options[this.categoryDropdown.value].text;
		Category category = this.categoryController.FindCategoryByName(categoryName);

		//Condition the task on the goal type
		SpartanTask createdTask;
		switch (selectedGoalType)
		{
			case GoalTypes.Frequency:
				if (string.IsNullOrEmpty(frequencyText.text))
				{
					throw new UserFriendlyException("Please enter a valid target frequency!");
				}
				createdTask = new SpartanTask(title, category, reminderTime, targetFrequency: int.Parse(frequencyText.text));
				break;
			case GoalTypes.TargetDays:
				createdTask = new SpartanTask(title, category, reminderTime, targetDaysOfWeek: Array.Empty<DayOfWeek>());
				break;
			case GoalTypes.SingleDay:
			default:
				createdTask = new SpartanTask(title, category, reminderTime);
				break;
		}
		//Send the task to the DB (and player prefs)
		DataStoreManager.SaveTask(createdTask, true);
	}


	private void SetupCategories()
	{
		this.categoryController = new CategoryController();
		this.categoryController.AppendCategoryOptions(categoryDropdown.options);
		this.categoryDropdown.onValueChanged.AddListener(ChangeItemColorToCategory);
		//Call the change item initially for some setup colors
		ChangeItemColorToCategory(0);
	}

	private void SetupTimeSelection()
	{
		this.timeSelectionController = new TimeSelectionController();
		this.timeSelectionController.AppendHourOptions(this.hourDropdown.options);
		this.timeSelectionController.AppendMinuteOptions(this.minuteDropdown.options);
	}

	private void SetupGoalTypeSection()
	{
		this.goalTypeDropdown.onValueChanged.AddListener(SwitchGoalTypeSection);
		SwitchGoalTypeSection(0);
	}

	private void SwitchGoalTypeSection(int goalTypeIndex)
	{
		GoalTypes goalType = (GoalTypes)goalTypeIndex;
		switch (goalType)
		{
			case GoalTypes.Frequency:
				this.frequencyGoalSection.SetActive(true);
				this.singleDayGoalSection.SetActive(false);
				this.targetDaysGoalSection.SetActive(false);
				break;
			case GoalTypes.TargetDays:
				this.targetDaysGoalSection.SetActive(true);
				this.frequencyGoalSection.SetActive(false);
				this.singleDayGoalSection.SetActive(false);
				break;
			case GoalTypes.SingleDay:
				this.singleDayGoalSection.SetActive(true);
				this.targetDaysGoalSection.SetActive(false);
				this.frequencyGoalSection.SetActive(false);
				break;
			default:
				throw new Exception("The goal type you selected is not recognized by the system, please contact support!");
		}
		this.selectedGoalType = goalType;
	}

	private void ChangeItemColorToCategory(int itemIndex)
	{
		//Get the item as a selectable
		string categoryName = this.categoryDropdown.options[itemIndex].text;
		Category foundCategory = this.categoryController.FindCategoryByName(categoryName);
		//Change its color (maybe with a Lerp)
		this.categoryDropdown.image.color = foundCategory.DisplayColor;
		Debug.Log($"Just changed color to {this.categoryDropdown.image.color}");
	}

}
