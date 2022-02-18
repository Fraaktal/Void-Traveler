using UnityEngine;

public class Icon : MonoBehaviour
{
    private float ypos = 0;
    private bool goUp = true;
    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            transform.Rotate(3.0f, 0, 0, Space.Self);
            
            if (goUp)
            {
                Vector3 current = transform.localPosition;
                current.y += 0.01f;
                ypos += 0.01f;
                transform.localPosition = current;
                if (ypos >= 0.5)
                {
                    goUp = false;
                }
            }
            else
            {
                Vector3 current = transform.localPosition;
                current.y -= 0.01f;
                ypos -= 0.01f;
                transform.localPosition = current;
                if (ypos <= -0.5)
                {
                    goUp = true;
                }
            }
        }
    }
}