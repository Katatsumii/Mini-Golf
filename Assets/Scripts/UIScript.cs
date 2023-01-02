using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitsCountText;
    [SerializeField] TextMeshProUGUI holeCountText;
    [SerializeField] GameObject continueButton;
    [SerializeField] HoleSM holeSM;

    private int hitsCount = 0;
    private void Start()
    {
        Shoot.ShootAction += AddShootCount;
        HoleScript.BallInTheHole += ContinueButtonEnable;
        hitsCountText.text = "Hits: " + hitsCount;
        holeSM.StateChange += SetHoleName;
        holeSM.StateChange += ResetShootCount;
    }
    private void ContinueButtonEnable()
    {
        continueButton.SetActive(true);
    }
    private void ResetShootCount()
    {
        hitsCount=0;
        hitsCountText.text= "Hits: " + hitsCount;
    }
    private void AddShootCount()
    {
        hitsCount++;
        hitsCountText.text = "Hits: " + hitsCount;
    }
    private void SetHoleName()
    {
        holeCountText.text = holeSM.currentState.nameOfState;
    }
    public void ContinueButtonFunction()
    {
        holeSM.ChangeState(holeSM.IterateThroughStates(holeSM.currentState));
    }
}
