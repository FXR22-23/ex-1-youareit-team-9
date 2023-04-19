using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(x, y, z);
    }
}