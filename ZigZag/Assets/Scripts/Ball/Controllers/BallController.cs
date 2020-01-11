public class BallController 
{
    private readonly BallView _ballView;

    public BallController(BallView ballView)
    {
        _ballView = ballView;
    }
    public void Start ()
    {
        _ballView.Start();
    }
    public void Update (float deltaTime)
    {
        _ballView.Update();
        _ballView.Move(deltaTime);
    }
}
