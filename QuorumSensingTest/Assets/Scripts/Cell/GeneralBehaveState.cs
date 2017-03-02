using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBehaveState : CellState
{
    private readonly Cell self;

    public GeneralBehaveState(Cell statePatternCell)
    {
        self = statePatternCell;
    }

    public void Update()
    {
        MoveCell();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Env"))
        {
            self.recInducer = self.recInducer + self.recPercentage * other.gameObject.GetComponent<Environment>().inducer;
            QuorumSensing();
        }
    }

    public void ToDivisionState()
    {
        self.currentState = self.divisionState;
    }

    public void ToGeneralBehaveState()
    {
        Debug.Log("Can't transition to same state");
    }

    void MoveCell()
    {
        self.transform.position = new Vector3(Mathf.Clamp(self.transform.position.x + Random.Range(-0.25f, 0.25f), -self.spaceSize, self.spaceSize),
            Mathf.Clamp(self.transform.position.y + Random.Range(-0.25f, 0.25f), -self.spaceSize, self.spaceSize),
            Mathf.Clamp(self.transform.position.z + Random.Range(-0.25f, 0.25f), -self.spaceSize, self.spaceSize));    //set random movement of the cell within a limit space
    }

    void QuorumSensing()
    {
        if (self.recInducer < 0.5 || Time.deltaTime >= self.age)
            ToDivisionState();
    }
}
