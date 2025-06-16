using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField]
    private float heldTimerMax = 0.2f;
    private float heldTimer = 0f;

    //private Vector3 scaleChange = new Vector3(0f, 0.1f, 0f);
    [SerializeField]
    private float scaleIncrease = 0.1f;
    private bool upHeld = false;

    [SerializeField]
    private float scaleDecrease = 0.1f;
    private bool downHeld = false;

    private void Update()
    {
        ScaleListener();
    }

    private void ScaleListener()
    {
        if (upHeld)
        {
            if (heldTimer < heldTimerMax)
            {
                heldTimer += Time.deltaTime;
            }
            if (heldTimer >= heldTimerMax)
            {
                heldTimer = 0f;
                IncreaseSizeUpCalculation();
            }
        }

        if (downHeld)
        {
            if (heldTimer < heldTimerMax)
            {
                heldTimer += Time.deltaTime;
            }
            if (heldTimer >= heldTimerMax)
            {
                heldTimer = 0f;
                DecreaseSizeDownCalculation();
            }
        }
    }

    public void IncreaseSizeUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {            
            upHeld = true;
        }
        if (context.canceled)
        {
            upHeld = false;
        }
    }

    public void DecreaseSizeDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            downHeld = true;
        }
        if (context.canceled)
        {
            downHeld = false;
        }
    }

    private void IncreaseSizeUpCalculation()
    {
        if(transform.localScale.x <= 0.1f)
        {
            return;
        }

        if(transform.localScale.x > 0f)
        {
            transform.localScale += new Vector3(-scaleDecrease, scaleIncrease, 0f);
            transform.position += new Vector3(0f, 0.05f, 0f);
        }
    }

    private void DecreaseSizeDownCalculation()
    {
        if (transform.localScale.y <= 0.1f)
        {
            return;
        }

        if (transform.localScale.y > 0f)
        {
            transform.localScale -= new Vector3(-scaleDecrease, scaleDecrease, 0f);
            transform.position -= new Vector3(0f, 0.05f, 0f);
        }
    }
}
