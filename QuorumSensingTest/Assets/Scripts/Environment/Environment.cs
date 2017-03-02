﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

    public GameObject envAgent;
    private GameObject[,,] env;      //environmental agents in 3 dimentions (3D array)
    private int spaceSize;                //size of array
    public float inducer = 0;
    public float secInducer = 0.1f;


    [HideInInspector] public EnvironmentState currentState;
    [HideInInspector] public DiffusionState diffusionState;
    [HideInInspector] public EnvUpdateState envUpdateState;

    private void Awake()
    {
        spaceSize = 10;
        env = new GameObject[spaceSize, spaceSize, spaceSize];
        for (int z = 0; z < spaceSize; z++)
        {
            for (int y = 0; y < spaceSize; y++)
            {
                for (int x = 0; x < spaceSize; x++)
                {
                    env[x, y, z] = Instantiate(envAgent, new Vector3(x, y, z), Quaternion.identity);
                    env[x, y, z].name = "env" + x.ToString() + y.ToString() + z.ToString();
                }
            }
        }

        diffusionState = new DiffusionState(this);
        envUpdateState = new EnvUpdateState(this);
    }

    // Use this for initialization
    void Start () {
        currentState = diffusionState;
	}
	

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
}
