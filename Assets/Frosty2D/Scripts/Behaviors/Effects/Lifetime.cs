﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Frosty-Effects/Lifetime Expiration")]
public class Lifetime : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        StartCoroutine(WaitAndDie());
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(lifeTime);
        GameObject.Destroy(this.gameObject);
    }
}
