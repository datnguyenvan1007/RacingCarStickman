using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{
    GameObject obj;

    Vector2 freezeTranslate;
    Vector3 freezeRotate;
    Vector3 transformUp;

    Rigidbody2D rig;

    public float speed;

    public float rotateAngle;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        rig = gameObject.GetComponent<Rigidbody2D>();
        freezeTranslate = new Vector2(0, 0);
        freezeRotate = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transformUp = transform.up;
        transformUp.Normalize();
        if (Input.GetKey(KeyCode.W))
            rig.velocity = -1 * transformUp * speed;
        else if (Input.GetKey(KeyCode.S))
            rig.velocity = transformUp * speed;
        else
            rig.velocity = freezeTranslate;

        if (Input.GetKey(KeyCode.A))
        {
            obj.transform.Rotate(new Vector3(0, 0, rotateAngle));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            obj.transform.Rotate(new Vector3(0, 0, -rotateAngle));
        }
        else
        {
            obj.transform.Rotate(freezeRotate);
        }
    }
}