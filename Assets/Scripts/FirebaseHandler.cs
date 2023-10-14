using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseHandler : MonoBehaviour
{
    public FirebaseAuthHandler firebaseAuthHandlerInstance;
    public FirebaseDBHandler firebaseDBHandlerInstance;
    public UserData tempdata = null;

    public string json;

    public static FirebaseHandler Instance;
    private void Awake()
    {
        Instance = this;
        firebaseAuthHandlerInstance = GetComponent<FirebaseAuthHandler>();
        firebaseDBHandlerInstance = GetComponent<FirebaseDBHandler>();
    }


    void Start()
    {

    }

    [ContextMenu("PrintJson")]
    void PrintJson()
    {
        print(Newtonsoft.Json.JsonConvert.DeserializeObject<FirebaseLoginResponse>(json).user.displayName);
    }
}
