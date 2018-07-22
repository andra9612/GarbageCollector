using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour {

    [SerializeField] private string tag;

    public delegate void OnGarbageDestroy(bool value);
    public static event OnGarbageDestroy GarbageDestroyerObserver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
            GarbageDestroyerObserver(true);
        else
        {
            GarbageDestroyerObserver(false);
            Handheld.Vibrate();
        }

        Destroy(collision.gameObject);
    }

}
