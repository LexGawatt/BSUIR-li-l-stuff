using System.Collections.Generic;
using System.Linq;

namespace Lab6.music
{
    public class Disc
    {
        private readonly string discName;
        private readonly List<Song> songs;

        public Disc(string discName, List<Song> songs)
        {
            this.discName = discName;
            this.songs = songs;
        }

        public string DiscName => discName;
        public List<Song> Songs => songs;

        public override string ToString()
        {
            return $"{nameof(discName)}: {discName}, num of songs: {songs.Count}";
        }

        protected bool Equals(Disc other)
        {
            return string.Equals(discName, other.discName) && songs.SequenceEqual(other.songs);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Disc) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((discName != null ? discName.GetHashCode() : 0) * 397) ^
                       (songs != null ? songs.GetHashCode() : 0);
            }
        }
    }
}