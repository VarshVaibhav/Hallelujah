using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChange : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SelectLevel);
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene(int.Parse(gameObject.name));
    }
}
