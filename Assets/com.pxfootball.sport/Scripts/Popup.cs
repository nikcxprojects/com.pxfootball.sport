using UnityEngine;

public class Popup : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2.0f);
    }
}
