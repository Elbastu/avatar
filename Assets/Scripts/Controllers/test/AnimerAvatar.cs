using UnityEngine;
using System.Collections.Generic;
public class AnimerAvatar : InterfaceAnimerAvatar
{
    public void Animer_avatar(string nom_animation, Animator animator)
    {
        List<string> dataset_animation= new List<string>{"good_response","bad_response"};
        if (dataset_animation.Contains(nom_animation))
        {// si l'animation name == to one of the list of animation dataset animate else do nothing !
            animator.SetTrigger(nom_animation);
        }
    }
}
