using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform diSelection;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            if(diSelection != null)
            {
                var selectionRenderer = diSelection.GetComponent<Renderer>();
                selectionRenderer.material = defaultMaterial;
                diSelection = null;
            }

            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                    diSelection = selection;
                }
                
            }
        }
        
    }
}
