using UnityEngine;
using System.Collections;

public class Avatars : ScriptableObject {

    public Avatar[] avatars;

    public Avatar GetAvatarById(int id)
    {
        if (avatars == null)
            return null;
        for (int i = 0; i < avatars.Length; i++)
        {
            if (avatars[i].id == id)
            {
                return avatars[i];
            }
        }
        return avatars[avatars.Length];
    }
}
