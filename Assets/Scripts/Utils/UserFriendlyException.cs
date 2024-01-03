public class UserFriendlyException : System.Exception {
    public UserFriendlyException(string message, string title = "Oops, there was an error") : base(message) {
        SpartanPopup dialog = new SpartanPopup(title, message, PopupTypes.Error);
        PopupProvider.Instance.InstantiatePopup(dialog);
    }
}