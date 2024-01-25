using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Toy {

    public string Name { get; set; }
    public int Excitement {get;set;}
    public int Id {get;}
    private static int nextId = 1;

    public Toy(string name) {
      Name = name;
      SetExcitementBasedOnName();
      _instances.Add(this);
      Id = nextId;
      nextId++;
    }

    private static List<Toy> _instances = new List<Toy>();
    private static Dictionary<string, int> ExcitementDictionary = new Dictionary<string, int>
    {
      {"Ball", 20},
      {"Bone", 30},
      {"frisbee", 50}
    };
    
    public static List<Toy> GetAll()
    {
      return _instances;
    }

    public static Dictionary<string,int> GetToys()
    {
      return ExcitementDictionary;
    }
    private void SetExcitementBasedOnName()
    {
      if (ExcitementDictionary.ContainsKey(Name))
      {
        Excitement = ExcitementDictionary[Name];
      }
      else
      {
        Excitement = 0;
      }
    }
  }
}