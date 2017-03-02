using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public float spaceSize = 10;
    public float sensedInducer;
    public float cellSize = 1;
    public float age = 5f;
    public float ageRange = 2;
    public GameObject cell;
    public float recInducer;
    public float recPercentage = 0.1f;


    [HideInInspector] public CellState currentState;
    [HideInInspector] public GeneralBehaveState generalBehaveState;
    [HideInInspector] public DivisionState divisionState;

    private void Awake()
    {
        generalBehaveState = new GeneralBehaveState(this);
        divisionState = new DivisionState(this);
    }


    // Use this for initialization
    void Start()
    {
        currentState = generalBehaveState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
}
