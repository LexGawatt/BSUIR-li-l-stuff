namespace Lab6.music
{
    public class Song
    {
        private readonly string songName;
        private readonly string author;

        public Song(string songName, string author)
        {
            this.songName = songName;
            this.author = author;
        }

        public string SongName => songName;
        public string Author => author;

        public override string ToString()
        {
            return $"{nameof(songName)}: {songName}, {nameof(author)}: {author}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Song) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((songName != null ? songName.GetHashCode() : 0) * 397) ^ (author != null ? author.GetHashCode() : 0);
            }
        }
    }
}