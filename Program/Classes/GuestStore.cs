/*
Dt071g, Moment3, Nils
nibo1005@student.miun.se*/
////////////////

//Här finns class, GuestStore.

//using System, innebär att du använder "System library" i projektet.
using System;
//Using, se ovan.
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//Namespaces används i C# för att organisera och ge en nivå av separerade koder.
namespace guestbook
{
//"Manageclass", Gueststore.
public class GuestStore
    {
//Filnamn json.fil. Filename pekar på jsonfil där datan lagras.
private string filename = @"gueststore.json";
//List innehåller samtliga element som lagras.
//Gömd som private i klassen Gueststore.
private List<Guest> guests = new List<Guest>();

//Konstruerare, public GuestStore, tar in arg. 
//Konstruerare instansierar Gueststore och kollar om json-filen finnes.
//Om så är fallet , så läses denna in  och deserialiseras...
public GuestStore(){ 
// If-sats, om lagrad json-data finns, then read.
if(File.Exists(@"gueststore.json")==true){ 
//Get json och deserialize. 
string jsonString = File.ReadAllText(filename);
//<Guest>, namnet på vektorn.
//Guest kan innehålla många obj. av typen guest.
//Läggs in i array, guests.
guests = JsonSerializer.Deserialize<List<Guest>>(jsonString)!;
}
}

//Metod, lägg till.
//Skickar med obj. av typen Guest
public Guest addGuest(Guest guest){
//Add, metod som används när jobbar med listor. (Som push.)
guests.Add(guest);
//Marshal, innebär att datan serialiseras för lagring(textform innan lagring).
marshalling();         
//Returnerar
return guest;
}

//Metod, ta bort.
//Skickar med ett index (int, ex. 1 ,2, 3 etc.),
public int delGuest(int index){
//RemoveAt samt berört index..
guests.RemoveAt(index);
//Spara nu, sparas efter elem. ändrats.
marshalling();
//returnerar
return index;
}

//Metod, listan
//Returnerar hela arrayen, så att alla element i denna kan bearbetas.
public List<Guest> getGuests(){
return guests;
}
//Marshal
private void marshalling()
{
// Serialize objekt och spara till fil.
var jsonString = JsonSerializer.Serialize(guests);
//Filename=gueststore.json.
File.WriteAllText(filename, jsonString);
}
}
}
