using UnityEngine;

public class PopupProvider : MonoBehaviour {

	public static PopupProvider Instance { get; private set; }

	[SerializeField]
	private GameObject popupTemplate;
	private Canvas uiRoot;

	private void Awake()
	{
		Instance = this;
		uiRoot = GameObject.FindWithTag(EntityConstants.UI_ROOT_TAG).GetComponent<Canvas>();
	}

	public GameObject InstantiatePopup(SpartanPopup popup, Vector3 position = default)
	{
		Debug.Log("Popup");
		GameObject instance = Instantiate(popupTemplate, position, Quaternion.identity);
		PopupRenderer renderer = instance.GetComponent<PopupRenderer>();
		renderer.Initialize(popup);
		renderer.GetComponent<RectTransform>().localPosition = position;
		//Set the parent to the root of the ui
		instance.transform.SetParent(uiRoot.transform, false);
		return instance;
	}

}