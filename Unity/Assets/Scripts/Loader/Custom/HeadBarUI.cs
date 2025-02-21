using UnityEngine;

public class HeadBarUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera UiCamera;
    public Camera MainCamera;

    public Vector2 Offset = Vector3.zero;
    public Transform HeadPos;
    public GameObject HeadBar;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        UiCamera = GameObject.Find("Global/UICamera").GetComponent<Camera>();
        MainCamera = GameObject.Find("Global/MainCamera").GetComponent<Camera>();
    }

    public void UpdatePostion()
    {
        if (HeadPos == null || HeadBar == null)
        {
            return;
        }

        Vector2 OldPosition = WorldPosiToUIPos.WorldPosiToUIPosition(this.HeadPos.position, HeadBar, UiCamera, MainCamera, false);
        Vector3 NewPosition = Vector3.zero;
        NewPosition.x = OldPosition.x + Offset.x;
        NewPosition.y = OldPosition.y + Offset.y;
        HeadBar.transform.localPosition = NewPosition;
        // HeadBar.transform.localPosition = Vector3.SmoothDamp(HeadBar.transform.localPosition, NewPosition, ref velocity, 0.1f);
    }

    private void LateUpdate()
    {
        UpdatePostion();
    }
}