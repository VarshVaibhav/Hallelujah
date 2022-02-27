using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("done"))
        {
            PlayerPrefs.SetInt("done", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("done"));
        Debug.Log(levels.Length);
        for(int i = 0; i<levels.Length; i++)
        {
            if(int.Parse(levels[i].name)> PlayerPrefs.GetInt("done"))
            {
                levels[i ].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.156f);
                levels[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}