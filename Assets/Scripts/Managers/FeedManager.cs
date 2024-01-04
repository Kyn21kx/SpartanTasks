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
	private bool isLoaded;

	private float SPACING_Y = 160f;

	private void Awake()
	{
		this.isLoaded = false;
		this.scrollContentParent.SetHeight(SPACING_Y);
    }

	private void Update()
	{
		if (!this.isLoaded) return;
		//Fetch the tasks
		Dictionary<Guid, SpartanTask> allTasks = DataStoreManager.GetAllTasks(forceSync: true);
		Vector3 currentPosition = default;
		//Create a new task template
		foreach (var entry in allTasks)
		{
			SpartanTask task = entry.Value;
			//Instantiate the template with the prefab sent
			GameObject instance = Instantiate(this.templateTask);
			//Parent to content
			instance.transform.SetParent(scrollContentParent, false);
			//Spacing is 160
			//Update content's height
			float updatedHeight = this.scrollContentParent.GetHeight() + SPACING_Y;
			this.scrollContentParent.SetHeight(updatedHeight);
			
		}
	}

	public void AddNewTask()
	{
		//Dispose of anything
		SceneManager.LoadScene(SceneConstants.NEW_TASK_ID);
	}

}

