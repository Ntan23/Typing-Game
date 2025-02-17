using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30.0f;
    public float panBorderThickness =10.0f;
    public bool canMove = true;
    public float scrollSpeed = 5.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;  
    public float minZ;
    public float maxZ;

    private ToggleUI toggleUI;

    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        toggleUI = FindObjectOfType<ToggleUI>();
        am = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.gameEnded)
        {
            changeMode();
            am.PlayAudioShot("Focus");
        }

        if(canMove && !GameManager.instance.gameEnded)
        {
            toggleUI.Toggle_OFF();
        }

        if(!canMove && !GameManager.instance.gameEnded)
        {
            toggleUI.Toggle_ON();
            return;
        }

        if(GameManager.instance.gameEnded)
        {
            return;
        }

        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x,minX,maxX);
        position.y = Mathf.Clamp(position.y,minY,maxY);
        position.z = Mathf.Clamp(position.z,minZ,maxZ);
        transform.position = position;
    }

    public void changeMode()
    {
        canMove = !canMove;
    }
}
