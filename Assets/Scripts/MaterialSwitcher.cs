using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialSwitcher : MonoBehaviour
{
    public Material[] materials = new Material[0];
    public int materialIndex = 0;

    private new Renderer renderer = null;

    public void Start() {
        renderer = GetComponent<Renderer>();
        onChangeIndex();
    }

    public void setMaterialIndex(int index) {
        materialIndex = index;
        onChangeIndex();
    }

    public void incrementMaterialIndex() {
        materialIndex++;
        onChangeIndex();
    }

    public void decrementMaterialIndex() {
        materialIndex--;
        onChangeIndex();
    }


    private void onChangeIndex() {
        if (materialIndex >= materials.Length) materialIndex = 0;
        else if (materialIndex < 0) materialIndex = materials.Length - 1;

        renderer.material = materials[materialIndex];
    }
}
