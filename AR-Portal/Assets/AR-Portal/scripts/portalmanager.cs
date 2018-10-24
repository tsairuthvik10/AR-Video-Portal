using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class portalmanager : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject sponza;
    private Material[] sponzamaterials;
    private Material portalplanematerial;
	// Use this for initialization
	void Start () {
        sponzamaterials = sponza.GetComponent<Renderer>().sharedMaterials;
        portalplanematerial = GetComponent<Renderer>().sharedMaterial;
    }
	
	// Update is called once per frame
    void OnTriggerStay (Collider collider) {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if (camPositionInPortalSpace.y <= 0.0f)
        {
            for (int i = 0; i < sponzamaterials.Length; ++i)
            {
                sponzamaterials[i].SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            }
            portalplanematerial.SetInt("_CullMode", (int)CullMode.Front);

        }
        else if(camPositionInPortalSpace.y < 0.5f)
        {
            for (int i = 0; i < sponzamaterials.Length; ++i)
            {
                sponzamaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            portalplanematerial.SetInt("_CullMode", (int)CullMode.Off);
        }
        else {
            for (int i = 0; i < sponzamaterials.Length; ++i)
            {
                sponzamaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            portalplanematerial.SetInt("_CullMode", (int)CullMode.Back);
        }
	}
}
