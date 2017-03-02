using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CellState
{

    void Update();

    void OnTriggerStay(Collider other);

    void ToDivisionState();

    void ToGeneralBehaveState();

}
