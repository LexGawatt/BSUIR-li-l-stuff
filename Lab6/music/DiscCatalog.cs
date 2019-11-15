using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab6.music
{
    public class DiscCatalog
    {
        private Hashtable discs = new Hashtable();
        private int lastId;

        public DiscCatalog()
        {
            SaveDiscs();           
        }

        private void SaveDiscs()
        {
            discs.Add(++lastId, new Disc("All about 90s", new List<Song>
            {
                new Song("Closing time", "Semisonic"),
                new Song("Losing my religion", "R.E.M"),
                new Song("Under the bridge", "RHCP"),
                new Song("Californification", "RHCP")
            }));
            discs.Add(++lastId, new Disc("Jazz classics", new List<Song>
            {
                new Song("Autumn leaves", "Chet Baker"),
                new Song("Coffee cold", "Galt MacDermot"),
                new Song("Nutty", "Thelpnius Monk")
            }));
            discs.Add(++lastId, new Disc("Hip-hop essentials", new List<Song>
            {
                new Song("So woke", "No Malice"),
                new Song("Feels so good", "A$AP Mob"),
                new Song("Wealth", "Erzo"),
                new Song("WISH YOU WELL", "Amir Obe")
            }));
        }

        public int SaveDisc(Disc disc)
        {
            discs.Add(++lastId, disc);
            return lastId;
        }

        public void DeleteDisc(int id)
        {
            discs.Remove(id);
        }

        public void DeleteDisc(Disc disc)
        {
            foreach (DictionaryEntry entry in discs)
            {
                if (!entry.Value.Equals(disc)) continue;
                
                discs.Remove(entry.Key);
                return;
            }
        }

        public List<Disc> FindAllDiscs()
        {
            return discs.Values.OfType<Disc>().ToList();
        }

        public Disc FindDisc(int id)
        {
            return (Disc) discs[id];
        }

        public List<Song> FindSongsByAuthor(string author)
        {
            var result = new List<Song>();
            foreach (DictionaryEntry entry in discs)
            {
                result.AddRange(((Disc) entry.Value).Songs.Where(song => song.Author.Equals(author)));
            }

            return result;
        }
    }
}