using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interectable : MonoBehaviour
{
    public objectTypes objectType; //Variavel que vai ser acessada pelo inspetor e vai permitir escolher qual objeto se trata

    public enum objectTypes { //Seletor de objetos
        Enemy, Chest, Item, Gold, Npc, Store
    }
}
