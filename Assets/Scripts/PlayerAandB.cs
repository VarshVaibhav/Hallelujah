using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAandB : MonoBehaviour
{
    //A thing of beauty is a joy forever. ~ JOHN KEATS
    //20:07, evening, Sunday.

    [SerializeField] int levelIndex;

    SpriteRenderer _sprite;
    Obstacle _obs;
    [SerializeField] GameObject child;
    [SerializeField] GameObject boomEffect;


    // for last level
    GameObject panel;
    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _obs = GameObject.FindWithTag("obsContainer").GetComponent<Obstacle>();

        // for last level

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obs")
        {
            GameObject effect = Instantiate(boomEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 2f);
            _obs.isDead = true;
            _obs.isMove = false;
            StartCoroutine(ToggleSprite());
        }
        else if(other.tag == "Complete")
        {
            PlayerPrefs.SetInt("done", (SceneManager.GetActiveScene().buildIndex + 1));
            Debug.Log(PlayerPrefs.GetInt("done"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.tag == "Last")
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator ToggleSprite()
    {
        child.SetActive(false);
        _sprite.enabled = false;
        yield return new WaitForSeconds(_obs.time);
        _sprite.enabled = true;
        child.SetActive(true);
    }

}
