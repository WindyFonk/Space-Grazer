using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage BackGround;
    [SerializeField] private float _x,_y;
    void Update()
    {
        BackGround.uvRect = new Rect(BackGround.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,
            BackGround.uvRect.size);
    }
}
