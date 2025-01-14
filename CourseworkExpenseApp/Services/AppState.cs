public class AppState
{
    public event Action OnChange;

    private bool _isUserRegistered;
    public bool IsUserRegistered
    {
        get => _isUserRegistered;
        set
        {
            _isUserRegistered = value;
            NotifyStateChanged();
        }
    }

    private bool _isUserLoggedIn;
    public bool IsUserLoggedIn
    {
        get => _isUserLoggedIn;
        set
        {
            _isUserLoggedIn = value;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
