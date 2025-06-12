using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleChanger : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0f, 0.1f, 0f);

    public void IncreaseSize(InputAction.CallbackContext context)
    {
        IncreaseSizeCalculation();
    }

    private void IncreaseSizeCalculation()
    {
        transform.localScale += scaleChange;
        transform.position += scaleChange;
    }
}
