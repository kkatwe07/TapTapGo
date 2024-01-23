using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform lastPlatform;
    private Vector3 _lastPosition;
    private Vector3 _newPosition;

    public bool StopPlatformSpawn { get; set; } = false;

    private void Start()
    {
        _lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        while (!StopPlatformSpawn)
        {
            GeneratePosition();

            Instantiate(platform, _newPosition, Quaternion.identity);

            _lastPosition = _newPosition;

            yield return new WaitForSeconds(0.05f);
        }
    }
    
    private void GeneratePosition()
    {
        var random = Random.Range(0, 2);
        _newPosition = _lastPosition;

        if (random > 0)
        {
            _newPosition.x += 2f;
        }
        else
        {
            _newPosition.z += 2f;
        }
    }
}
