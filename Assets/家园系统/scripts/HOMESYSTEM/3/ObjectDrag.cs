using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 startPos;
    public float deltaX, deltaY;

    void Start()
    {
        startPos = Input.mousePosition;
        startPos = Camera.main.ScreenToWorldPoint(startPos);
        deltaX = startPos.x - transform.position.x;
        deltaY = startPos.y - transform.position.y;
    }

    void Update()
    {
        //get the current position of the mouse (touch) and convert to world
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //calculate the new position by subtracting the offset
        Vector3 pos = new Vector3(mousePos.x - deltaX, mousePos.y - deltaY);

        //convert to cell position on a grid
        Vector3Int cellPos = GridBuildingSystem.current.gridLayout.WorldToCell(pos);
        //convert back to local to provide grid snapping
        transform.position = GridBuildingSystem.current.gridLayout.CellToLocalInterpolated(cellPos);
    }

    private void LateUpdate()
    {
        //touch release - object has to be placed
        if (Input.GetMouseButtonUp(0))
        {
            //check if we can place
            gameObject.GetComponent<Building>().CheckPlacement();
            //destroy drag since we don't need it
            Destroy(this);
        }
    }



}
