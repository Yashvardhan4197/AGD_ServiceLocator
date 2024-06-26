using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<t> : MonoBehaviour where t: GenericMonoSingleton<t>
{
    private static t instance;
    public static t Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = (t)this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
