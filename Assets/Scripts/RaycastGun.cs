using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Shooter();
        }
    }

    void Shooter()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {

            RaycastTargetBehavior target = hit.transform.GetComponent<RaycastTargetBehavior>();
            target.Target();
            Debug.Log(hit.transform.name);
        }
    }
}
