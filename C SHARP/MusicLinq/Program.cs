using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public program()
        {
            public static void Main(string[] args)
            {
                //Collections to work with
                List<Artist> Artists = JsonToFile<Artist>.ReadJson();
                List<Group> Groups = JsonToFile<Group>.ReadJson();

                //========================================================
                //Solve all of the prompts below using various LINQ queries
                //========================================================

                //There is only one artist in this collection from Mount Vernon, what is their name and age?
                Artist fromMT = Artist.Where(Artist => Artist.Hometown == "mount Vernon").Single();
                Console.WriteLine("The artist from {Artist.Hometown} is {fromMT.ArtistName}");

                //Who is the youngest artist in our collection of artists?
                Artist young = Artist.OrderBy(Artist => Artist.age).First();


                //Display all artists with 'William' somewhere in their real name
                List<Artist> will = Artist.Where(Artist => Artist.RealName.Contains("William")).ToList();

                //Display the 3 oldest artist from Atlanta
                List<Artist> fromAT = Artist.Where(artist => artist.Hometown == "Atlanta")
                                            .OrderByDescending(artist => artist.age)
                                            .Take(3)
                                            .ToList();
                //display all groups with 8 characters of less
                List<Group> less8 = Group.Where(Group => Group.GroupName.Length() > 8).ToList();
                

                //(Optional) Display the Group Name of all groups that have members that are not from New York City
                List<Group> notNY = Group.Join(Groups, Artist => Artist.GroupId, Group => Group.Id, (Artist, Group) => {Artist.Group = Group; return Artist;})
                                         .Where(Artist => (Artist.Hometown != "New York City" && Artist.Group !+ null))
                                         .Select(Artist ==> Artist.Group.GroupName)
                                         .Disctinct()
                                         .ToList();

                //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            }
        }
    }
