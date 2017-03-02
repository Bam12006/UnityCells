using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionState : CellState
{
    private readonly Cell self;
    private float birthTime;
    private float cellAge;
    private Vector3 pos;
    public GameObject cell;

    public DivisionState(Cell statePatternCell)
    {
        self = statePatternCell;
    }

    public void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {

    }

    public void ToDivisionState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToGeneralBehaveState()
    {
        self.currentState = self.generalBehaveState;
    }

    void Division()
    {
        birthTime = Time.time;
        self.age = self.age + Random.Range(0, self.ageRange);
        pos = Random.onUnitSphere * 2;
        cell = Cell.Instantiate(self.cell, new Vector3(self.transform.position.x + pos.x, self.transform.position.y + pos.y, 
            self.transform.position.z + pos.z), Quaternion.identity);
        cell.name = "cell" + birthTime.ToString();
        
    }
}
