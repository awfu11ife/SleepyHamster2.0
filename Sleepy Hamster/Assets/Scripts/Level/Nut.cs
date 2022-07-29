using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField] private GameObject _eatNutParticle;

    public void DisableNut()
    {
        Instantiate(_eatNutParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
