public class UIController 
{
    private readonly UIView _UIView;

    public UIController (UIView UIview)
    {
        _UIView = UIview;
    }
    
    public void Start()
    {
        _UIView.coinCountText.gameObject.SetActive(true);
        _UIView.tapToPlayText.gameObject.SetActive(true);
        _UIView.tapToRestartText.gameObject.SetActive(false);
    }
    
    public void UpdateCoin(int countCoint)
    {
        _UIView.coinCountText.text ="Coins: " + countCoint;
    }
    
    public void ShowTapToPlayText(bool state)
    {
        _UIView.tapToPlayText.gameObject.SetActive(state);
    }
    public void GameOver()
    {
        _UIView.tapToRestartText.gameObject.SetActive(true);
    }
}
