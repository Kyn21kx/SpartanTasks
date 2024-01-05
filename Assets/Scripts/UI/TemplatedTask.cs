using TMPro;
using UnityEngine;

public class TemplatedTask : MonoBehaviour {

	[SerializeField]
	private TextMeshProUGUI titleText;
	[SerializeField]
	private ProgressBarAnimator progressBar;
	private SpartanTask task;

	public void SetTask(SpartanTask task)
	{
		this.task = task;
        this.titleText.text = task.Title;
        this.progressBar.StartAnimation(task.CompletedCount, task.TargetFrequency);
    }

	public void CompleteTaskForToday()
	{
		task.CompletedCount++;
		this.progressBar.StartAnimation(task.CompletedCount, task.TargetFrequency);
		//TODO: Don't commit here, but once the player goes to another scene or attempts to close the app to improve performance
		DataStoreManager.SaveTask(task, true);
	}

}