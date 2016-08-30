using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// This class will be used to Binary Format to save locally a players structure creations.
// This system is a basic ingame editor that saves the positions of all objects in the editor bounds.
// This allows players to quickly create simple structures once they gather the resources.
public class StructureIO
{
    private List<Structure> structures = new List<Structure>();
}
