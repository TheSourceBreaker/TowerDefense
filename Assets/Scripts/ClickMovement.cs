using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{
    public float speed;
    Vector3 movePos;

    private void Start()
    {
        movePos = transform.position;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // The ray spawns at the camera and aims torward the position of the mouse of the screen.
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Raycast then grabs the information from the mouse's position and back then runs the code.
            {
                movePos = Input.mousePosition;
            }
        }
        transform.position += movePos * Time.deltaTime; //PROBLEM
    }
}
