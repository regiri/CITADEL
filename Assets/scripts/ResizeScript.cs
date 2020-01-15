using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeScript : MonoBehaviour
{
    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Screen.height/Screen.width * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        scale *= cameraSize.x / spriteSize.x;
        transform.position = Vector2.zero;
        transform.localScale = scale;
    }

}
