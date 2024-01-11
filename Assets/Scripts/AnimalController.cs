using System.Collections;
using UnityEngine;

/// <summary>
/// This script manage all the things related with the funcionalities of the hammer
/// </summary>
public class AnimalController : MonoBehaviour
{
    public delegate void whack();
    public event whack OnWhack;

    public GameObject hammer;

    /// <summary>
    /// This function initialize the process of destroy an animal
    /// </summary>
    public void OnPointerClick()
    {
        GameObject hammer_copy = Instantiate(hammer);
        HammerSwing hammer_script = hammer_copy.AddComponent<HammerSwing>();
        hammer_script.animal = this;
        hammer_script.OnCopyCreated();
        OnWhack();
    }
}
