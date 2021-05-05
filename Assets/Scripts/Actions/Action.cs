using System.Diagnostics;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class Action : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    public InteractionType InteractionType { get { return interactionType; } }

    protected KeyCode keyCode;
    protected bool activated = false;

    protected float value = 0f;


    [SerializeField] private float valueChangeSpeed = 1.0f;
    [SerializeField] private Vector2 valueClamp = new Vector2(0, 1);


    private Stopwatch stopwatch = new Stopwatch();
    [SerializeField] private float timerLength = 2000.0f;

    [SerializeField] private float tapChangeSpeed = 1.0f;



    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        keyCode = GetComponentInParent<KB_Key>().KeyCode;
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
        switch (InteractionType)
        {
            case InteractionType.Hold:
                {
                    activated = Input.GetKey(keyCode);
                }
                break;

            case InteractionType.Toggle:
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        activated = !activated;
                    }
                }
                break;

            case InteractionType.Timer:
                {
                    if (Input.GetKeyDown(keyCode) && activated == false)
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
                    activated = false;

                    if (Input.GetKeyDown(keyCode))
                    {
                        value = Mathf.Clamp(value += Time.deltaTime * tapChangeSpeed, valueClamp.x, valueClamp.y);
                    }
                }
                break;
        }
    }

    private void UpdateValue()
    {
        if (activated)
            value = Mathf.Clamp(value += Time.deltaTime * valueChangeSpeed, valueClamp.x, valueClamp.y);
        else
            value = Mathf.Clamp(value -= Time.deltaTime * valueChangeSpeed, valueClamp.x, valueClamp.y);
    }
}
