using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouserotate : MonoBehaviour
{
    public float SenX = 5, SensY = 10;
    float moveY, moveX;
    public Vector2 MinMax_Y = new Vector2(-75, 90);
    public Vector2 MinMax_X = new Vector2(-360, 360);
    CharacterController cumzone;

    //функция расчета угла поворота
    static float ClampAngle(float angle, float min, float max)
    {
        //если угол прошел расстояние от 0 до -360 то обнуляем его 
        if (angle < -360F) angle += 360F;
        //если угол прошел расстояние от 0 до 360 то обнуляем его 
        if (angle > 360F) angle -= 360F;
        //рассчитываем среднее значение поворота относительно угла 
        return Mathf.Clamp(angle, min, max);
    }
    void Start()
    {
        cumzone = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveY -= Input.GetAxis("Mouse Y") * SensY;
        moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
        moveX +=  Input.GetAxis("Mouse X") * SenX;
        moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y);
        cumzone.transform.rotation = Quaternion.Euler(moveY, moveX, 0);
    }
}