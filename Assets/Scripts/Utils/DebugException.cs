public class DebugException : System.Exception {

    public DebugException(string message, string title = "[DEBUG] - ERROR") : base(message) {
        SpartanPopup dialog = new SpartanPopup(title, message, PopupTypes.Debug);
        PopupProvider.Instance.InstantiatePopup(dialog);
    }

}