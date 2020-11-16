using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    public GameObject player;
    VRLook _playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        _playerCtrl = player.GetComponent<VRLook>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            print("yes");
            _playerCtrl.canJump = true;
        }
    }
}
