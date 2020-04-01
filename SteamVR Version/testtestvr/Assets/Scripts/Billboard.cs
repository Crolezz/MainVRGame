using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
    }

}
