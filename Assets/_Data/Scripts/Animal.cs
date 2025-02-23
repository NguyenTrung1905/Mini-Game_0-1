using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected bool showDebug = true;
    int legCount = 2;
    float weight = 0.5f;

    private void Awake()
    {
        this.RandomWeight();
    }

    /* public abstract string làm phương thức cha trong lớp cha "4 chân", các lớp con có thể thống nhất
     sử dụng phương thức này bằng cách thay abstract bằng override và tự tạo đoạn mã phù hợp với yêu cầu
    của từng lớp con*/
    public abstract string GetName();
    public abstract string MakeSound();

    protected virtual void RandomWeight()
    {
        if(showDebug) Debug.Log(transform.name + " :RandomWeight");
        /*Random là hàm dựng sẵn/ hàm trong thư viện sẵn có/ Library*/
        this.weight = Random.Range(1f, 30f);
    }

    public virtual float GetWeight()
    {
        return this.weight;
    }
    public virtual int CountLeg()
    {
        return this.legCount;
    }

    public virtual string GetInfo()
    {
        return this.GetName() 
            + "/Sound: " + this.MakeSound() 
            + "/Leg: " + this.CountLeg() 
            + "/Weight: " + this.GetWeight();
    }
} 
