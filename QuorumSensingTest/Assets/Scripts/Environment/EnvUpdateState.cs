using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvUpdateState : EnvironmentState
{
    private readonly Environment env;

    public EnvUpdateState(Environment environment)
    {
        env = environment;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cell"))
        {
            env.inducer = env.inducer + env.secInducer;
        }
        if (other.gameObject.CompareTag("Env"))
            ToDiffusionState();
    }

    public void ToDiffusionState()
    {
        env.currentState = env.diffusionState;
    }

    public void ToEnvUpdateState()
    {
        Debug.Log("Can't transition to same state");
    }
}
