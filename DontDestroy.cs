using UnityEngine;

//Script which enables objects to stay persistant 
//across scene changes
public class DontDestroy : MonoBehaviour
{
    //Determines which objects to keep persistant
    public string targetTag;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(targetTag);

        //Keeps 1 instance of object
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
