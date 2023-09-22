namespace FrontZoo.Services;

public class AnimalRepository : IRepository<Animal>
{
    private List<Animal> animalList = new List<Animal>()
    {
        new Animal { Id = 1, Age = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "lion" ,SpecieId = 1,ImagePath = "https://images.unsplash.com/photo-1546182990-dffeafbe841d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8fA%3D%3D&w=1000&q=80"},
        new Animal { Id = 2, Age = 4, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "guépard", SpecieId = 1, ImagePath = "https://upload.chatsdumonde.com/img_global/24-cousins-du-chat/_light-1285-guepard.jpg"},
        new Animal { Id = 3, Age = 5, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "panthère", SpecieId = 1,ImagePath = "https://www.parcanimalierlabarben.com/wp-content/uploads/2018/02/panthere-01052020-9.jpg"},
        new Animal { Id = 4, Age = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "jaguare" , SpecieId = 1,ImagePath = "https://www.anigaido.com/media/zoo_animaux/101-200/145/jaguar-1-thomas-pierre-xl.jpg" },
        new Animal { Id = 5, Age = 7, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "tigre" , SpecieId = 1, ImagePath = "https://fac.img.pmdstatic.net/fit/https.3A.2F.2Fi.2Epmdstatic.2Enet.2Ffac.2F2023.2F05.2F24.2Fee6f206e-5d13-465c-a22b-f5244b3c81d5.2Ejpeg/1200x1200/quality/80/crop-from/center/le-tigre-un-animal-moins-cruel-qu-on-ne-le-dit.jpeg"}
    };

    private int lastId = 5;
    
    public Animal? Get(int id)
    {
        return animalList.FirstOrDefault(p => p.Id == id);
    }

    public List<Animal> GetAll()
    {
        return animalList;
    }

    public bool Post(Animal animal)
    {
        animal.Id = ++lastId;
        animalList.Add(animal);
        return true;
    }

    public bool Put(Animal animal)
    {
        var animalfromdb = animalList.FirstOrDefault(p => p.Id == animal.Id);
        if (animalfromdb == null) return false;
        animalfromdb = animal;
        return true;
    }

    public bool Delete(int id)
    {
        var nb = animalList.RemoveAll(p => p.Id == id);
        return nb == 1;
    }
}