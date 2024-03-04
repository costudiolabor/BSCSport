using Unity.VisualScripting;
using UnityEngine;

public class AvatarsView : View {
    [SerializeField] private GameObject[] avatars;

    private int lastIndex;
    
    public void Initialize() {
        HideAvatars();
    }

    private void HideAvatars() {
        foreach (var avatar in avatars) {
            avatar.SetActive(false);
        }
    }
    
    public void Idle() {
        SetActiveObject(0);
    }

    public void KickBall() {
        SetActiveObject(1);
    }

    public void BallIdle() {
        SetActiveObject(2);
    }

    public void BallWaiting() {
        SetActiveObject(3);
    }

    private void SetActiveObject(int currentIndex) {
        avatars[lastIndex].SetActive(false);
        avatars[currentIndex].SetActive(true);
        lastIndex = currentIndex;
    }
}
