using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public static float particalSpeed;
    [SerializeField] GameObject cubePart;
    GameObject Player;
    ParticleSystem crashParticle;
    MeshRenderer cubeMesh;
    // Start is called before the first frame update
    void Start()
    {
        cubeMesh = GetComponentInChildren<MeshRenderer>();
        crashParticle = GetComponentInChildren<ParticleSystem>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
        crashParticle.startSpeed = particalSpeed;
    }

    private void DestroyObject()
    {
        if (Player.transform.position.x - 10f > this.gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            crashParticle.Play();
            cubeMesh.enabled = false;
        }
    }
}
