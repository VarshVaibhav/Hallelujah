using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject levelPanel;
    [SerializeField] GameObject frontItems;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    float xValue, yValue;

    [SerializeField] GameObject infoPanel;

    void Start()
    {
        levelPanel.SetActive(false);
        infoPanel.SetActive(false);
        frontItems.SetActive(true);
        playerObject.SetActive(true);
        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CircleRotation();
        if (playerObject.activeInHierarchy)
        {
            playerObject.transform.Rotate(Vector3.forward * 200 * Time.deltaTime);
        }
    }
    public void OpenLevelPanel()
    {
        levelPanel.SetActive(true);
        frontItems.SetActive(false);
        playerObject.SetActive(false);
    }
    public void CloseLevelPanel()
    {
        RandomPosition();
        Debug.Log("clicked");
        levelPanel.SetActive(false);
        frontItems.SetActive(true);
        playerObject.SetActive(true);
        CircleRotation();
    }

    public void OpenInfoPanel()
    {
        infoPanel.SetActive(true);
        frontItems.SetActive(false);
        playerObject.SetActive(false);
    }

    public void CloseInfoPanel()
    {
        RandomPosition();
        Debug.Log("clicked");
        infoPanel.SetActive(false);
        frontItems.SetActive(true);
        playerObject.SetActive(true);
        CircleRotation();
    }

    private void RandomPosition()
    {
        xValue = Random.Range(-3f, 3f);
        yValue = Random.Range(-3f, 3f);
        red.transform.localPosition = new Vector3(xValue, yValue, 0);
        blue.transform.localPosition = new Vector3(-xValue, -yValue, 0);
    }
    public void CircleRotation()
    {
        red.transform.localPosition = Vector2.MoveTowards(red.transform.localPosition, new Vector2(-1.5f, 0), 2 * Time.deltaTime);
        blue.transform.localPosition = Vector2.MoveTowards(blue.transform.localPosition, new Vector2(1.5f, 0), 2 * Time.deltaTime);
    }
}
