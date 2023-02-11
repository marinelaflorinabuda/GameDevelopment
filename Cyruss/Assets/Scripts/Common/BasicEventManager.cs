using UnityEngine;

/// <summary>
/// Singleton inherited by any EventManagers in the game.
/// </summary>
/// <typeparam name="T"></typeparam>

public class BasicEventManager<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = GetComponent<T>();
            if (_instance == null)
                _instance = gameObject.AddComponent<T>();
        }
    }
}
