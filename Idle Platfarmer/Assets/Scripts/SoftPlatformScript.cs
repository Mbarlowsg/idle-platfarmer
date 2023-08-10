using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftPlatformScript : MonoBehaviour
{
    private PlatformEffector2D effector;

    private bool isPlayerOnTop;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isPlayerOnTop)
        {
            StartCoroutine(PlayerFallThrough());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnTop = true;
        }
    }

    IEnumerator PlayerFallThrough()
    {
        effector.rotationalOffset = 180;
        yield return new WaitForSeconds(0.25f);
        effector.rotationalOffset = 0;
    }
}
