using UnityEngine;
using UnityEngine.InputSystem;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    private PlayerControls pc;


    private void Awake()
    {
        pc = new PlayerControls();
        pc.Player.Spawn.performed += ctx => SpawnAtMouse();
    }

    private void OnEnable()
    {
        pc.Enable();
    }

    private void OnDisable()
    {
        pc.Disable();
    }

    private void SpawnAtMouse()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(prefabToSpawn, hit.point, Quaternion.identity);
        }
    }
}
