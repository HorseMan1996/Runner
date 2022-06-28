using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;
    public static GameObject currentPlatform;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        CreatePlatform.RunDummy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentPlatform = collision.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        CreatePlatform.RunDummy();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * 90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up * -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.1f,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0, 0);
        }
    }
}
