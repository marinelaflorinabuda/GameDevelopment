using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.parent.Rotate(new Vector3(0,0,1),speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.parent.Rotate(new Vector3(0, 0, 1), -speed);
        }
    }
}
