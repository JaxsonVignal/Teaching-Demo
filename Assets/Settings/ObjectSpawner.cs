using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Spawn.performed += ctx => SpawnAtMouse();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void SpawnAtMouse()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 spawnPosition = hit.point + Vector3.up * 0.5f;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}