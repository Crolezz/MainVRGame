using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkcol : MonoBehaviour
{
    public AudioSource _as;
    public AudioClip collisionSound;


    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision _c)
    {

        if (_c.gameObject.tag == "")
        {
            _as.PlayOneShot(collisionSound);
        }

    }
}
