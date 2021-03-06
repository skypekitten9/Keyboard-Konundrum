using System.Diagnostics;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
public abstract class Action : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    public InteractionType InteractionType { get { return interactionType; } set { interactionType = value; } }

    protected KeyCode keyCode;
    protected bool activated = false;

    protected float value = 0f;


    [SerializeField] private float valueChangeSpeed = 1.0f;
    public float ValueChangeSpeed { get { return valueChangeSpeed; } set { valueChangeSpeed = value; } }

    [SerializeField] private Vector2 valueClamp = new Vector2(0, 1);
    public Vector2 ValueClamp { get { return valueClamp; } set { valueClamp = value; } }


    private Stopwatch stopwatch = new Stopwatch();
    [SerializeField] private float timerLength = 2000.0f;
    public float TimerLength { get { return timerLength; } set { timerLength = value; } }

    [SerializeField] private float tapChangeSpeed = 1.0f;
    public float TapChangeSpeed { get { return tapChangeSpeed; } set { tapChangeSpeed = value; } }



    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        keyCode = GetComponentInParent<Tile>().KeyCode;
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
