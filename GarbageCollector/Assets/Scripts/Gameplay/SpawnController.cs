using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject[] prefabs;
    [SerializeField] private float _timer;

	void Start ()
    {
        StartCoroutine("SpawnPrefab");
    }
	
    private IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(_timer);
        Spawn();
        StartCoroutine("SpawnPrefab");
    }

    private void Spawn()
    {
        int rndPrefab = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[rndPrefab];
        Instantiate(prefab, transform.position, Quaternion.identity, transform);
    }

    public float Timer
    {
        get
        {
            return _timer;
        }

    }
}
