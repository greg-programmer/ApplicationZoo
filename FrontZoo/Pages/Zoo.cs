
using FrontZoo.Services;
using Microsoft.AspNetCore.Components;

namespace FrontZoo.Pages;

public partial class Zoo
{
    [Inject]
    public IRepository<Animal> repository { get; set; }
    
    private List<Animal> AnimalList { get; set; } = new();
    private string? LoadingMessage { get; set; }
    public bool Description { get; set; } = false;

    public Dictionary<int, string> Race = new()
    {
        { 1, "Félin" }
    };

    
    
    protected override void OnInitialized()
    {
        LoadingMessage = "Récupération des Pizzas...";
        AnimalList = new List<Animal>(repository.GetAll());
        LoadingMessage = "";
    }

    public void ShowDesc()
    {
        Description = true;
    }
    
    public void CloseDesc()
    {
        Description = true;
    }
    
}