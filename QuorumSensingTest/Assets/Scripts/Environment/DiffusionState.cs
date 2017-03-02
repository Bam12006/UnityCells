using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffusionState : EnvironmentState
{
    private readonly Environment env;
    private float diff = 0.001f;

    public DiffusionState(Environment environment)
    {
        env = environment;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Env"))
        {
            env.inducer = env.inducer + diff * (other.gameObject.GetComponent<Environment>().inducer - env.inducer); //environment diffusion equation
            env.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, env.inducer);                //set concentration by transparency change
        }

        if (other.gameObject.CompareTag("Cell"))
            ToEnvUpdateState();
    }

    public void ToDiffusionState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToEnvUpdateState()
    {
        env.currentState = env.envUpdateState;
    }

}
