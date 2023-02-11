using UnityEngine;

/// <summary>
/// Component rotates the parent when the user presses right or left and cools down the bullet creation by dificulty. 
/// </summary>

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float angle = 3;

    [SerializeField]
    private Vector3 coolDown = new Vector3(1,3,6);

    private float currentCoolDown;

    private bool _isCoolingDown;

    private void Start()
    {
        currentCoolDown = coolDown.x;
        
        var dificulty = PlayerPrefs.GetFloat(ConstsHolder.DIFICULTY_PLAYERPREFS_TAG, 0);
        if (dificulty >= ConstsHolder.MEDIUM_DIFICULTY_VALUE - ConstsHolder.MEDIUM_DIFICULTY_OFFSET
            && dificulty <= ConstsHolder.MEDIUM_DIFICULTY_VALUE + ConstsHolder.MEDIUM_DIFICULTY_OFFSET)
        {
            currentCoolDown = coolDown.y;
        }

        if (dificulty > ConstsHolder.MEDIUM_DIFICULTY_VALUE + ConstsHolder.MEDIUM_DIFICULTY_OFFSET)
        {
            currentCoolDown = coolDown.z;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.parent.Rotate(new Vector3(0,0,1),angle);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.parent.Rotate(new Vector3(0, 0, 1), -angle);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isCoolingDown)
        {
            GameEventManager.Instance.SpawnBullet();
            _isCoolingDown = true;
            Invoke(nameof(ResetCooldown), currentCoolDown);
        }
    }

    private void ResetCooldown()
    {
        _isCoolingDown = false;
    }
}
