public class UIController 
{
    private readonly UIView _UIView;
    private readonly BallView _ballView;
    public UIController (UIView viewUI, BallView viewSphere)
    {
        _UIView = viewUI;
        _ballView = viewSphere;
    }
    
    public void Start()
    {
        _UIView.coinCountText.gameObject.SetActive(true);
        _UIView.tapToPlayText.gameObject.SetActive(true);
        _UIView.tapToRestartText.gameObject.SetActive(false);
    }
    
    public void Update()
    {
        if (_ballView.start && _UIView.tapToPlayText.gameObject.activeSelf)
            _UIView.tapToPlayText.gameObject.SetActive(false);
        _UIView.coinCountText.text ="Coins: " + _ballView.collectedCoinCount;
        if(_ballView.gameOver)
        {
            _UIView.tapToRestartText.gameObject.SetActive(true);
        }
    }
}
