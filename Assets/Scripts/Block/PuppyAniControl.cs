using UnityEngine;
using System.Collections;

public class PuppyAniControl : MonoBehaviour
{
	public int count = 0;
    SpecialBlockEffect effect;
    private int max = 1;
    public void Count()
    {
        count++;
        if (count > max)
        {
            effect.OnPuppyEffectDestroyed();
        }
    }

    public void StartEffect(SpecialBlockEffect effect)
    {
        count = 0;
        this.effect = effect;
    }
}
