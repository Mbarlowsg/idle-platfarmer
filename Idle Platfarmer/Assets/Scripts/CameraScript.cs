using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            _player.transform.position.x,
            _player.transform.position.y,
            -10f
        );
    }
}
