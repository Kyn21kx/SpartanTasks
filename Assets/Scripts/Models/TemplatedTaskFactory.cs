using UnityEngine;

public class TemplatedTaskFactory {


    public TemplatedTask CreateTemplatedTask(SpartanTask task, GameObject template)
    {
        GameObject instance = GameObject.Instantiate(template);
        RectTransform rectTransform = instance.GetComponent<RectTransform>();
        TemplatedTask result = instance.GetComponent<TemplatedTask>();
        if (result == null ) {
            throw new DebugException("The prefab for this task does not contain the TemplatedTask script!");
        }
        result.SetTask(task);
        rectTransform.UseTopMiddleAnchor();
        return result;
    }

}