using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    Obstacle _obs;

    [SerializeField] GameObject sun;
    [SerializeField] GameObject moon;
    
    SpriteRenderer _sprite;

    private void Awake()
    {
        _obs = GameObject.FindWithTag("obsContainer").GetComponent<Obstacle>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
        NoRotationForChild();
        if(_obs.isDead == true)
        {
            StartCoroutine(BackRotation());
        }
    }

    private void TouchDetect()
    {
        if(_obs.isDead == true)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            _sprite.color = new Color(1f, 1f, 1f, 0.5f);   
            if (Input.mousePosition.x < Screen.width / 2)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            _sprite.color = new Color(1f, 1f, 1f, 0.19f);
        }

    }

    private void NoRotationForChild()
    {
        sun.transform.rotation = Quaternion.identity;
        moon.transform.rotation = Quaternion.identity;
    }

    IEnumerator BackRotation()
    {
        yield return new WaitForSeconds(_obs.time);
        transform.Rotate(Vector3.forward * -250 * Time.deltaTime);
    }
}
