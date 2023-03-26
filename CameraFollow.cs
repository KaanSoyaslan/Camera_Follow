using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player")!=null )
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; //hedef bulundu 

            TargetPointCalculate();//mesafe hesabý 

            float y = CalculateY(CarController2.AracHýz); //aracýn hýzýnýn geldiði kýsým

            if (y < 5) // araç ekrandan çýkmasýn
            {
                transform.localRotation = Quaternion.Euler(new Vector3(55, 0, 0)); //maximum açý
            }
            else
            {
                transform.localRotation = Quaternion.Euler(new Vector3(y + 50, 0, 0)); //normal açý
            }
  
        }
        else
        {
            target = null; //ölündüðünde vs bug yaþanmamasý için
        }
      

        //hýz 5 ila 20 arasýnda iken ++30 a dek yükselttim
        //camera angel 70 ila 55 arasý olmalý

        //  Cam-50 dersek (50 fark aldým ki denklem basitleþsin)
        //5-20   20 ye 5 olur
    }

    private void TargetPointCalculate() // hedef konum hesaplayýcý (oyuncu aracý)
    {
       gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z - 20); //traffic runner car position
    }

    public static float CalculateY(float x) //açý hesaplayýcý
    {
        return -3 * x / 5 + 22;
    }
}