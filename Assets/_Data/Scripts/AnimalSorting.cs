using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSorting : MonoBehaviour
{
    [SerializeField] protected AnimalManager animalManager;
    [SerializeField] protected List<Animal> sortByWeight = new();

    void Start()
    {
        this.SortAnimalByWeight();

    }

    protected void SortAnimalByWeight()
    {
        if(this.animalManager.Animals.Count == 0)
        {
            Debug.Log("Recusive SortAnimalByWeight");
            Invoke(nameof(this.SortAnimalByWeight), 1);
            return;
        }


        long startTime = UnixTime.GetUnixTimeMicro();

        Debug.Log("========== Sort Animal By Weight =============");
        this.sortByWeight = new(this.animalManager.Animals);

        Animal animalX, animalY;
        for (int x = 0; x < this.sortByWeight.Count - 1; x++)
        {
            //Debug.Log("x: " + x);
            for (int y = x + 1; y < this.sortByWeight.Count; y++)
            {
                animalX = this.sortByWeight[x];
                animalY = this.sortByWeight[y];
                //Debug.Log("y: " + y);
                if (animalX.GetWeight() >= animalY.GetWeight())
                {
                    this.SwapAnimal(x, y);
                }
            }
        }
        //Debug.Log("========== Sort Animal By Weight =============");

        foreach (Animal animal in this.sortByWeight)
        {
            this.animalManager.MakeAnimalDoSomeThing(animal);
        }
    }

    protected void SwapAnimal(int x, int y)
    {
        Animal temp = this.sortByWeight[y];
        this.sortByWeight[y] = this.sortByWeight[x];
        this.sortByWeight[x] = temp;
    }
}
