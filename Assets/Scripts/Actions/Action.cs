using System.Diagnostics;
using UnityEngine;
using static Enums;

[RequireComponent(typeof(Rigidbody))]
public abstract class Action : MonoBehaviour
{
    [SerializeField] protected InteractionType interactionType;

    protected bool activated = false;

    protected float value = 0f;
    [SerializeField] private float valueChangeSpeed = 1.0f;
    [SerializeField] private Vector2 clamp = new Vector2(0, 1);

    protected KeyCode key;

    private Stopwatch stopwatch = new Stopwatch();
    [SerializeField] private float timerLength = 2000.0f;


    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        key = GetComponent<Tile>().Key;
    }

    private void Update()
    {
        UpdateInteraction();
        UpdateValue();
        UpdateAction();
    }
    protected abstract void UpdateAction();


    private void UpdateInteraction()
    {
        switch (interactionType)
        {
            case InteractionType.Hold:
                {
                    activated = Input.GetKey(key);
                }
                break;

            case InteractionType.Toggle:
                {
                    if (Input.GetKeyDown(key))
                    {
                        activated = !activated;
                    }
                }
                break;

            case InteractionType.Timer:
                {
                    if (Input.GetKeyDown(key) && activated == false)
                    {
                        stopwatch.Restart();
                        activated = true;
                    }

                    if (stopwatch.ElapsedMilliseconds >= timerLength)
                    {
                        activated = false;
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

    private void UpdateValue()
    {
        if (activated)
            value = Mathf.Clamp(value += Time.deltaTime * valueChangeSpeed, clamp.x, clamp.y);
        else
            value = Mathf.Clamp(value -= Time.deltaTime * valueChangeSpeed, clamp.x, clamp.y);
    }
}
