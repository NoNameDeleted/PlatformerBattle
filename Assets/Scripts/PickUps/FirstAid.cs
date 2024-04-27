using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private int _healAmount = 20;

    public int HealAmount => _healAmount;
}
