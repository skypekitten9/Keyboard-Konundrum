using System.Diagnostics;
using UnityEngine;
using static Enums;

[RequireComponent(typeof(Action))]
public class Tile : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private InteractionType interactionType;
    private Action action;

    private Stopwatch stopwatch;


    private void Awake()
    {
        action = gameObject.GetComponent<Action>();
        stopwatch = new Stopwatch();
    }

    private void Update()
    {
        switch (interactionType)
        {
            case InteractionType.Hold:
                {
                    action.Activated = Input.GetKey(key);
                }
                break;

            case InteractionType.Toggle:
                {
                    if (Input.GetKeyDown(key))
                    {
                        action.Activated = !action.Activated;
                    }
                }
                break;

            case InteractionType.Timer:
                {
                    if (Input.GetKeyDown(key))
                    {
                        stopwatch.Restart();
                        action.Activated = true;
                    }

                    if (stopwatch.ElapsedMilliseconds >= 3000.0f)
                    {
                        action.Activated = false;
                        stopwatch.Stop();
                    }
                }
                break;

            case InteractionType.Tap:
                {

                }
                break;
        }
    }

}
