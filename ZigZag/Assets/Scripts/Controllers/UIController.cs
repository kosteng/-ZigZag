public class UIController 
{
    private readonly ViewUI _viewUI;
    private readonly ViewSphere _viewSphere;
    public UIController (ViewUI viewUI, ViewSphere viewSphere)
    {
        _viewUI = viewUI;
        _viewSphere = viewSphere;
    }
    
    public void Start()
    {
        _viewUI.coinCountText.gameObject.SetActive(true);
        _viewUI.tapToPlayText.gameObject.SetActive(true);
        _viewUI.tapToRestartText.gameObject.SetActive(false);
    }
    
    public void Update()
    {
        if (_viewSphere.start && _viewUI.tapToPlayText.gameObject.activeSelf)
            _viewUI.tapToPlayText.gameObject.SetActive(false);
        _viewUI.coinCountText.text ="Coins: " + _viewSphere.collectedCoinCount;
        if(_viewSphere.gameOver)
        {
            _viewUI.tapToRestartText.gameObject.SetActive(true);
        }
    }
}
