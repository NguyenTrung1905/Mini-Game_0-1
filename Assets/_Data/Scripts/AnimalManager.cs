using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected bool showDebug = true;
    [SerializeField] protected List<Transform> defaultAnimals = new();
    // [SerializeField] để tương tác trực tiếp trên Unity, trong trường hợp này là để dễ debug
    // protected cho phép các lớp con kế thừa và sử dụng biến này
    // List<Animal> animals = new(); khởi tạo một list chứa các đối tượng Animal với animals là tên biến
    [SerializeField] protected List<Animal> animals = new();
    public List<Animal> Animals => this.animals;//Cú pháp tắt lấy ra list animals

    private void Start()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("========== Start Time: " + startTime);

        this.LoadDefaultAnimals();
        this.CreateRandomAnimals();

        //AddAnimalsToList là phương thức thêm các đối tượng Animal vào list animals
        this.AddAnimalsToList();
        /*MakeAnimalsDoSomething là phương thức thực hiện hành động của các đối tượng Animal trong list 
         * animals*/
        this.MakeAnimalsDoSomething();

        long endTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("========== End Time: " + endTime);

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("========== Time Diff: " + timeDiff);
    }
    
    //LoadDefaultAnimals là phương thức thêm các đối tượng Animal vào list defaultAnimals
    protected void LoadDefaultAnimals() 
    {
        foreach (Transform child in transform)
        {
            this.defaultAnimals.Add(child);
        }
    }
    //CreateRandomAnimals là phương thức tạo ra các đối tượng Animal ngẫu nhiên
    protected void CreateRandomAnimals()
    {
        int createCount = 20000;
        for (int i = 0; i < createCount; i++)
        {
            this.CreateRandomAnimal();
        }
    }
    /*CreateRandomAnimal là phương thức tạo ra một đối tượng Animal ngẫu nhiên từ list defaultAnimals
     * và thêm vào list animals*/
    protected void CreateRandomAnimal()
    {
        //GetRandomFromDefaultAnimals là phương thức chọn ngẫu nhiên một đối tượng Animal từ list defaultAnimals
        Transform randomChild = this.GetRandomFromDefaultAnimals();
        //Instantiate là hàm tạo ra một đối tượng mới từ một đối tượng đã có
        Transform newChild = GameObject.Instantiate(randomChild);
        //Cách gán đối tượng mới vào trong AnimalManager
        newChild.parent = this.transform;
    }
    //GetRandomFromDefaultAnimals là phương thức chọn ngẫu nhiên một đối tượng Animal từ list defaultAnimals
    protected Transform GetRandomFromDefaultAnimals()
    {
        int randomIndex = Random.Range(0, this.defaultAnimals.Count);
        return this.defaultAnimals[randomIndex];
    }

    

    protected void AddAnimalsToList()
    {
        /*Transform là một lớp trong Unity, dùng để thao tác với các thành phần con của một đối tượng
         * trong game (game object), trong trường hợp này là thao tác với các đối tượng Animal ( là Game 
         * object cha) chứa script này*/
        /*child là một đối tượng con của đối tượng cha, trong trường hợp này là các đối tượng Animal. 
         * Ví dụ: Dog, Cat, Chicken,... Xem cấu trúc trong hierachy của Unity để rõ*/
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            Animal animal = child.GetComponent<Animal>();
            this.animals.Add(animal);
        }
    }
    protected void MakeAnimalsDoSomething()
    {
        Debug.Log("========== Make Animal Do Something =============");
        foreach (Animal animal in this.animals)
        {
            this.MakeAnimalDoSomeThing(animal);
        }
    }
    public void MakeAnimalDoSomeThing(Animal animal)
    {
        string info = animal.GetInfo();
        if(this.showDebug == true) Debug.Log(animal.name + ": " + info);
    }
   
}
