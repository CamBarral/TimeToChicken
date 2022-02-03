using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxInteraction : MonoBehaviour
{
    public Animator _spawnBoxAnimator;

    private GameObject _spawnBox;
    void Start()
    {
        _spawnBox = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "eventBox")
        {
            _spawnBoxAnimator.SetTrigger("Open");
        }
    }
}
