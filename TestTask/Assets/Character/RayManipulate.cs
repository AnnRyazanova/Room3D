using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManipulate : MonoBehaviour
{
    private Camera camera;

	void Start ()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    private void OnGUI()
    {
        int sizePoint = 12;
        float positionX = camera.pixelWidth / 2 - sizePoint / 4;
        float positionY = camera.pixelHeight / 2 - sizePoint / 2;
        GUI.Label(new Rect(positionX, positionY, sizePoint, sizePoint), "*");
    }

    public Vector3 r;
	void Update ()
    {
        Vector3 position = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
        Ray ray = camera.ScreenPointToRay(position);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            BoxTarget box = hitObject.GetComponent<BoxTarget>();
            if (box != null)
                box.Destroy();
        }
    }

    
}
