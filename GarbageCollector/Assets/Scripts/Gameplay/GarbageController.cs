using UnityEngine;
using System.Collections;

public class GarbageController : MonoBehaviour
{
    private SpawnController controller;
    private float _halfTime;

    private void OnEnable()
    {
        controller = GameObject.Find("Spawner").GetComponent<SpawnController>();
        _halfTime = controller.Timer/2;
        StartCoroutine("AddPhysics");
    }

    private IEnumerator AddPhysics()
    {
        yield return new WaitForSeconds(_halfTime);
        gameObject.AddComponent<Rigidbody2D>();
    }

    public float HalfTime
    {
        get
        {
            return _halfTime;
        }
    }
}
