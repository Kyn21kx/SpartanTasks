using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PopupRenderer : MonoBehaviour {

	[SerializeField]
	private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    private Image backgroundPanelImage;
    public SpartanPopup Popup { get; private set; }
	public UnityEvent<SpartanPopup> OnSubmitEvent { get; private set; } = new UnityEvent<SpartanPopup>();

	private void OnEnable()
	{
		this.backgroundPanelImage = GetComponent<Image>();
	}

	public void Initialize(SpartanPopup popup)
	{
		this.Popup = popup;
		this.titleText.text = this.Popup.Title;
		this.descriptionText.text = this.Popup.Description;
		switch (this.Popup.PopupType)
		{
			case PopupTypes.Info:
				break;
			case PopupTypes.Debug:
#if DEBUG
				this.backgroundPanelImage.color = Color.blue;
#else
				Destroy(this.gameObject);
				return;
#endif
                break;
			case PopupTypes.Error:
				//Change our pop up BG color to red
				this.backgroundPanelImage.color = Color.red;
				//Change any FG colors to match
				break;
			case PopupTypes.Input:
				break;
			default:
				break;
		}
		Color currColor = this.backgroundPanelImage.color;
		currColor.a = 0.8f;
		this.backgroundPanelImage.color = currColor;
	}

	public void Submit()
	{
		this.OnSubmitEvent.Invoke(this.Popup);
		Destroy(this.gameObject);
	}

	public void SetOnSubmitCallback(UnityAction<SpartanPopup> handler)
	{
		this.OnSubmitEvent.AddListener(handler);
	}

}