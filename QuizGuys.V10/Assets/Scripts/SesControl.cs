using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesControl : MonoBehaviour
{
    static SesControl sManager;
    // Start is called before the first frame update
    void Start()
    {
        if (sManager == null)
        {
            sManager = this;
        }
        else if (sManager != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(sManager);
    }
}
