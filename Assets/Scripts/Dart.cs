using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public GameObject player;
    Vector3 follow_direction;
    public Material bulletMat;
    int velocity = 500;
    int bulletLimit = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        follow_direction = Vector3.Normalize(player.transform.position - transform.position) * velocity;
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Player" && bulletLimit < 100) {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bullet.tag = "Bullet";
            bullet.GetComponent<MeshRenderer>().material = bulletMat;
            bullet.transform.position = new Vector3(player.transform.position.x, 30, player.transform.position.z);
            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().AddForce(follow_direction);
            bulletLimit++;
        }
    }

    void Update()
    {
                
    }
}
