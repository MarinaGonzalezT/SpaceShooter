using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsByType<MusicManager>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
