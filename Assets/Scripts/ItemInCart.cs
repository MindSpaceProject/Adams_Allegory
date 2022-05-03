using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInCart: MonoBehaviour {
    [SerializeField] private Transform inCart;
 
    private void Start() {
        
        this.transform.position = inCart.position;
        this.transform.parent = inCart.transform;

    }

}