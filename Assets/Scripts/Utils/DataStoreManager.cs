using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class DataStoreManager {

	private const string EMPTY_JSON = "{}";
	private const string ALL_TASKS_DICT = "ALL_TASKS_DICT";
	private const int INITIAL_TASK_CAPACITY = 10;

	private static Dictionary<Guid, SpartanTask> s_AllTasks = new Dictionary<Guid, SpartanTask>(INITIAL_TASK_CAPACITY);

	public static void SaveTask(SpartanTask task, bool commit)
	{
		//Get the dictionary, update it, and send it to the prefs
		s_AllTasks[task.Id] = task;
		if (commit)
		{
			Commit();
		}
	}

	private static void SendUpdateTasks()
	{
		//Serialize the dict and send it to the key
		string jsonRepresentation = JsonParser.ToJson(s_AllTasks);
		Debug.Log(jsonRepresentation);
		PlayerPrefs.SetString(ALL_TASKS_DICT, jsonRepresentation);
	}

	public static Dictionary<Guid, SpartanTask> GetAllTasks(bool forceSync = false) {
		//Check if the dict has any info, if it does not, we update it
		if (s_AllTasks.Count != 0 && !forceSync)
		{
			return s_AllTasks;
		}
		//Otherwise, get it from the prefs
		string jsonDict = PlayerPrefs.GetString(ALL_TASKS_DICT);
		if (string.IsNullOrEmpty(jsonDict))
		{
			throw new Exception("No tasks were found in the database, can't get info");
		}
		var dictFromPrefs = JsonParser.FromJson<Dictionary<Guid, SpartanTask>>(jsonDict);
		for (int i = 0; i < dictFromPrefs.Count; i++)
		{
			KeyValuePair<Guid, SpartanTask> entry = dictFromPrefs.ElementAt(i);
			s_AllTasks.TryAdd(entry.Key, entry.Value);
		}
		return s_AllTasks;
	}

	public static void Commit()
	{
		SendUpdateTasks();
		PlayerPrefs.Save();
	}

}
