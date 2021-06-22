using UnityEngine;


[SelectionBase]
public class Tile : MonoBehaviour
{
    public KeyCode KeyCode { get; private set; }


    public void Initialize(KeyCode keyCode, string tileName)
    {
        this.name = tileName;
        GetComponentInChildren<TMPro.TMP_Text>().text = tileName;
        this.KeyCode = keyCode;
    }


    public void SetTile(GameObject original)
    {
        this.GetComponent<MeshFilter>().sharedMesh = original.GetComponent<MeshFilter>().sharedMesh;
        this.GetComponent<MeshCollider>().sharedMesh = original.GetComponent<MeshCollider>().sharedMesh;

        CopyAction(original.GetComponent<Action>());
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
