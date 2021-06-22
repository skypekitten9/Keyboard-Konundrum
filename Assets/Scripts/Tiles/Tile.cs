using UnityEngine;


[SelectionBase]
public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject newTilePrefab = null;
    [SerializeField] [Range(-180.0f, 180.0f)] private float newRotation = 0.0f;
    [SerializeField] private bool canSetTileInRuntime;


    public KeyCode KeyCode { get; private set; }



    public void Initialize(KeyCode keyCode, string tileName)
    {
        this.name = tileName;
        this.KeyCode = keyCode;
        GetComponentInChildren<TMPro.TMP_Text>().text = tileName;

        canSetTileInRuntime = false;
    }


    public void SetTile()
    {
        SetTile(newTilePrefab, newRotation);
    }

    public void SetTile(GameObject original, float rotation)
    {
        if (Application.isPlaying == true && canSetTileInRuntime == false)
            return;

        if (original != null)
        {
            this.GetComponent<MeshFilter>().sharedMesh = original.GetComponent<MeshFilter>().sharedMesh;
            this.GetComponent<MeshCollider>().sharedMesh = original.GetComponent<MeshCollider>().sharedMesh;
            CopyAction(original.GetComponent<Action>());
        }

        this.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        this.transform.GetChild(0).rotation = Quaternion.Euler(90.0f, Quaternion.AngleAxis(-rotation, -Vector3.forward).eulerAngles.y, 0f);
    }


    private void CopyAction<T>(T original) where T : Action
    {
        Action target;
        if (GetComponent<Action>() == null)
            target = this.gameObject.AddComponent(original.GetType()) as Action;
        else
            target = this.GetComponent<Action>();

        target.InteractionType = original.InteractionType;
        target.ValueChangeSpeed = original.ValueChangeSpeed;
        target.ValueClamp = original.ValueClamp;
        target.TimerLength = original.TimerLength;
        target.TapChangeSpeed = original.TapChangeSpeed;
    }

}
