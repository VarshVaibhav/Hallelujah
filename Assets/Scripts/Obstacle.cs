using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    GameUI inGameObjects;

    public float time = 0.5f;
    [SerializeField] float speed = 3.5f;
    public bool isDead = false;
    public bool isMove = false;
    Vector3 oldPosition;
    Vector3 newPosition;

    private void Awake()
    {
        inGameObjects = GameObject.FindWithTag("gameui").GetComponent<GameUI>();
    }

    void Start()
    {
        StartCoroutine(DownwardMovement());
        oldPosition = transform.position;
        inGameObjects.pauseButton.SetActive(false);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(isMove == true )
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if(isDead == true)
        {
            StartCoroutine(BackToPosition());
        }
    }

    IEnumerator BackToPosition()
    {
        yield return new WaitForSeconds(time);
        newPosition = transform.position;
        Vector3 pos = oldPosition - newPosition;
        transform.Translate(Vector3.down * -speed * Time.deltaTime * pos.y);
        if ((int)pos.y == 0)
        {
            isMove = true;
            isDead = false;
        }
    }

    IEnumerator DownwardMovement()
    {
        inGameObjects.playerAnim.Play(0);
        yield return new WaitForSeconds(2f);
        isMove = true;
        inGameObjects.quote.SetActive(false);
        inGameObjects.pauseButton.SetActive(true);
    }

}
