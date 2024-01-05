using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FeedManager : MonoBehaviour {

	[SerializeField]
	private GameObject templateTask;

	[SerializeField]
	private RectTransform scrollContentParent;
	private ScrollRect taskScrollView;
	private TemplatedTaskFactory templatedTaskFactory;
	private bool isLoaded;

	private const float SPACING_Y = 160f;
	private const float INITIAL_Y_POS = 0f;

	private void Awake()
	{
		this.isLoaded = false;
		this.templatedTaskFactory = new TemplatedTaskFactory();
    }

	private void Update()
	{
		if (this.isLoaded) return;
		//Fetch the tasks
		Dictionary<Guid, SpartanTask> allTasks = DataStoreManager.GetAllTasks(forceSync: true);
		Debug.Log($"Found {allTasks.Count} tasks");
		if (allTasks.Count == 0)
		{
			//TODO: Instantiate or activate a message saying, hey, go here and add some tasks
			this.isLoaded = true;
			return;
		}
		Vector3 currentPosition = new Vector3(0f, INITIAL_Y_POS, 0f);
		//Create a new task template
		foreach (var entry in allTasks)
		{
            //Spacing is 160
            //Update content's height
            float updatedHeight = this.scrollContentParent.GetHeight() + SPACING_Y;
            this.scrollContentParent.SetHeight(updatedHeight);
            SpartanTask task = entry.Value;
			//Instantiate the template with the prefab sent
			TemplatedTask templatedTaskInstance = templatedTaskFactory.CreateTemplatedTask(task, templateTask);
			//Parent to content
			templatedTaskInstance.transform.SetParent(scrollContentParent, false);
			templatedTaskInstance.transform.localPosition = currentPosition;
			currentPosition.y -= SPACING_Y;
		}
		this.isLoaded = true;
	}

	public void AddNewTask()
	{
		//Dispose of anything
		SceneManager.LoadScene(SceneConstants.NEW_TASK_ID);
	}

}

