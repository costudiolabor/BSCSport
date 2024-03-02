using UnityEngine;

public class View : MonoBehaviour {
    public void Close() => gameObject.SetActive(false);
    public void Open() => gameObject.SetActive(true);
}
