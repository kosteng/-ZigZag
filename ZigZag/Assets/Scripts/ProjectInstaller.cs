using UnityEngine;
using UnityEngine.EventSystems;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField] private MonoBehaviourView _monoBehaviourView;

    private ProjectInfrastructure _infrastructure;

    private void Awake()
    {
        _infrastructure = new ProjectInfrastructure(_monoBehaviourView);
    }

    private void Start()
    {
        _infrastructure.Start();
    }
    private void Update()
    {
        _infrastructure.Update(Time.deltaTime);
    }
}
