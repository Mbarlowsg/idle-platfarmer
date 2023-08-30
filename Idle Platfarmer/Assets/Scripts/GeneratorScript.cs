using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    private bool _isPlayerOnTop;

    private Color _highlight;
    private Color _baseColor;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerOnTop == true && Player.Money > 10 && Input.GetKeyDown(KeyCode.E) == true)
        {
            Player.Money -= 10;
            print("Spent 10");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _isPlayerOnTop = true;
        _renderer.color = _highlight;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _isPlayerOnTop = false;
        _renderer.color = _baseColor;
    }
}
