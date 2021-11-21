using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Slider speed;
    [SerializeField] Slider jumpHeight;
    [SerializeField] Slider turnRate;

    [SerializeField] PlayerMovement pm;


    void Start()
    {
        speed.minValue = 500;
        speed.maxValue = 5000;
        speed.value = pm.RunSpeed;

        jumpHeight.minValue = 10000;
        jumpHeight.maxValue = 100000;
        jumpHeight.value = pm.JumpHeight;

        turnRate.minValue = 0.2f;
        turnRate.maxValue = 1.2f;
        turnRate.value = pm.TurnRate;
    }


    // Called by Slider's OnValueChanged methods
    public void SpeedChanged()
    {
        pm.RunSpeed = speed.value;
    }

    public void JumpHeightChanged()
    {
        pm.JumpHeight = jumpHeight.value;
    }

    public void TurnRateChanged()
    {
        pm.TurnRate = turnRate.value;
    }
}
