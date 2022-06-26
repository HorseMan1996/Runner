using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] GameObject Cube;
    [SerializeField] GameObject player;
    float xValue = 2f, zValue;
    float speed = 5f;
    float playerPositionX = 0;
    Rigidbody characterRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cubes.particalSpeed = characterRigidbody.velocity.magnitude;
        zValue = Input.GetAxis("Vertical") * speed;

        if (Input.GetKeyDown(KeyCode.G))
        {
            characterRigidbody.useGravity = !characterRigidbody.useGravity;
        }
        if (player.transform.position.x >= playerPositionX)
        {
            xValue = xValue + 1f;
            playerPositionX = playerPositionX + 20f;
            Instantiate(Cube, new Vector3(player.transform.position.x + 10f, 0.669f, Random.Range(-4f, 3f)), Quaternion.Euler(0f, 0f, 0f));
        }
    }
    private void FixedUpdate()
    {
        characterRigidbody.velocity = new Vector3(xValue, 0f, zValue);
    }
}
