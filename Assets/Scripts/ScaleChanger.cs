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
    private bool rightHeld = false;
    private bool leftHeld = false;
    private bool upHeld = false;
    private bool downHeld = false;

    [SerializeField]
    private float scaleDecrease = 0.1f;

    private void Update()
    {
        ScaleListener();
    }

    private void ScaleListener()
    {
        if (rightHeld)
        {
            if (heldTimer < heldTimerMax)
            {
                heldTimer += Time.deltaTime;
            }
            if (heldTimer >= heldTimerMax)
            {
                heldTimer = 0f;
                ResizeRightCalculation();
            }
        }

        if (leftHeld)
        {
            if (heldTimer < heldTimerMax)
            {
                heldTimer += Time.deltaTime;
            }
            if (heldTimer >= heldTimerMax)
            {
                heldTimer = 0f;
                ResizeLeftCalculation();
            }
        }

        if (upHeld)
        {
            if (heldTimer < heldTimerMax)
            {
                heldTimer += Time.deltaTime;
            }
            if (heldTimer >= heldTimerMax)
            {
                heldTimer = 0f;
                ResizeUpCalculation();
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
                ResizeDownCalculation();
            }
        }
    }

    public void ResizeUp(InputAction.CallbackContext context)
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

    public void ResizeDown(InputAction.CallbackContext context)
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

    public void ResizeRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rightHeld = true;
        }
        if (context.canceled)
        {
            rightHeld = false;
        }
    }

    public void ResizeLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            leftHeld = true;
        }
        if (context.canceled)
        {
            leftHeld = false;
        }
    }

    private void ResizeRightCalculation()
    {
        if(transform.localScale.y <= 0.2f)
        {
            return;
        }

        if(transform.localScale.y > 0f)
        {
            //transform.localScale += new Vector3(-scaleDecrease, scaleIncrease, 0f);
            //transform.position += new Vector3(0f, 0.05f, 0f);
            transform.position = new Vector3(transform.position.x + (scaleIncrease / 2), transform.position.y - 0.1f, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y - scaleIncrease, transform.localScale.z);
        }
    }

    private void ResizeLeftCalculation()
    {
        if (transform.localScale.y <= 0.2f)
        {
            return;
        }

        if (transform.localScale.y > 0f)
        {
            //transform.localScale -= new Vector3(-scaleDecrease, scaleDecrease, 0f);
            //transform.position -= new Vector3(0f, 0.05f, 0f);
            transform.position = new Vector3(transform.position.x - (scaleIncrease / 2), transform.position.y - 0.1f, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y - scaleIncrease, transform.localScale.z);
        }
    }

    private void ResizeUpCalculation()
    {
        if (transform.localScale.x <= 0.2f)
        {
            return;
        }

        if (transform.localScale.x > 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (scaleIncrease / 2), transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x - scaleIncrease, transform.localScale.y + scaleIncrease, transform.localScale.z);
        }
    }

    private void ResizeDownCalculation()
    {
        if (transform.localScale.x <= 0.2f)
        {
            return;
        }

        if (transform.localScale.x > 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (scaleIncrease / 2), transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x - scaleIncrease, transform.localScale.y + scaleIncrease, transform.localScale.z);
        }
    }
}
