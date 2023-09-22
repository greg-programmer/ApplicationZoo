using FrontZoo.Services;
using Microsoft.AspNetCore.Components;

namespace FrontZoo.Pages;



public partial class Addanimal
{
    public Animal animal { get; set; }
    [Inject] 
    public IRepository<Animal> Repo { get; set; }
    
    public void HandleSubmit()
    {
        var listAnimal = Repo.GetAll();
        listAnimal.Add(animal);
    }
}