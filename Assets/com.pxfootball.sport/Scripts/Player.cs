using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool IsBot;

    private Camera _camera;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnMouseDrag()
    {
        if (Time.timeScale < 1 || IsBot)
        {
            return;
        }

        transform.position = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }

    private void Update()
    {
        if (Time.timeScale < 1)
        {
            return;
        }

        if (IsBot)
        {
            transform.position = new Vector2(GameManager.Instance.BallRef.transform.position.x, transform.position.y);
        }
    }
}
