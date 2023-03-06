using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [FormerlySerializedAs("Health")] public float healthvalue;
    // Update is called once per frame
    void Update()
    {
        if (healthvalue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
