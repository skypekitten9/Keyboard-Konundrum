using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public bool activated { get; set; } = false;
    public float speed;
    float value;
    [SerializeField] private Vector2 scaleClamp;
    void Update()
    {
        if (activated)
        {
            value = Mathf.Clamp(value += Time.deltaTime * speed, scaleClamp.x, scaleClamp.y);
        }
        else
        {
            value = Mathf.Clamp(value -= Time.deltaTime * speed, scaleClamp.x, scaleClamp.y);
        }
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, value, gameObject.transform.localScale.z);
    }
}
