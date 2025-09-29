using UnityEngine;
using Project.InputSignals;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ClickGridManager : MonoBehaviour, IPointerCaptureEvent
{
    //GridCollider 

    //world.CellToWorld(GridSpaceToMove);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Grid world;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // 0 for left click, 1 for right click, 2 for middle click
        //{
        //    // ... (steps 1, 2, and 3 here) ...
        //    Debug.Log($"Clicked grid cell: ({gridX}, {gridY})");
        //}
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3Int coordinates = world.WorldToCell(ray.origin);

    }

    //void OnClick(InputAction.CallbackContext context)
    //{
    //    if(context.performed)
    //    {
    //       // Debug.Log($"Clicked grid cell: ({gridX}, {gridY})");
    //        //Signals.Get<InputClickSignal>().Dispatch()
    //    }
    //}

    public void OnPointerClick(PointerDownEvent eventData)
    {
        Vector3 mousePos = eventData.localPosition;
        Debug.Log($"Mouse at {mousePos}");
        Vector3Int coordinates = world.WorldToCell(mousePos);
    }
}
