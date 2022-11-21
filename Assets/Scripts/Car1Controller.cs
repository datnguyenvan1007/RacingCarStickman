using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1Controller : MonoBehaviour
{
    Vector3 transformUp;

    Rigidbody2D rig;

    public float speed;

    public float rotateAngle;
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transformUp = transform.up;
        transformUp.Normalize();
        if (Input.GetKey(KeyCode.UpArrow))
            rig.velocity = -1 * transformUp * speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            rig.velocity = transformUp * speed;
        else
            rig.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig.rotation += rotateAngle;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.rotation -= rotateAngle;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }
}
