using UnityEngine;

public class BoxCollection : MonoBehaviour
{
    [SerializeField] Transform stack;

    float stackHeight = 0;
    float stackBottomPositionY;

    void Start()
    {
        stack.localScale = new Vector3 (stack.localScale.x, stackHeight, stack.localScale.z);
        stackBottomPositionY = stack.position.y;
    }

    void Update()
    {
        // scale up the stack in Y direction, depending the on Y size of collected box.
        // collecting bigger boxes scales up stack quickly and vice versa.
        // Adjust the position of the stack so its bottom is always just above player's head.

        stack.position = new Vector3(stack.position.x, transform.position.y + stackBottomPositionY + stackHeight/2, stack.position.z);
        stack.localScale = new Vector3(stack.localScale.x, stackHeight, stack.localScale.z);

        // Turn stack invisible if it becomes too small
        if(stack.localScale.y <= 0)
            stack.gameObject.SetActive(false);
        else
            stack.gameObject.SetActive(true);
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("StackBoost"))
        {
            stackHeight += collider.gameObject.transform.localScale.y;
            Destroy(collider.gameObject);
        }
    }
}
