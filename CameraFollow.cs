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

            TargetPointCalculate();//mesafe hesab� 

            float y = CalculateY(CarController2.AracH�z); //arac�n h�z�n�n geldi�i k�s�m

            if (y < 5) // ara� ekrandan ��kmas�n
            {
                transform.localRotation = Quaternion.Euler(new Vector3(55, 0, 0)); //maximum a��
            }
            else
            {
                transform.localRotation = Quaternion.Euler(new Vector3(y + 50, 0, 0)); //normal a��
            }
  
        }
        else
        {
            target = null; //�l�nd���nde vs bug ya�anmamas� i�in
        }
      

        //h�z 5 ila 20 aras�nda iken ++30 a dek y�kselttim
        //camera angel 70 ila 55 aras� olmal�

        //  Cam-50 dersek (50 fark ald�m ki denklem basitle�sin)
        //5-20   20 ye 5 olur
    }

    private void TargetPointCalculate() // hedef konum hesaplay�c� (oyuncu arac�)
    {
       gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z - 20); //traffic runner car position
    }

    public static float CalculateY(float x) //a�� hesaplay�c�
    {
        return -3 * x / 5 + 22;
    }
}