using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroy : MonoBehaviour
{
    private float lifetime = 20;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
