using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class Tile : MonoBehaviour
{
    public KeyCode key;
    public InteractionType interactionType;
    Action action;

    private void Start()
    {
        action = gameObject.GetComponent<Action>();
    }
    void Update()
    {
        switch (interactionType)
        {
            case InteractionType.Hold:
                action.activated = Input.GetKey(key);
                //if (Input.GetKey(key) && !action.activated)
                //{
                //    action.Activate();
                //}
                //else if (!Input.GetKey(key) && action.activated)
                //{
                //    action.Deactivate();
                //}
                break;
            case InteractionType.Toggle:
                break;
            case InteractionType.Timer:
                break;
            case InteractionType.Tap:
                break;
            default:
                break;
        }
    }
}
