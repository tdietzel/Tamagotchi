using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class PetsController : Controller
  {
    [HttpPost("/pets")]
    public ActionResult Create(string petName)
    {
      Pet newPet = new Pet(petName);
      return RedirectToAction("Index");
    }

    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }

    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Pet foundPet = Pet.Find(id);
      if (foundPet != null)
      {
        return View(foundPet);
      }
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/action")]
    public ActionResult Perform(int petId, string action)
    {
      Pet foundPet = Pet.Find(petId);
      if (foundPet != null)
      {
        switch (action)
        {
          case "feed":
            foundPet.Feed(20);
            break;
          case "sleep":
            foundPet.Sleep();
            break;
          case "play":
            if (foundPet.Energy > 2)
            {
              foundPet.Play(10);
              break;
            }
            else
            {
              TempData["LowEnergyAlert"] = "Your pet is too tired to play!";
              break;
            }
          case "delete":
            Pet.Delete(petId);
            return RedirectToAction("Index");
        }
      }
      return RedirectToAction("Show", new { id = petId });
    }
    [HttpPost("/pets/applyItem")]
    public ActionResult ApplyItemToPet([FromBody] ApplyItemModel model)
    {
      var pet = Pet.Find(model.PetId);
      if (pet != null)
      {
        if (model.ItemType == "food")
        {
          var food = Food.Find(model.ItemId);
          if (food != null)
          {
            pet.Feed(food.Fullness);
            Food.Delete(food.Id);
            // return Json(new { success = true, newFullness = pet.Fullness, newEnergy = pet.Energy, newHappiness = pet.Attention });
          }
        }
        else if (model.ItemType == "toy")
        {
          var toy = Toy.Find(model.ItemId);
          if (toy != null)
          {
            pet.Play(toy.Excitement);
            Toy.Delete(toy.Id);
            // return Json(new { success = true, newFullness = pet.Fullness, newEnergy = pet.Energy, newHappiness = pet.Attention });
          }
        }
      }
      return Json(new { success = false });
    }

    public class ApplyItemModel
    {
      public int PetId { get; set; }
      public int ItemId { get; set; }
      public string ItemType { get; set; }
    }
  }
}