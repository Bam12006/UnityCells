using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnvironmentState
{

    void OnTriggerStay(Collider other);

    void ToDiffusionState();

    void ToEnvUpdateState();

}
