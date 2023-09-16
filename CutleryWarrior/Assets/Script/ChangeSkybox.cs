using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material newSkyboxMaterial_G; // Il nuovo materiale Skybox che desideri applicare
    public GameObject Giorno; // Il nuovo materiale Skybox che desideri applicare
    public Material newSkyboxMaterial_N; // Il nuovo materiale Skybox che desideri applicare
    public GameObject Notte; // Il nuovo materiale Skybox che desideri applicare
    public bool changeSkyboxOnTrigger = true; // Imposta questo booleano su "true" se vuoi cambiare il materiale Skybox quando il trigger viene attivato

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {ChangeSkyboxMaterial();}
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {ChangeSkyboxMaterial();}
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {ChangeSkyboxMaterial();}
    }

    public void ChangeSkyboxMaterial()
    {
        // Cambia il materiale Skybox
        if(changeSkyboxOnTrigger){
        RenderSettings.skybox = newSkyboxMaterial_N;
        Notte.SetActive(true);
        Giorno.SetActive(false);
        // Ricarica l'illuminazione per riflettere il nuovo Skybox
        DynamicGI.UpdateEnvironment();
        changeSkyboxOnTrigger = false;}
        else if(!changeSkyboxOnTrigger){
        RenderSettings.skybox = newSkyboxMaterial_G;
        Notte.SetActive(false);
        Giorno.SetActive(true);
        // Ricarica l'illuminazione per riflettere il nuovo Skybox
        DynamicGI.UpdateEnvironment(); 
        changeSkyboxOnTrigger = true;}
    }
}