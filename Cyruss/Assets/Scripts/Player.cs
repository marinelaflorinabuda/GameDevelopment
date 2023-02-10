using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private GameObject BulletLibraryReference;

    [SerializeField]
    private Transform rotationSpawnerParent;

    [SerializeField]
    private Transform spawnerParent;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletLibraryReference, rotationSpawnerParent.position, rotationSpawnerParent.rotation,spawnerParent);

            Debug.Log("Space clicked");
        }
    }
}
