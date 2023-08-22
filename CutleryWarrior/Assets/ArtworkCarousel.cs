using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArtworkCarousel : MonoBehaviour
{
    public List<GameObject> artworks; // Lista degli oggetti d'arte
    private int currentIndex = 0; // Indice dell'oggetto corrente nel carosello
    private void Start()
    {
        ShowCurrentArtwork();
    }
    public void NextArtwork()
    {
        // Passa all'opera d'arte successiva nell'elenco
        currentIndex = (currentIndex + 1) % artworks.Count;
        ShowCurrentArtwork();
    }
    public void PreviousArtwork()
    {
        // Passa all'opera d'arte precedente nell'elenco
        currentIndex = (currentIndex - 1 + artworks.Count) % artworks.Count;
        ShowCurrentArtwork();
    }
    private void ShowCurrentArtwork()
    {
        // Nasconde tutti gli artwork
        foreach (GameObject artwork in artworks)
        {artwork.SetActive(false);}
         // Mostra l'opera d'arte corrente
        artworks[currentIndex].SetActive(true);  
    }
}