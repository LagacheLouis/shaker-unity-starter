using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shaker;

namespace TempNamespace
{
    [DefaultExecutionOrder(-10)]
    public class GameManager : Singleton<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
    }
}

