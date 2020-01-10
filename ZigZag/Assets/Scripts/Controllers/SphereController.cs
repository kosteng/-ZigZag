public class SphereController 
{
    private readonly ViewSphere _viewSphere;

    public SphereController (ViewSphere viewSphere)
    {
        _viewSphere = viewSphere;
    }
    public void Start ()
    {
        _viewSphere.Start();
    }
    public void Update (float deltaTime)
    {
        _viewSphere.Update();
        _viewSphere.Move(deltaTime);
    }
}
