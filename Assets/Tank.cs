using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : BaseTank
{
    public static Tank instance;
    new private void Awake()
    {
        base.Awake();
        instance = this;
    }
}

public class BaseTank : MonoBehaviour
{
    public static List<BaseTank> tanks = new();
    public float MaxHp = 100;
    public int hp = 100;

    public Slider hpSlider;
    protected void Awake() => tanks.Add(this);
    protected void Start() => updateHpUI();
    private void OnDestroy() => tanks.Remove(this);
    void updateHpUI() => hpSlider.value = hp / MaxHp;
    public void Damage(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
        updateHpUI();
    }
}