using System.Collections;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public delegate void whack();
    public event whack OnWhack;

    public GameObject hammer;

    public void OnPointerClick()
    {
        GameObject hammer_copy = Instantiate(hammer);
        HammerSwing hammer_script = hammer_copy.AddComponent<HammerSwing>();
        hammer_script.animal = this;
        hammer_script.OnCopyCreated();
        OnWhack();
    }
}
