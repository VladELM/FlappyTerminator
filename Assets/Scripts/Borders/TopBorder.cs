using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBorder : MonoBehaviour
{
    public float GlobalPositionY {  get; private set; }

    private void Start()
    {
        GlobalPositionY = transform.parent.position.y;
    }
}
