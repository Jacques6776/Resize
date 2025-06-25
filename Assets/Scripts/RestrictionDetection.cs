using UnityEngine;

public class RestrictionDetection : MonoBehaviour
{
    [SerializeField]
    private CollisionDirections blockDirection;

    private ScaleChanger scaleChanger;

    private int setDirection;
    
    void Start()
    {
        scaleChanger = FindFirstObjectByType<ScaleChanger>();

        switch (blockDirection)
        {
            case CollisionDirections.RestrictUp:
                setDirection = 0;
                break;

            case CollisionDirections.RestrictDown:
                setDirection = 1;
                break;

            case CollisionDirections.RestrictLeft:
                setDirection = 2;
                break;

            case CollisionDirections.RestrictRight:
                setDirection = 3;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (setDirection == 0)
            {
                scaleChanger.upRestriction = true;
            }

            if (setDirection == 1)
            {
                scaleChanger.downRestriction = true;
            }

            if (setDirection == 2)
            {
                scaleChanger.leftRestriction = true;
            }

            if (setDirection == 3)
            {
                scaleChanger.rightRestriction = true;
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (setDirection == 0)
            {
                scaleChanger.upRestriction = false;
            }

            if (setDirection == 1)
            {
                scaleChanger.downRestriction = false;
            }

            if (setDirection == 2)
            {
                scaleChanger.leftRestriction = false;
            }

            if (setDirection == 3)
            {
                scaleChanger.rightRestriction = false;
            }
        }
    }
}
